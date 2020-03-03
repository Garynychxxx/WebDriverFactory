if(!(Test-Path $PWD/cm.exe)){

if ($env:PROCESSOR_ARCHITECTURE -eq "AMD64") {
    $platform = "windows_amd64"
}
else {
    $platform = "windows_386"
}


$json = (Invoke-WebRequest -UseBasicParsing "https://api.github.com/repos/aerokube/cm/releases/latest").Content | ConvertFrom-Json

ForEach ($asset in $json.assets) {
    $url = $asset.browser_download_url
    if ($url -match $platform) {
        $latest_binary_url = $url
    }
}

if ([string]::IsNullOrEmpty($latest_binary_url)) {
    Write-Error "Сan't find URL for latest release!"
}

Invoke-WebRequest -Uri $latest_binary_url -OutFile ".\cm.exe"

Write-Host -ForegroundColor Green "
SUCCESSFULLY DOWNLOADED!
"
}


Write-Host -NoNewline "
Now you can run "
Write-Host -NoNewline -ForegroundColor Cyan "Selenoid"
Write-Host -NoNewline " with "
Write-Host -NoNewline -ForegroundColor Cyan "cm"
Write-Host ":"
Write-Host -ForegroundColor Cyan "   
 ./cm selenoid start --vnc"
Write-Host "
To get instant help just type:
"
Write-Host -ForegroundColor Cyan "    ./cm --help
"




$current = $PWD -replace "\\", "/" 
./cm selenoid start --vnc -g "-limit 10" -j ./browsers.json  -c $current  --force
