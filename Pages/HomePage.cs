using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;


/// <summary>
/// Represents actions on the home page of the Matching Engine website.
/// </summary>
public class HomePage : IHomePage
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

    /// <summary>
    /// Navigates to the Matching Engine homepage.
    /// </summary>
    public void Open()
    { 
        _driver.Navigate().GoToUrl(TestConfig.BaseUrl);
        _wait.Until(d =>((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete"));
    }

    /// <summary>
    /// Hovers over the 'Modules' menu in the header.
    /// </summary>
    public void HoverOverModules()
    {
        var modules = _wait.Until(driver => driver.FindElement(By.LinkText(ElementSelectors.ModulesLinkText)));
        _actions.MoveToElement(modules).Perform();
    }

    /// <summary>
    /// Clicks on the 'Repertoire Management Module' item.
    /// </summary>
    public void SelectRepertoireManagementModule()
    {
        var link = _wait.Until(driver => driver.FindElement(By.PartialLinkText(ElementSelectors.RepertoireModulePartialLinkText)));
        link.Click();
    }
}