# 强制UTF8编码，避免解析错误
[Console]::InputEncoding = [System.Text.Encoding]::UTF8
[Console]::OutputEncoding = [System.Text.Encoding]::UTF8

# 切换到脚本所在目录
Set-Location (Split-Path $MyInvocation.MyCommand.Path -Parent)

# 定义核心变量
$repoOwner = "XTLS"
$repoName = "Xray-core"
$assetName = "Xray-windows-64.zip" # 要下载的文件名（固定）
$tempZipFile = ".\$assetName"
$targetExePath = '..\release\xray.exe'
$tempUnzipDir = ".\.temp_xray_unzip" # 临时解压目录（仅存放解压的压缩包内容）
$cpFileName = "xray.exe" # 要拷贝的文件

try {
    # Step 1: 调用GitHub API获取最新Release信息（禁用SSL验证，避免证书问题）
    Write-Host "Fetching latest release info from GitHub API..."
    [Net.ServicePointManager]::SecurityProtocol = [Net.SecurityProtocolType]::Tls12
    $latestRelease = Invoke-RestMethod -Uri "https://api.github.com/repos/$repoOwner/$repoName/releases/latest" -ErrorAction Stop

    # Step 2: 解析最新版本号和下载链接
    $latestVersion = $latestRelease.tag_name # 最新版本号（如v5.45.0）
    Write-Host "Found latest version: $latestVersion"

    # 从Release的assets中找到对应zip包的下载链接
    $downloadUrl = $latestRelease.assets | Where-Object { $_.name -eq $assetName } | Select-Object -ExpandProperty browser_download_url
    if (-not $downloadUrl) {
        Write-Error "Failed to find $assetName in latest release assets"
        exit 1
    }
    Write-Host "Download URL: $downloadUrl"

    # Step 3: 下载最新版本的zip包
    Write-Host "Downloading $assetName (version: $latestVersion)..."
    Invoke-WebRequest -Uri $downloadUrl -OutFile $tempZipFile -UseBasicParsing -ErrorAction Stop

    # 检查下载是否成功
    if (-Not (Test-Path $tempZipFile)) {
        Write-Error "Download failed: $tempZipFile not found"
        exit 1
    }

    # Step 4: 创建release目录（确保存在）
    $releaseDir = Split-Path $targetExePath -Parent
    if (-Not (Test-Path $releaseDir)) {
        New-Item -ItemType Directory -Path $releaseDir | Out-Null
        Write-Host "Created directory: $releaseDir"
    }

    # Step 5: 解压压缩包到临时目录（仅解压，不直接到release目录）
    Write-Host "Extracting zip to temporary directory: $tempUnzipDir..."
    # 先删除旧的临时解压目录（避免残留）
    if (Test-Path $tempUnzipDir) {
        Remove-Item -Path $tempUnzipDir -Recurse -Force
    }
    # 解压整个压缩包到临时目录
    Expand-Archive -Path $tempZipFile -DestinationPath $tempUnzipDir -Force -ErrorAction Stop

    # Step 6: 仅复制cpFile到目标路径（核心修改：只取单个文件）
    $tempExePath = Join-Path $tempUnzipDir $cpFileName
    if (-Not (Test-Path $tempExePath)) {
        Write-Error "Extraction failed: $cpFileName not found in temporary directory"
        exit 1
    }
    Write-Host "Copying only $cpFileName to $targetExePath..."
    Copy-Item -Path $tempExePath -Destination $targetExePath -Force

    # Step 7: 最终验证
    if (Test-Path $targetExePath) {
        Write-Host "Success: $cpFileName (latest version $latestVersion) saved to $targetExePath"
    } else {
        Write-Error "Failed: Target file $targetExePath does not exist"
        exit 1
    }
}
catch {
    Write-Error "Execution failed: $($_.Exception.Message)"
    exit 1
}
finally {
    # 清理临时文件：包括下载的zip包 + 临时解压目录
    if (Test-Path $tempZipFile) {
        Remove-Item -Path $tempZipFile -Force
        Write-Host "Temporary file $tempZipFile cleaned up"
    }
    if (Test-Path $tempUnzipDir) {
        Remove-Item -Path $tempUnzipDir -Recurse -Force
        Write-Host "Temporary unzip directory $tempUnzipDir cleaned up"
    }
}

exit 0