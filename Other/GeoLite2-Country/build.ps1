# 强制UTF8编码，避免解析错误
[Console]::InputEncoding = [System.Text.Encoding]::UTF8
[Console]::OutputEncoding = [System.Text.Encoding]::UTF8

Set-Location (Split-Path $MyInvocation.MyCommand.Path -Parent)

try {
    Invoke-WebRequest `
        -Uri 'https://raw.githubusercontent.com/Loyalsoldier/geoip/release/GeoLite2-Country.mmdb' `
        -OutFile 'GeoLite2-Country.mmdb'
}
catch {
    Write-Error "下载失败：$($_.Exception.Message)"
    exit 1
}

# 检查目标目录是否存在，不存在则创建
$targetDir = Join-Path (Get-Location) "..\release"
if (-not (Test-Path $targetDir)) {
    Write-Host "创建目标目录：$targetDir"
    New-Item -ItemType Directory -Path $targetDir -Force | Out-Null
}

# 移动GeoLite2-Country.mmdb到目标目录
try {
    Write-Host "移动GeoLite2-Country.mmdb到release目录..."
    Move-Item -Force 'GeoLite2-Country.mmdb' '..\release\GeoLite2-Country.mmdb'
}
catch {
    Write-Error "移动文件失败：$($_.Exception.Message)"
    exit 1
}

# 清理临时文件
Write-Host "清理临时文件..."
if (Test-Path 'GeoLite2-Country.mmdb') { Remove-Item -Force 'GeoLite2-Country.mmdb' }

Write-Host "操作完成！GeoLite2-Country.mmdb已成功复制到release目录"
exit 0