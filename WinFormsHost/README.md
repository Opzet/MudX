# MudBlazor Desktop Host

This project provides a desktop wrapper for the MudBlazor web application.

## Features

- **Cross-platform launcher**: Works on Windows, Linux, and macOS
- **Windows WinForms integration**: Native Windows application with WebView2
- **Browser fallback**: Opens in default browser on non-Windows platforms

## Usage

### Quick Start
```bash
./launch-desktop-app.sh
```

### Manual Launch
```bash
cd WinFormsHost
dotnet run
```

## Windows-Specific Features

When running on Windows, the application will:
- Launch as a native WinForms application
- Use WebView2 for embedded web rendering
- Provide a seamless desktop experience

## Cross-Platform Compatibility

On Linux/macOS, the launcher will:
- Start the MudBlazor web application
- Automatically open it in the default browser
- Provide console controls for shutdown

## Development

### Windows Development
To use the full WinForms implementation on Windows:
1. Uncomment the WinForms code in `Program.cs`
2. The project file is already configured for conditional Windows builds

### Project Structure
- `MudBlazorWinFormsHost.csproj`: Cross-platform project configuration
- `Program.cs`: Main application entry point with platform detection
- Contains complete WinForms + WebView2 implementation in comments

## Dependencies

- **.NET 8.0**: Required runtime
- **Microsoft.Web.WebView2**: Automatically included on Windows builds
- **System browser**: Required on non-Windows platforms

## Configuration

The application connects to the MudBlazor app at:
- URL: `https://localhost:5001`
- Auto-start: Yes (launches the web app automatically)
- Shutdown: Automatic when desktop app is closed