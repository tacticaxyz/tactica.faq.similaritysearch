# TacTicA.FaqSimilaritySearchBot Build and Deploy Script
param(
    [Parameter(Position=0)]
    [ValidateSet("build", "train", "serve", "deploy", "clean")]
    [string]$Action = "build",
    
    [switch]$SkipTraining,
    [switch]$OpenBrowser,
    [int]$Port = 8080
)

$ErrorActionPreference = "Stop"

Write-Host "TacTicA.FaqSimilaritySearchBot Build Script" -ForegroundColor Blue
Write-Host "=============================" -ForegroundColor Blue

$RootPath = $PSScriptRoot
$SrcPath = Join-Path $RootPath "src"
$TrainingPath = Join-Path $SrcPath "TacTicA.FaqSimilaritySearchBot.Training"
$WebPath = Join-Path $SrcPath "TacTicA.FaqSimilaritySearchBot.WebOnnx"
$DataPath = Join-Path $RootPath "data"
$WwwRootPath = Join-Path $RootPath "wwwroot"

function Test-Prerequisites {
    Write-Host "Checking prerequisites..." -ForegroundColor Yellow
    
    # Check .NET 9
    try {
        $dotnetVersion = dotnet --version
        Write-Host "✓ .NET version: $dotnetVersion" -ForegroundColor Green
    }
    catch {
        Write-Error ".NET 9.0 SDK is required. Please install from https://dotnet.microsoft.com/download"
    }
    
    # Check if Python is available (optional for advanced embeddings)
    try {
        $pythonVersion = python --version 2>$null
        if ($pythonVersion) {
            Write-Host "✓ Python available: $pythonVersion" -ForegroundColor Green
        }
    }
    catch {
        Write-Host "⚠ Python not found (optional for advanced embeddings)" -ForegroundColor Yellow
    }
}

function Build-Solution {
    Write-Host "Building solution..." -ForegroundColor Yellow
    
    Push-Location $RootPath
    try {
        dotnet restore
        dotnet build --configuration Release
        Write-Host "✓ Build completed successfully" -ForegroundColor Green
    }
    finally {
        Pop-Location
    }
}

function Start-Training {
    Write-Host "Starting training process..." -ForegroundColor Yellow
    
    # Ensure data directory exists
    if (-not (Test-Path $DataPath)) {
        New-Item -ItemType Directory -Path $DataPath -Force | Out-Null
    }
    
    # Ensure wwwroot directory exists
    if (-not (Test-Path $WwwRootPath)) {
        New-Item -ItemType Directory -Path $WwwRootPath -Force | Out-Null
    }
    
    Push-Location $TrainingPath
    try {
        dotnet run --configuration Release
        Write-Host "✓ Training completed successfully" -ForegroundColor Green
    }
    finally {
        Pop-Location
    }
}

function Start-WebServer {
    Write-Host "Starting local web server on port $Port..." -ForegroundColor Yellow
    
    # Check if Python is available for simple HTTP server
    try {
        python --version | Out-Null
        Push-Location $RootPath
        
        Write-Host "Web server running at: http://localhost:$Port" -ForegroundColor Green
        Write-Host "Press Ctrl+C to stop the server" -ForegroundColor Yellow
        
        if ($OpenBrowser) {
            Start-Process "http://localhost:$Port"
        }
        
        # Start Python HTTP server
        python -m http.server $Port --bind 127.0.0.1 --directory .
    }
    catch {
        Write-Host "Python not available. Please install Python or use a different web server." -ForegroundColor Red
        Write-Host "Alternative: Use VS Code Live Server extension or any other HTTP server" -ForegroundColor Yellow
        
        # Provide alternative instructions
        Write-Host "`nAlternative serving options:" -ForegroundColor Yellow
        Write-Host "1. Install Python: https://python.org/downloads" -ForegroundColor White
        Write-Host "2. Use VS Code with Live Server extension" -ForegroundColor White
        Write-Host "3. Use Node.js: npx serve ." -ForegroundColor White
        Write-Host "4. Use any other HTTP server pointing to: $RootPath" -ForegroundColor White
    }
    finally {
        if (Get-Location | Where-Object { $_.Path -eq $RootPath }) {
            Pop-Location -ErrorAction SilentlyContinue
        }
    }
}

function Clean-Build {
    Write-Host "Cleaning build artifacts..." -ForegroundColor Yellow
    
    $CleanPaths = @(
        (Join-Path $RootPath "bin"),
        (Join-Path $RootPath "obj"),
        (Join-Path $SrcPath "**\bin"),
        (Join-Path $SrcPath "**\obj"),
        $WwwRootPath
    )
    
    foreach ($path in $CleanPaths) {
        if (Test-Path $path) {
            Remove-Item $path -Recurse -Force
            Write-Host "✓ Cleaned $path" -ForegroundColor Green
        }
    }
}

# Main execution
switch ($Action) {
    "build" {
        Test-Prerequisites
        Build-Solution
        
        if (-not $SkipTraining) {
            Start-Training
        }
        
        Write-Host "`nBuild completed! Use 'serve' action to start the web server." -ForegroundColor Green
    }
    
    "train" {
        Test-Prerequisites
        Start-Training
    }
    
    "serve" {
        Start-WebServer
    }
    
    "clean" {
        Clean-Build
    }
    
    default {
        Write-Host "Usage: .\build.ps1 [build|train|serve|deploy|clean] [options]" -ForegroundColor Yellow
        Write-Host "`nActions:" -ForegroundColor Yellow
        Write-Host "  build   - Build and train the solution (default)" -ForegroundColor White
        Write-Host "  train   - Run training process only" -ForegroundColor White
        Write-Host "  serve   - Start local web server" -ForegroundColor White
        Write-Host "  clean   - Clean build artifacts" -ForegroundColor White
        Write-Host "`nOptions:" -ForegroundColor Yellow
        Write-Host "  -SkipTraining  - Skip the training step during build" -ForegroundColor White
        Write-Host "  -OpenBrowser   - Open browser when serving" -ForegroundColor White
        Write-Host "  -Port <number> - Port for web server (default: 8080)" -ForegroundColor White
    }
}
