#!/bin/bash

echo "MudBlazor Desktop Application Launcher"
echo "======================================"
echo ""

# Check if we're on Windows (Git Bash/WSL) or Unix-like system
if [[ "$OSTYPE" == "msys" || "$OSTYPE" == "cygwin" ]]; then
    echo "Windows environment detected - launching native WinForms app..."
    cd WinFormsHost
    dotnet run
else
    echo "Unix-like environment detected - launching browser-based version..."
    cd WinFormsHost
    dotnet run
fi