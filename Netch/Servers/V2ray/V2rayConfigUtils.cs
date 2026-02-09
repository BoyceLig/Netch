using Netch.Models;
using Netch.Utils;

#pragma warning disable VSTHRD200

namespace Netch.Servers;

public static class V2rayConfigUtils
{
    public static async Task<V2rayConfig> GenerateClientConfigAsync(Server server)
    {
        var v2rayConfig = new V2rayConfig
        {
            inbounds = new object[]
            {
                new
                {
                    port = Global.Settings.Socks5LocalPort,
                    protocol = "socks",
                    listen = Global.Settings.LocalAddress,
                    settings = new
                    {
                        auth = "noauth",
                        udp = true
                    }
                }
            }
        };

        v2rayConfig.outbounds = new[] { await outbound(server) };

        return v2rayConfig;
    }

    private static async Task<Outbound> outbound(Server server)
    {
        var outbound = new Outbound
        {
            settings = new OutboundConfiguration(),
            mux = new Mux()
        };

        switch (server)
        {
            case Socks5Server socks:
                {
                    outbound.protocol = "socks";
                    outbound.settings.servers = new object[]
                    {
                    new
                    {
                        address = await server.AutoResolveHostnameAsync(),
                        port = server.Port,
                        users = socks.Auth()
                            ? new[]
                            {
                                new
                                {
                                    user = socks.Username,
                                    pass = socks.Password,
                                    level = 1
                                }
                            }
                            : null
                    }
                    };
                    outbound.settings.version = socks.Version;

                    outbound.mux.enabled = false;
                    outbound.mux.concurrency = -1;
                    break;
                }
            case VLESSServer vless:
                {
                    outbound.protocol = "vless";
                    outbound.settings.vnext = new[]
                    {
                        new VnextItem
                        {
                            address = await server.AutoResolveHostnameAsync(),
                            port = server.Port,
                            users = new[]
                            {
                                new User
                                {
                                    id = getUUID(vless.UserID),
                                    flow = vless.Flow,
                                    encryption = vless.EncryptMethod
                                }
                            }
                        }
                    };

                    outbound.settings.packetEncoding = Global.Settings.V2RayConfig.XrayCone ? vless.PacketEncoding : "none";
                    outbound.mux.packetEncoding = Global.Settings.V2RayConfig.XrayCone ? vless.PacketEncoding : "none";

                    outbound.streamSettings = boundStreamSettings(vless);

                    if (vless.tlsConfig.TLSSecureType == "xtls")
                    {
                        outbound.mux.enabled = false;
                        outbound.mux.concurrency = -1;
                    }
                    else
                    {
                        outbound.mux.enabled = vless.UseMux ?? Global.Settings.V2RayConfig.UseMux;
                        outbound.mux.concurrency = vless.UseMux ?? Global.Settings.V2RayConfig.UseMux ? 8 : -1;
                    }

                    break;
                }
            case VMessServer vmess:
                {
                    outbound.protocol = "vmess";
                    if (vmess.EncryptMethod == "auto" && vmess.tlsConfig.TLSSecureType != "none" && !Global.Settings.V2RayConfig.AllowInsecure)
                    {
                        vmess.EncryptMethod = "zero";
                    }
                    outbound.settings.vnext = new[]
                    {
                    new VnextItem
                    {
                        address = await server.AutoResolveHostnameAsync(),
                        port = server.Port,
                        users = new[]
                        {
                            new User
                            {
                                id = getUUID(vmess.UserID),
                                alterId = vmess.AlterID,
                                security = vmess.EncryptMethod
                            }
                        }
                    }
                };

                    outbound.settings.packetEncoding = Global.Settings.V2RayConfig.XrayCone ? vmess.PacketEncoding : "none";
                    outbound.mux.packetEncoding = Global.Settings.V2RayConfig.XrayCone ? vmess.PacketEncoding : "none";

                    outbound.streamSettings = boundStreamSettings(vmess);

                    outbound.mux.enabled = vmess.UseMux ?? Global.Settings.V2RayConfig.UseMux;
                    outbound.mux.concurrency = vmess.UseMux ?? Global.Settings.V2RayConfig.UseMux ? 8 : -1;
                    break;
                }
            case ShadowsocksServer ss:
                outbound.protocol = "shadowsocks";
                outbound.settings.servers = new[]
                {
                    new ShadowsocksServerItem
                    {
                        address = await server.AutoResolveHostnameAsync(),
                        port = server.Port,
                        method = ss.EncryptMethod,
                        password = ss.Password
                    }
                };
                outbound.settings.plugin = ss.Plugin ?? "";
                outbound.settings.pluginOpts = ss.PluginOption ?? "";

                if (Global.Settings.V2RayConfig.TCPFastOpen)
                {
                    outbound.streamSettings = new StreamSettings
                    {
                        sockopt = new Sockopt
                        {
                            tcpFastOpen = true
                        }
                    };
                }
                break;
            case ShadowsocksRServer ssr:
                outbound.protocol = "shadowsocks";
                outbound.settings.servers = new[]
                {
                    new ShadowsocksServerItem
                    {
                        address = await server.AutoResolveHostnameAsync(),
                        port = server.Port,
                        method = ssr.EncryptMethod,
                        password = ssr.Password,
                    }
                };
                outbound.settings.plugin = "shadowsocksr";
                outbound.settings.pluginArgs = new string[]
                {
                    "--obfs=" + ssr.OBFS,
                    "--obfs-param=" + ssr.OBFSParam ?? "",
                    "--protocol=" + ssr.Protocol,
                    "--protocol-param=" + ssr.ProtocolParam ?? ""
                };

                if (Global.Settings.V2RayConfig.TCPFastOpen)
                {
                    outbound.streamSettings = new StreamSettings
                    {
                        sockopt = new Sockopt
                        {
                            tcpFastOpen = true
                        }
                    };
                }
                break;
            case TrojanServer trojan:
                outbound.protocol = "trojan";
                outbound.settings.servers = new[]
                {
                    new ShadowsocksServerItem // I'm not serious
                    {
                        address = await server.AutoResolveHostnameAsync(),
                        port = server.Port,
                        method = "",
                        password = trojan.Password,
                        flow =  trojan.Flow
                    }
                };

                outbound.streamSettings = new StreamSettings
                {
                    network = trojan.Transport.TransferProtocol,
                    security = trojan.tlsConfig.TLSSecureType
                };
                if (trojan.tlsConfig.TLSSecureType != "none")
                {
                    var tlsSettings = new TlsSettings
                    {
                        allowInsecure = Global.Settings.V2RayConfig.AllowInsecure,
                        serverName = trojan.Transport.Host ?? "",
                    };

                    switch (trojan.tlsConfig.TLSSecureType)
                    {
                        case "tls":
                            outbound.streamSettings.tlsSettings = tlsSettings;
                            break;
                        case "xtls":
                            outbound.streamSettings.xtlsSettings = tlsSettings;
                            break;
                    }
                }

                if (Global.Settings.V2RayConfig.TCPFastOpen)
                {
                    outbound.streamSettings.sockopt = new Sockopt
                    {
                        tcpFastOpen = true
                    };
                }
                break;
            case WireGuardServer wg:
                outbound.protocol = "wireguard";
                outbound.settings.address = await server.AutoResolveHostnameAsync();
                outbound.settings.port = server.Port;
                outbound.settings.localAddresses = wg.LocalAddresses.SplitOrDefault();
                outbound.settings.peerPublicKey = wg.PeerPublicKey;
                outbound.settings.privateKey = wg.PrivateKey;
                outbound.settings.preSharedKey = wg.PreSharedKey;
                outbound.settings.mtu = wg.MTU;

                if (Global.Settings.V2RayConfig.TCPFastOpen)
                {
                    outbound.streamSettings = new StreamSettings
                    {
                        sockopt = new Sockopt
                        {
                            tcpFastOpen = true
                        }
                    };
                }
                break;

            case SSHServer ssh:
                outbound.protocol = "ssh";
                outbound.settings.address = await server.AutoResolveHostnameAsync();
                outbound.settings.port = server.Port;
                outbound.settings.user = ssh.User;
                outbound.settings.password = ssh.Password;
                outbound.settings.privateKey = ssh.PrivateKey;
                outbound.settings.publicKey = ssh.PublicKey;

                if (Global.Settings.V2RayConfig.TCPFastOpen)
                {
                    outbound.streamSettings = new StreamSettings
                    {
                        sockopt = new Sockopt
                        {
                            tcpFastOpen = true
                        }
                    };
                }
                break;
            case Hysteria2Server hysteria2Server:
                outbound.protocol = "hysteria";
                outbound.settings.address = await hysteria2Server.AutoResolveHostnameAsync();
                outbound.settings.port = hysteria2Server.Port;
                outbound.settings.version = 2;

                outbound.streamSettings = new()
                {
                    network = "hysteria",
                    security = hysteria2Server.tlsConfig.TLSSecureType,
                };
                var hysteria2TlsSettings = new TlsSettings();
                bool useTlsSettings = false;
                if (hysteria2Server.tlsConfig.allowInsecure != null)
                {
                    hysteria2TlsSettings.allowInsecure = (bool)hysteria2Server.tlsConfig.allowInsecure;
                    useTlsSettings = true;
                }
                if (!hysteria2Server.tlsConfig.ServerName.IsNullOrWhiteSpace())
                {
                    hysteria2TlsSettings.serverName = hysteria2Server.tlsConfig.ServerName;
                    useTlsSettings = true;
                }
                if (useTlsSettings)
                {
                    outbound.streamSettings.tlsSettings = hysteria2TlsSettings;
                }

                outbound.streamSettings.hysteriaSettings = new()
                {
                    version = 2,
                    auth = hysteria2Server.Auth,
                };
                if (!hysteria2Server.PortHoppingRange.IsNullOrWhiteSpace())
                {
                    outbound.streamSettings.hysteriaSettings.udphop = new()
                    {
                        ports = hysteria2Server.PortHoppingRange,
                        interval = 30
                    };
                }

                outbound.mux = new Mux()
                {
                    enabled = false,
                };
                break;
        }

        return outbound;
    }

