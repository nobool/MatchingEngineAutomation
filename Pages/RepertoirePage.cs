using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Represents the Repertoire Management Module page and its interactions.
/// </summary>
public class RepertoirePage : IRepertoirePage
{
    private readonly IWebDriver _driver;
    private readonly WebDriverWait _wait;

    public RepertoirePage(IWebDriver driver)
    {
        _driver = driver;
        _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
    }
    /// <summary>
    /// Scrolls the page to the 'Additional Features' section.
    /// </summary>
    public void ScrollToAdditionalFeatures()
    {
        var section = _wait.Until(d => d.FindElement(By.XPath(ElementSelectors.AdditionalFeaturesXPath)));
        ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView(true);", section);
    }
    /// <summary>
    /// Clicks on the 'Products Supported' expandable section.
    /// </summary>
    public void OpenProductsSupported()
    {
        var link = _wait.Until(d => d.FindElement(By.XPath(ElementSelectors.ProductsSupportedXPath)));
        link.Click();
    }

    /// <summary>
    /// Extracts the list of supported products listed on the page.
    /// </summary>
   public List<string> GetSupportedProducts()
    {
        // Wait for the heading to be visible
        var heading = _wait.Until(driver =>
        {
            try
            {
                var h = driver.FindElement(By.XPath(ElementSelectors.ProductSupportHeadingXPath));
                return h.Displayed ? h : null;
            }
            catch
            {
                return null;
            }
        });

        // Wait for the list to appear and contain non-empty items
        var items = _wait.Until(driver =>
        {
            try
            {
                var refreshedHeading = driver.FindElement(By.XPath(ElementSelectors.ProductSupportHeadingXPath));
                var ul = refreshedHeading.FindElement(By.XPath(ElementSelectors.ProductListXPath));

                var listItems = ul.FindElements(By.TagName("li"))
                                .Where(li => !string.IsNullOrWhiteSpace(li.Text))
                                .Select(li => li.Text.Trim())
                                .ToList();

                return listItems.Count > 0 ? listItems : null;
            }
            catch
            {
                return null;
            }
        });

        return items;
    }

}