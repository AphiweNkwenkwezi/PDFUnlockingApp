using iTextSharp.text.pdf;
using System.IO;
using System.Reflection.PortableExecutable;
using System.Text;

public class ITextSharpPdfUnlocker : IPdfUnlocker
{
    public void Unlock(PdfUnlockRequest request)
    {
        if (!File.Exists(request.InputPath))
            throw new FileNotFoundException("Input PDF not found.", request.InputPath);

        using var reader = new PdfReader(request.InputPath, Encoding.ASCII.GetBytes(request.Password));
        using var outputStream = new FileStream(request.OutputPath, FileMode.Create, FileAccess.Write);
        using var stamper = new PdfStamper(reader, outputStream);

        // Close ensures the changes are written
        stamper.Close();
    }
}
