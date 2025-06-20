using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;

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
        var section = _wait.Until(d => d.FindElement(By.XPath(ElementSelectors.AdditionalFeaturesXPath)));
        ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView(true);", section);
    }

    public void OpenProductsSupported()
    {
        var link = _wait.Until(d => d.FindElement(By.XPath(ElementSelectors.ProductsSupportedXPath)));
        link.Click();
    }

    public List<string> GetSupportedProducts()
    {
        return _wait.Until(d =>
        {
            try
            {
                var heading = d.FindElement(By.XPath(ElementSelectors.ProductSupportHeadingXPath));
                Console.WriteLine("DEBUG: Found heading text.");

                var ul = heading.FindElement(By.XPath(ElementSelectors.ProductListXPath));
                Console.WriteLine("DEBUG: Found nested <ul> list.");

                var items = ul.FindElements(By.TagName("li"))
                              .Where(li => !string.IsNullOrWhiteSpace(li.Text))
                              .Select(li => li.Text.Trim())
                              .ToList();

                Console.WriteLine($"DEBUG: Found {items.Count} non-empty <li> elements.");
                return items.Count > 0 ? items : null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"DEBUG: Exception while retrieving list: {ex.Message}");
                return null;
            }
        });
    }
}