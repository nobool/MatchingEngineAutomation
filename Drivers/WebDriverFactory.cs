using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

public class WebDriverFactory : IWebDriverFactory
{
    public IWebDriver Create()
    {
        var options = new ChromeOptions();

        // Check if running in headless mode (default to false if not set)
        var headless = Environment.GetEnvironmentVariable("HEADLESS")?.ToLower() == "true";

        // if (headless)
        // {
            options.AddArguments(
                "--headless=new", 
                "--disable-gpu",
                "--window-size=1920,1080",
                "--no-sandbox", 
                "--disable-dev-shm-usage"
            );
        // }
        // else
        // {
        //     // Optional: run maximized in GUI mode
        //     options.AddArgument("--start-maximized");
        // }

        return new ChromeDriver(options);
    }
}