    private static StreamSettings boundStreamSettings(VMessServer server)
    {
        // https://xtls.github.io/config/transports

        var streamSettings = new StreamSettings
        {
            network = server.Transport.TransferProtocol,
            security = server.tlsConfig.TLSSecureType
        };

        if (server.tlsConfig.TLSSecureType != "none")
        {
            var tlsSettings = new TlsSettings
            {
                allowInsecure = server.tlsConfig.allowInsecure != null ? (bool)server.tlsConfig.allowInsecure : Global.Settings.V2RayConfig.AllowInsecure,
                serverName = server.tlsConfig.ServerName.ValueOrDefault() ?? server.Transport.Host.SplitOrDefault()?[0],
                fingerprint = server.tlsConfig.Fingerprint,
                alpn = string.IsNullOrEmpty(server.tlsConfig.Alpn) ? Array.Empty<string>() : server.tlsConfig.Alpn.Split(',')
                     .Select(s => s.Trim()) // 去除首尾空格（比如误写"h2, http/1.1"也能解析）
                     .Where(s => !string.IsNullOrEmpty(s)) // 过滤空值（比如"h2,,http/1.1"会过滤掉空元素）
                     .ToArray(),
                echConfigList = server.tlsConfig.EchConfigList,
                echForceQuery = server.tlsConfig.EchForceQuery,
            }
        ;

            switch (server.tlsConfig.TLSSecureType)
            {
                case "tls":
                    streamSettings.tlsSettings = tlsSettings;
                    break;
                case "xtls":
                    streamSettings.xtlsSettings = tlsSettings;
                    break;
                case "reality":
                    var vlessServer = server as VLESSServer;
                    if (vlessServer != null)
                    {
                        streamSettings.realitySettings = new RealitySettings()
                        {
                            serverName = tlsSettings.serverName,
                            fingerprint = tlsSettings.fingerprint,
                            publicKey = vlessServer.tlsConfig.PublicKey.ValueOrDefault() ?? "",
                            shortId = vlessServer.tlsConfig.ShortId.ValueOrDefault() ?? "",
                            spiderX = vlessServer.tlsConfig.SpiderX.ValueOrDefault() ?? "",
                            mldsa65Verify = vlessServer.tlsConfig.Mldsa65Verify.ValueOrDefault() ?? ""
                        };
                    }
                    break;
            }
        }

        switch (server.Transport.TransferProtocol)
        {
            case "tcp":

                streamSettings.tcpSettings = new TcpSettings
                {
                    header = new
                    {
                        type = server.Transport.FakeType,
                        request = server.Transport.FakeType switch
                        {
                            "none" => null,
                            "http" => new
                            {
                                path = server.Transport.Path.SplitOrDefault(),
                                host = server.Transport.Host.SplitOrDefault(),
                                headers = new Dictionary<string, string>
                                {
                                    ["User-Agent"] = server.tlsConfig.UserAgent,
                                }
                            },
                            _ => throw new MessageException($"Invalid tcp type {server.Transport.FakeType}")
                        }
                    }
                };

                break;
            case "ws":

                streamSettings.wsSettings = new WsSettings
                {
                    path = server.Transport.Path.ValueOrDefault(),
                    host = server.Transport.Host.ValueOrDefault(),
                    headers = new Dictionary<string, string>
                    {
                        ["User-Agent"] = server.tlsConfig.UserAgent,
                    }
                };

                break;
            case "kcp":

                streamSettings.kcpSettings = new KcpSettings
                {
                    mtu = Global.Settings.V2RayConfig.KcpConfig.mtu,
                    tti = Global.Settings.V2RayConfig.KcpConfig.tti,
                    uplinkCapacity = Global.Settings.V2RayConfig.KcpConfig.uplinkCapacity,
                    downlinkCapacity = Global.Settings.V2RayConfig.KcpConfig.downlinkCapacity,
                    congestion = Global.Settings.V2RayConfig.KcpConfig.congestion,
                    readBufferSize = Global.Settings.V2RayConfig.KcpConfig.readBufferSize,
                    writeBufferSize = Global.Settings.V2RayConfig.KcpConfig.writeBufferSize,
                    header = new
                    {
                        type = server.Transport.FakeType
                    },
                    seed = server.Transport.Path.ValueOrDefault()
                };

                break;
            case "h2":

                streamSettings.httpSettings = new HttpSettings
                {
                    host = server.Transport.Host.SplitOrDefault(),
                    path = server.Transport.Path.ValueOrDefault()
                };

                break;
            case "xhttp":
                streamSettings.xhttpSettings = new XhttpSettings
                {
                    host = server.Transport.Host.SplitOrDefault()?[0],
                    path = server.Transport.Path.ValueOrDefault(),
                    xHttpObject = server.Transport.XHttpObject
                };
                break;
            case "quic":

                streamSettings.quicSettings = new QuicSettings
                {
                    security = server.Transport.Host,
                    key = server.Transport.Path,
                    header = new
                    {
                        type = server.Transport.FakeType
                    }
                };

                break;
            case "grpc":

                streamSettings.grpcSettings = new GrpcSettings
                {
                    serviceName = server.Transport.Path,
                    multiMode = server.Transport.FakeType == "multi"
                };

                break;
            default:
                throw new MessageException($"transfer protocol \"{server.Transport.TransferProtocol}\" not implemented yet");
        }

        if (Global.Settings.V2RayConfig.TCPFastOpen)
        {
            streamSettings.sockopt = new Sockopt
            {
                tcpFastOpen = true
            };
        }

        return streamSettings;
    }

    public static string getUUID(string uuid)
    {
        if (uuid.Length == 36 || uuid.Length == 32)
        {
            return uuid;
        }
        return uuid.GenerateUUIDv5();
    }
}