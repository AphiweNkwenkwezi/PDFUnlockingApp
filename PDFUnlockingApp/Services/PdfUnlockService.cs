using iTextSharp.text.pdf;
using Microsoft.Extensions.Logging;
using System.Text;

public class PdfUnlockService : IPdfUnlocker
{
    private readonly ILogger<PdfUnlockService> _logger;

    public PdfUnlockService(ILogger<PdfUnlockService> logger)
    {
        _logger = logger;
    }

    public void Unlock(PdfUnlockRequest request)
    {
        string inputPath = request.InputPath;
        _logger.LogInformation($"Attempting to unlock PDF at {inputPath}");

        try
        {
            if (!File.Exists(inputPath))
            {
                _logger.LogError($"Input PDF not found: {inputPath}");
                return;
            }
        }
        catch (Exception ex)
        {
            _logger.LogError($"Failed to unlock PDF with error {ex}");
        }

        PdfReader reader = null;
        FileStream outputStream = null;
        PdfStamper stamper = null;

        try
        {
            reader = new PdfReader(request.InputPath, Encoding.ASCII.GetBytes(request.Password));
            outputStream = new FileStream(request.OutputPath, FileMode.Create, FileAccess.Write);
            stamper = new PdfStamper(reader, outputStream);

            _logger.LogInformation($"PDF unlocked successfully. Output written to '{request.OutputPath}'");
        }
        catch (Exception ex)
        {
            _logger.LogError($"An error occurred while unlocking the PDF: {ex.Message}", ex);
        }
        finally
        {
            stamper?.Close();
            outputStream?.Close();
            reader?.Close();
        }
    }
}
