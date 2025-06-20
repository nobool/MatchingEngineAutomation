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
        return _wait.Until(d =>
        {
            try
            {
                var heading = d.FindElement(By.XPath(ElementSelectors.ProductSupportHeadingXPath));

                var ul = heading.FindElement(By.XPath(ElementSelectors.ProductListXPath));

                var previous = new List<string>();
                int stableCount = 0;

                for (int i = 0; i < 10; i++) // Try for ~5 seconds (10 x 500ms)
                {
                    var items = ul.FindElements(By.TagName("li"))
                                .Where(li => !string.IsNullOrWhiteSpace(li.Text))
                                .Select(li => li.Text.Trim())
                                .ToList();

                    if (items.SequenceEqual(previous))
                    {
                        stableCount++;
                        if (stableCount >= 2) // Same list for 2 iterations (1 second)
                            return items;
                    }
                    else
                    {
                        stableCount = 0;
                        previous = items;
                    }

                    Thread.Sleep(500);
                }

                return previous.Count > 0 ? previous : null;

                // var items = ul.FindElements(By.TagName("li"))
                //               .Where(li => !string.IsNullOrWhiteSpace(li.Text))
                //               .Select(li => li.Text.Trim())
                //               .ToList();

                // return items.Count > 0 ? items : null;
            }
            catch (Exception ex)
            {
                return null;
            }
        });
    }
}