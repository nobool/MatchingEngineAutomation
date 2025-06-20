using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

public class WebDriverFactory : IWebDriverFactory
{
    public IWebDriver Create()
    {
        var options = new ChromeOptions();

        if (TestConfig.Headless)
        {
            options.AddArguments(
                "--headless=new", 
                "--disable-gpu",
                "--window-size=1920,1080",
                "--no-sandbox", 
                "--disable-dev-shm-usage"
            );
        }
        else
        {
            // Optional: run maximized in GUI mode
            options.AddArgument("--start-maximized");
        }

        return new ChromeDriver(options);
    }
}