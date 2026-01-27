using Microsoft.VisualStudio.Threading;
using System.Net;
using System.Text;

namespace Netch.Utils;

public static class WebUtil
{
    public const string DefaultUserAgent = @"Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/94.0.4606.61 Safari/537.36 Edg/94.0.992.31";

    static WebUtil()
    {
        ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls12;
    }

    private static int DefaultGetTimeout => Global.Settings.RequestTimeout;

    // ✅ 单例 HttpClient（非常关键）
    private static readonly HttpClient _httpClient = CreateHttpClient();

    public static HttpClient CreateHttpClient(int? timeout = null, string? userAgent = null)
    {
        var handler = new HttpClientHandler
        {
            // 自动解压（以前 WebRequest 默认没开）
            AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
        };

        var client = new HttpClient(handler)
        {
            Timeout = TimeSpan.FromMilliseconds(timeout ?? DefaultGetTimeout)
        };

        client.DefaultRequestHeaders.UserAgent.ParseAdd(string.IsNullOrWhiteSpace(userAgent) ? DefaultUserAgent : userAgent);
        client.DefaultRequestHeaders.Accept.ParseAdd("*/*");
        client.DefaultRequestHeaders.AcceptCharset.ParseAdd("utf-8");

        return client;
    }

    public static async Task<(HttpStatusCode, string)> DownloadStringAsync(string address, string? userAgent, string? proxyServer, Encoding? encoding = null)
    {
        encoding ??= Encoding.UTF8;

        var handler = new HttpClientHandler
        {
            AutomaticDecompression =
                DecompressionMethods.GZip |
                DecompressionMethods.Deflate
        };

        if (!string.IsNullOrEmpty(proxyServer))
        {
            handler.Proxy = new WebProxy(proxyServer);
            handler.UseProxy = true;
        }

        using var client = new HttpClient(handler)
        {
            Timeout = TimeSpan.FromMilliseconds(Global.Settings.RequestTimeout)
        };

        client.DefaultRequestHeaders.UserAgent.ParseAdd(
            string.IsNullOrWhiteSpace(userAgent)
                ? DefaultUserAgent
                : userAgent);

        client.DefaultRequestHeaders.Accept.ParseAdd("*/*");
        client.DefaultRequestHeaders.AcceptCharset.ParseAdd("utf-8");

        using var response = await client.GetAsync(address);
        var status = response.StatusCode;

        response.EnsureSuccessStatusCode();

        var bytes = await response.Content.ReadAsByteArrayAsync();
        return (status, encoding.GetString(bytes));
    }

    public static async Task<byte[]> DownloadBytesAsync(string address)
    {
        using var response = await _httpClient.GetAsync(address);
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadAsByteArrayAsync();
    }

    public static async Task<(HttpStatusCode, string)> DownloadStringAsync(
        string address,
        Encoding? encoding = null)
    {
        encoding ??= Encoding.UTF8;

        using var response = await _httpClient.GetAsync(address);
        var status = response.StatusCode;

        response.EnsureSuccessStatusCode();

        var bytes = await response.Content.ReadAsByteArrayAsync();
        return (status, encoding.GetString(bytes));
    }

    public static async Task DownloadFileAsync(string address, string fileFullPath, IProgress<int>? progress)
    {
        using var response = await _httpClient.SendAsync(new HttpRequestMessage(HttpMethod.Get, address), HttpCompletionOption.ResponseHeadersRead);

        response.EnsureSuccessStatusCode();

        var total = response.Content.Headers.ContentLength ?? -1L;

        await using var input = await response.Content.ReadAsStreamAsync();
        await using var fileStream = new FileStream(
            fileFullPath,
            FileMode.Create,
            FileAccess.Write,
            FileShare.None,
            bufferSize: 4096,
            useAsync: true);

        var copyTask = input.CopyToAsync(fileStream);

        // ✅ 保留你原来的“旁路进度监控”模型
        if (progress != null && total > 0)
        {
            ReportProgressAsync(
                total,
                copyTask,
                fileStream,
                progress,
                200).Forget();
        }

        await copyTask;

        progress?.Report(100);
    }

    private static async Task ReportProgressAsync(long total, IAsyncResult downloadTask, Stream stream, IProgress<int> progress, int interval)
    {
        var last = 0;
        while (!downloadTask.IsCompleted)
        {
            var current = (int)((double)stream.Length / total * 100);
            if (last != current)
            {
                last = current;
                progress.Report(current);
            }

            await Task.Delay(interval);
        }
    }
}