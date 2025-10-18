# MudBlazor Application

A modern Blazor Server application using MudBlazor components for rich, interactive UI experiences.

## 🚀 Features

- **MudBlazor Components**: Material Design components for Blazor
- **Real-time Updates**: Blazor Server with SignalR connection
- **Desktop Integration**: Cross-platform desktop wrapper included
- **Responsive Design**: Mobile-friendly layout and components

## 📋 Prerequisites

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- Modern web browser
- For desktop app: Windows (WinForms + WebView2) or any OS (browser mode)

## 🏃‍♂️ Quick Start

### Web Application
```bash
dotnet run
```
Then navigate to `https://localhost:5001`

### Desktop Application
```bash
./launch-desktop-app.sh
```

## 🏗️ Project Structure

```
├── Components/
│   ├── Layout/          # Application layout components
│   ├── Pages/           # Page components and routes
│   └── _Imports.razor   # Global using statements
├── WinFormsHost/        # Desktop application wrapper
├── wwwroot/             # Static web assets
├── Program.cs           # Application entry point
└── appsettings.json     # Application configuration
```

## 🎨 MudBlazor Integration

The application is configured with:
- MudBlazor services in `Program.cs`
- Material Design CSS and JavaScript
- MudBlazor namespace in `_Imports.razor`
- Sample components demonstrating MudBlazor usage

### Key Components Used
- `MudThemeProvider`: Theme management
- `MudDialogProvider`: Modal dialogs
- `MudSnackbarProvider`: Toast notifications
- `MudButton`, `MudTextField`, `MudCard`: UI components

## 🖥️ Desktop Application

The included desktop wrapper provides:
- **Windows**: Native WinForms app with WebView2 integration
- **Cross-platform**: Browser-based launcher for Linux/macOS
- **Auto-start**: Automatically launches the web application
- **Integrated shutdown**: Closes web app when desktop app exits

### Desktop Usage
See `WinFormsHost/README.md` for detailed desktop application documentation.

## 🔧 Development

### Running in Development
```bash
dotnet watch run
```

### Building for Production
```bash
dotnet build -c Release
dotnet publish -c Release
```

### Adding New Pages
1. Create a new `.razor` file in `Components/Pages/`
2. Add `@page "/route"` directive
3. Use MudBlazor components for UI elements

### Customizing Theme
Modify the MudBlazor theme in `Components/Layout/MainLayout.razor`:
```razor
<MudThemeProvider Theme="@customTheme" />
```

## 📦 Dependencies

- **MudBlazor**: Material Design component library
- **Microsoft.AspNetCore.Components**: Blazor framework
- **Microsoft.Web.WebView2**: Desktop WebView (Windows only)

## 🚀 Deployment

### Web Deployment
Deploy as a standard ASP.NET Core application to:
- Azure App Service
- IIS
- Docker containers
- Linux servers

### Desktop Distribution
For Windows desktop deployment:
1. Build the WinFormsHost project on Windows
2. Include the WebView2 runtime
3. Package with an installer (optional)

## 🤝 Contributing

1. Fork the repository
2. Create a feature branch
3. Make changes using MudBlazor components
4. Test both web and desktop versions
5. Submit a pull request

## 📄 License

This project is licensed under the MIT License.

## 🆘 Support

- MudBlazor Documentation: https://mudblazor.com/
- Blazor Documentation: https://docs.microsoft.com/aspnet/core/blazor
- Issues: Create an issue in this repository