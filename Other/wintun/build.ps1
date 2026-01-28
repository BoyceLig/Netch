# 强制UTF8编码，避免解析错误
[Console]::InputEncoding = [System.Text.Encoding]::UTF8
[Console]::OutputEncoding = [System.Text.Encoding]::UTF8

Set-Location (Split-Path $MyInvocation.MyCommand.Path -Parent)

try {
    Invoke-WebRequest `
        -Uri 'https://www.wintun.net/builds/wintun-0.14.1.zip' `
        -OutFile 'wintun.zip'
}
catch {
    Write-Error "下载失败：$($_.Exception.Message)"
    exit 1
}

try{
    Write-Host "正在解压wintun.zip..."
    # -Force：覆盖已存在的文件/目录；-Path：解压到当前目录的wintun文件夹
    Expand-Archive -Path 'wintun.zip' -DestinationPath 'wintun' -Force
}
catch{
    Write-Error "解压失败：$($_.Exception.Message)"
    exit 1
}

# 检查目标目录是否存在，不存在则创建
$targetDir = Join-Path (Get-Location) "..\release"
if (-not (Test-Path $targetDir)) {
    Write-Host "创建目标目录：$targetDir"
    New-Item -ItemType Directory -Path $targetDir -Force | Out-Null
}

# 移动wintun.dll到目标目录
try {
    Write-Host "移动wintun.dll到release目录..."
    Move-Item -Force 'wintun\wintun\bin\amd64\wintun.dll' '..\release\wintun.dll'
}
catch {
    Write-Error "移动文件失败：$($_.Exception.Message)"
    exit 1
}

# 清理临时文件
Write-Host "清理临时文件..."
if (Test-Path 'wintun') { Remove-Item -Recurse -Force 'wintun' }
if (Test-Path 'wintun.zip') { Remove-Item -Force 'wintun.zip' }

Write-Host "操作完成！wintun.dll已成功复制到release目录"
exit 0