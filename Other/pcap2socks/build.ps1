Set-Location (Split-Path $MyInvocation.MyCommand.Path -Parent)

try {
    Invoke-WebRequest `
        -Uri 'https://github.com/zhxie/pcap2socks/releases/download/v0.6.2/pcap2socks-v0.6.2-windows-amd64.zip' `
        -OutFile 'pcap2socks.zip'
    Expand-Archive -Force -Path pcap2socks.zip -DestinationPath pcap2socks
    
    mv -Force 'pcap2socks\pcap2socks.exe' '..\release\pcap2socks.exe'
}
catch {
    exit 1
}
finally {
    # 清理临时文件：包括下载的zip包 + 临时解压目录
    if (Test-Path 'pcap2socks.zip') {
        Remove-Item -Path 'pcap2socks.zip' -Force
        Write-Host "Temporary file pcap2socks.zip cleaned up"
    }
    if (Test-Path 'pcap2socks') {
        Remove-Item -Path 'pcap2socks' -Recurse -Force
        Write-Host "Temporary unzip directory pcap2socks cleaned up"
    }
}

exit 0