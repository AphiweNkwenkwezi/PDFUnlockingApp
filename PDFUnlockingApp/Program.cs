using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

class Program
{
    static void Main()
    {
        var serviceProvider = new ServiceCollection()
            .AddLogging(configure => configure.AddConsole())
            .AddSingleton<PdfUnlockService>()
            .BuildServiceProvider();

        var logger = serviceProvider.GetRequiredService<ILogger<Program>>();
        logger.LogInformation("PDF Unlocking App started.");

        var request = new PdfUnlockRequest
        {
            InputPath = @"C:\path\to\secured.pdf",
            OutputPath = @"C:\path\to\unlocked.pdf",
            Password = "your_password"
        };

        var unlockService = serviceProvider.GetRequiredService<PdfUnlockService>();

        try
        {
            unlockService.Unlock(request);
            logger.LogInformation("PDF unlocked successfully.");
        }
        catch (Exception ex)
        {
            logger.LogError($"Failed to unlock PDF: {ex.Message}");
        }
    }
}
