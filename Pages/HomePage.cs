using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

public class HomePage
{
    private readonly IWebDriver _driver;
    private readonly WebDriverWait _wait;
    private readonly Actions _actions;

    public HomePage(IWebDriver driver)
    {
        _driver = driver;
        _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        _actions = new Actions(driver);
    }

    public void Open() => _driver.Navigate().GoToUrl(TestConfig.BaseUrl);

    public void HoverOverModules()
    {
        var modules = _wait.Until(d => d.FindElement(By.LinkText(ElementSelectors.ModulesLinkText)));
        _actions.MoveToElement(modules).Perform();
    }

    public void SelectRepertoireManagementModule()
    {
        var link = _wait.Until(d => d.FindElement(By.PartialLinkText(ElementSelectors.RepertoireModulePartialLinkText)));
        link.Click();
    }
}