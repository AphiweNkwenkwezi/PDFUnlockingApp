using System;

class Program
{
    static void Main()
    {
        var request = new PdfUnlockRequest
        {
            InputPath = @"C:\path\to\secured.pdf",
            OutputPath = @"C:\path\to\unlocked.pdf",
            Password = "your_password"
        };

        IPdfUnlocker unlocker = new ITextSharpPdfUnlocker();

        try
        {
            unlocker.Unlock(request);
            Console.WriteLine("PDF unlocked successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Failed to unlock PDF: {ex.Message}");
        }
    }
}
