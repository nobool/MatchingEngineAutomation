// Pages/RepertoirePage.cs
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

public class RepertoirePage
{
    private readonly IWebDriver _driver;
    private readonly WebDriverWait _wait;

    public RepertoirePage(IWebDriver driver)
    {
        _driver = driver;
        _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
    }

    public void ScrollToAdditionalFeatures()
    {
        var section = _wait.Until(d => d.FindElement(By.XPath("//*[contains(text(), 'Additional Features')]")));
        ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView(true);", section);
    }

    public void OpenProductsSupported()
    {
        var link = _wait.Until(d => d.FindElement(By.XPath("//*[text()='Products Supported']")));
        link.Click();
    }

    public List<string> GetSupportedProducts()
{
    return _wait.Until(d =>
    {
        try
        {
            var heading = d.FindElement(By.XPath("//*[contains(text(), 'There are several types of Product Supported:')]"));

            var ul = heading.FindElement(By.XPath("./following-sibling::*[descendant-or-self::ul][1]//ul[1]"));

            var items = ul.FindElements(By.TagName("li"))
                          .Where(li => !string.IsNullOrWhiteSpace(li.Text))
                          .Select(li => li.Text.Trim())
                          .ToList();

            return items.Count > 0 ? items : null;
        }
        catch (Exception ex)
        {
            return null;
        }
    });
}
}