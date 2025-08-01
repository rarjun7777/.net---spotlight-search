# AI Search Application Launcher
Write-Host "Starting AI Search Application..." -ForegroundColor Green
Write-Host ""
Write-Host "Features:" -ForegroundColor Yellow
Write-Host "- Press Ctrl+Space to open search from anywhere" -ForegroundColor White
Write-Host "- System tray integration" -ForegroundColor White
Write-Host "- Gemini web search integration" -ForegroundColor White
Write-Host ""
Write-Host "The application will start in the system tray." -ForegroundColor Cyan
Write-Host "Look for the icon in the notification area." -ForegroundColor Cyan
Write-Host ""

try {
    # Check if .NET 8.0 is installed
    $dotnetVersion = dotnet --version
    Write-Host "Using .NET version: $dotnetVersion" -ForegroundColor Gray
    
    # Build and run the application
    dotnet build --no-restore
    if ($LASTEXITCODE -eq 0) {
        Write-Host "Build successful. Starting application..." -ForegroundColor Green
        dotnet run
    } else {
        Write-Host "Build failed. Please check the errors above." -ForegroundColor Red
    }
} catch {
    Write-Host "Error: $_" -ForegroundColor Red
    Write-Host "Please ensure .NET 8.0 SDK is installed." -ForegroundColor Yellow
}

Write-Host ""
Write-Host "Press any key to exit..." -ForegroundColor Gray
$null = $Host.UI.RawUI.ReadKey("NoEcho,IncludeKeyDown") 