# Matching Engine Automation

This project automates the verification of supported products on the [Matching Engine](https://www.matchingengine.com/) website using **Selenium WebDriver** in **C#**.

---

## 🧪 What the Test Does

1. Launches Google Chrome
2. Navigates to the Matching Engine homepage
3. Expands the **Modules** menu
4. Clicks on **Repertoire Management Module**
5. Scrolls to the **Additional Features** section
6. Clicks on **Products Supported**
7. Asserts that the displayed product list includes:
   - Cue Sheet / AV Work
   - Recording
   - Bundle
   - Advertisement

---

## 🧱 Project Structure

```plaintext
MatchingEngineAutomation/
├── Drivers/
│   └── WebDriverFactory.cs
├── Interfaces/
│   ├── IHomePage.cs
│   ├── IRepertoirePage.cs
│   └── IWebDriverFactory.cs
├── Pages/
│   ├── HomePage.cs
│   └── RepertoirePage.cs
├── Utilities/
│   ├── ElementSelectors.cs
│   ├── ProductList.cs
│   └── TestConfig.cs
├── Tests/
│   └── MatchingEngineTests.cs
├── MatchingEngineAutomation.csproj
```

---

## 🛠 Prerequisites

- [.NET SDK 6.0+](https://dotnet.microsoft.com/download)
- [Google Chrome](https://www.google.com/chrome/)
- ChromeDriver (automatically managed by `Selenium.WebDriver.ChromeDriver`)

---

## 📦 Dependencies

Installed via NuGet:

```bash
dotnet add package Selenium.WebDriver
dotnet add package Selenium.WebDriver.ChromeDriver
dotnet add package Selenium.Support
dotnet add package NUnit
dotnet add package NUnit3TestAdapter
dotnet add package Microsoft.NET.Test.Sdk
```

---

## 🚀 Running the Tests

1. Restore dependencies:
   ```bash
   dotnet restore
   ```

2. Run the test suite:
   ```bash
   dotnet test
   ```

3. To run in Headless mode

   On Windows based devices - CMD
   ```cmd
   set HEADLESS=true
   dotnet test
   ```

   On Windows based devices - Powershell
   ```powershell
   $env:HEADLESS = "true"
   dotnet test
   ```

   On Linux based devices
   ```bash
   export HEADLESS=true
   dotnet test
   ```

---

## ⚙️ Configuration

The base URL is defined in:

```csharp
TestConfig.BaseUrl = "https://www.matchingengine.com/";
```

All XPath selectors are defined in `ElementSelectors.cs`.

The expected product list is maintained in `ProductList.cs`.

---