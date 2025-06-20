using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

public class WebDriverFactory : IWebDriverFactory
{
    public IWebDriver Create()
    {
        var options = new ChromeOptions();
        return new ChromeDriver(options);
    }
}