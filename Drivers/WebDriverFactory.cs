using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

public class WebDriverFactory : IWebDriverFactory
{
    public IWebDriver Create()
    {
        var options = new ChromeOptions();

        // Check if running in headless mode (default to false if not set)
        var headless = Environment.GetEnvironmentVariable("HEADLESS")?.ToLower() == "true";

        if (headless)
        {
            options.AddArguments(
                "--headless=new", 
                "--disable-gpu", 
                "--no-sandbox", 
                "--disable-dev-shm-usage"
            );
        }

        return new ChromeDriver(options);
    }
}