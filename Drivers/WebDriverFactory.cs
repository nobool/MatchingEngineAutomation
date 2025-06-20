using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

public static class WebDriverFactory
{
    public static IWebDriver CreateChromeDriver()
    {
        var options = new ChromeOptions();
        return new ChromeDriver(options);
    }
}