# PDFUnlockingApp

A simple .NET console application to unlock password-protected PDF files.

## 🔧 Features

- Unlock password-protected PDFs
- Outputs an unprotected copy of the original file
- Lightweight and easy to use

## 📦 Requirements

- .NET 6 or later
- [iTextSharp](https://github.com/itext/itextsharp) PDF library (or your preferred PDF handling library)

## 🚀 Getting Started

1. **Clone the repository**

```bash
git clone https://github.com/your-username/PDFUnlockingApp.git
cd PDFUnlockingApp
```

2. **Restore dependencies**

```bash
dotnet restore
```

3. **Build the app**

```bash
dotnet build
```

4. **Run the app**

```bash
dotnet run
```

## 📂 Project Structure

```
PDFUnlockingApp/
│
├── Program.cs              # Main entry point
├── Services/
│   └── PdfUnlockService.cs # Handles unlocking logic
├── Models/
│   └── PdfUnlockRequest.cs # Input model (if needed)
├── .gitignore
├── README.md
└── PDFUnlockingApp.csproj
```

## 📝 Usage

Update the input file path, output file path, and password in the code or through command-line arguments.

