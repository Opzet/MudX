# C# MudBlazor Project Instructions

This is a Blazor Server application using MudBlazor components for modern UI design, with an optional desktop wrapper.

## Architecture
- **Blazor Server**: Real-time UI updates via SignalR connection
- **MudBlazor**: Material Design component library for Blazor
- **Dependency Injection**: Services registered in `Program.cs`
- **Razor Components**: Located in `Components/` directory
- **Desktop Integration**: WinForms + WebView2 wrapper in `WinFormsHost/`

## Key Files
- `Program.cs`: Application entry point and service configuration
- `Components/App.razor`: Root component with routing and MudBlazor CSS/JS
- `Components/Layout/MainLayout.razor`: Main application layout with MudBlazor providers
- `Components/Pages/`: Page components and routes
- `WinFormsHost/`: Desktop application wrapper with cross-platform launcher

## Development Patterns
- Use MudBlazor components (`MudButton`, `MudTextField`, `MudCard`, etc.) instead of HTML elements
- Follow Blazor naming conventions: PascalCase for components and parameters
- Use `@page` directive for routable components
- Implement `IDisposable` for components with event subscriptions
- Import MudBlazor namespace in `_Imports.razor` for all components

## Running the Project
- **Web Development**: `dotnet watch run` (auto-reload on changes)
- **Web Production**: `dotnet run` or `dotnet publish -c Release`
- **Desktop Mode**: `./launch-desktop-app.sh` (cross-platform launcher)
- **Build Only**: `dotnet build`

## MudBlazor Specifics
- Theme and providers configured in `MainLayout.razor`
- MudBlazor services registered in `Program.cs` with `AddMudServices()`
- CSS and JS references in `App.razor` head section
- Use `MudThemeProvider`, `MudDialogProvider`, `MudSnackbarProvider` for core functionality
- Access theme colors and breakpoints via MudBlazor's built-in classes

## Desktop Application
- Located in `WinFormsHost/` directory
- Cross-platform launcher script: `launch-desktop-app.sh`
- Windows: Native WinForms with WebView2 integration
- Linux/macOS: Browser-based with auto-launch
- Automatically starts and stops the web application