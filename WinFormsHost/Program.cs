using System.Diagnostics;
using System.Runtime.InteropServices;

namespace MudBlazorWinFormsHost
{
    internal class Program
    {
        private static Process? browserProcess;
        private static Process? blazorProcess;
        
        static async Task Main(string[] args)
        {
            Console.WriteLine("🚀 MudBlazor Desktop Application Launcher");
            Console.WriteLine("=========================================");
            Console.WriteLine();
            
            // Start the Blazor web application
            await StartBlazorApp();
            
            // Wait for it to initialize
            Console.WriteLine("⏳ Waiting for application to start...");
            await Task.Delay(4000);
            
            // Open in browser
            OpenBrowser("https://localhost:5001");
            
            Console.WriteLine("✅ Application started successfully!");
            Console.WriteLine("🌐 MudBlazor app: https://localhost:5001");
            Console.WriteLine();
            Console.WriteLine("📋 Available Commands:");
            Console.WriteLine("  'o' or 'open'    - Open in browser");
            Console.WriteLine("  'r' or 'restart' - Restart browser");
            Console.WriteLine("  'l' or 'logs'    - Show application logs");
            Console.WriteLine("  'q' or 'quit'    - Quit application");
            Console.WriteLine("  'h' or 'help'    - Show this help");
            Console.WriteLine();
            
            // Handle user input
            await HandleUserInput();
            
            // Cleanup
            await Cleanup();
        }
        
        private static async Task StartBlazorApp()
        {
            try
            {
                Console.WriteLine("🔧 Starting MudBlazor web application...");
                
                var startInfo = new ProcessStartInfo
                {
                    FileName = "dotnet",
                    Arguments = "run --project ../source.csproj --urls https://localhost:5001",
                    UseShellExecute = false,
                    CreateNoWindow = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true
                };

                blazorProcess = Process.Start(startInfo);
                
                if (blazorProcess != null)
                {
                    Console.WriteLine("✅ Blazor process started (PID: " + blazorProcess.Id + ")");
                    
                    // Monitor output for startup confirmation
                    _ = Task.Run(() => MonitorBlazorOutput());
                }
                else
                {
                    Console.WriteLine("❌ Failed to start Blazor process");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Failed to start Blazor application: {ex.Message}");
                Console.WriteLine("💡 Please ensure .NET 8.0 SDK is installed");
                Console.WriteLine("� Run 'dotnet --version' to check your .NET installation");
            }
        }
        
        private static async Task MonitorBlazorOutput()
        {
            if (blazorProcess?.StandardOutput != null)
            {
                while (!blazorProcess.StandardOutput.EndOfStream)
                {
                    var line = await blazorProcess.StandardOutput.ReadLineAsync();
                    if (!string.IsNullOrEmpty(line))
                    {
                        // Show important startup messages
                        if (line.Contains("Now listening on") || 
                            line.Contains("Application started") ||
                            line.Contains("Hosting environment"))
                        {
                            Console.WriteLine($"📄 {line}");
                        }
                    }
                }
            }
        }
        
        private static void OpenBrowser(string url)
        {
            try
            {
                ProcessStartInfo startInfo;
                
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    startInfo = new ProcessStartInfo("cmd", $"/c start {url}") { CreateNoWindow = true };
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                {
                    startInfo = new ProcessStartInfo("xdg-open", url);
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                {
                    startInfo = new ProcessStartInfo("open", url);
                }
                else
                {
                    Console.WriteLine($"📋 Please manually open: {url}");
                    return;
                }
                
                browserProcess = Process.Start(startInfo);
                Console.WriteLine($"🌐 Browser opened: {url}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"⚠️  Could not open browser automatically: {ex.Message}");
                Console.WriteLine($"📋 Please manually navigate to: {url}");
            }
        }
        
        private static async Task HandleUserInput()
        {
            while (true)
            {
                Console.Write("mudblazor> ");
                var input = Console.ReadLine()?.ToLower().Trim();
                
                switch (input)
                {
                    case "o":
                    case "open":
                        OpenBrowser("https://localhost:5001");
                        break;
                        
                    case "r":
                    case "restart":
                        Console.WriteLine("🔄 Restarting browser...");
                        try
                        {
                            browserProcess?.Kill();
                            browserProcess?.Dispose();
                        }
                        catch { }
                        await Task.Delay(500);
                        OpenBrowser("https://localhost:5001");
                        break;
                        
                    case "l":
                    case "logs":
                        Console.WriteLine("📄 Application Status:");
                        if (blazorProcess != null && !blazorProcess.HasExited)
                        {
                            Console.WriteLine($"  ✅ Blazor app running (PID: {blazorProcess.Id})");
                            Console.WriteLine($"  🌐 URL: https://localhost:5001");
                            Console.WriteLine($"  ⏱️  Runtime: {DateTime.Now - blazorProcess.StartTime:hh\\:mm\\:ss}");
                        }
                        else
                        {
                            Console.WriteLine("  ❌ Blazor app not running");
                        }
                        break;
                        
                    case "q":
                    case "quit":
                    case "exit":
                        Console.WriteLine("👋 Shutting down...");
                        return;
                        
                    case "h":
                    case "help":
                        Console.WriteLine("📋 Available Commands:");
                        Console.WriteLine("  'o' or 'open'    - Open in browser");
                        Console.WriteLine("  'r' or 'restart' - Restart browser");
                        Console.WriteLine("  'l' or 'logs'    - Show application logs");
                        Console.WriteLine("  'q' or 'quit'    - Quit application");
                        Console.WriteLine("  'h' or 'help'    - Show this help");
                        break;
                        
                    case "":
                        // Empty input, do nothing
                        break;
                        
                    default:
                        Console.WriteLine("❓ Unknown command. Type 'h' for help.");
                        break;
                }
            }
        }
        
        private static async Task Cleanup()
        {
            Console.WriteLine("🧹 Cleaning up...");
            
            try
            {
                browserProcess?.Kill();
                browserProcess?.Dispose();
            }
            catch { }
            
            try
            {
                if (blazorProcess != null && !blazorProcess.HasExited)
                {
                    Console.WriteLine("🔄 Stopping Blazor application...");
                    blazorProcess.Kill();
                    blazorProcess.WaitForExit(5000);
                    blazorProcess.Dispose();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"⚠️  Error stopping Blazor process: {ex.Message}");
            }
            
            Console.WriteLine("✅ Cleanup completed");
        }
    }
}
