using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        ChromeOptions options = new ChromeOptions();
        using IWebDriver driver = new ChromeDriver(options);
        {
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.matchingengine.com/");

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            // Hover over 'Modules'
            IWebElement modulesButton = wait.Until(driver =>
                driver.FindElements(By.LinkText("Modules")).FirstOrDefault());

            if (modulesButton != null)
            {
                Actions action = new Actions(driver);
                action.MoveToElement(modulesButton).Perform();
            }

            // Click 'Repertoire Management Module'
            IWebElement repertoireModule = wait.Until(driver =>
                driver.FindElements(By.PartialLinkText("Repertoire Management Module")).FirstOrDefault());
            repertoireModule?.Click();

            // Scroll to 'Additional Features'
            IWebElement additionalFeatures = wait.Until(driver =>
                driver.FindElement(By.XPath("//*[contains(text(), 'Additional Features')]")));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", additionalFeatures);

            // Click on 'Products Supported'
            IWebElement productsSupported = wait.Until(driver =>
                driver.FindElement(By.XPath("//*[text()='Products Supported']")));
            productsSupported.Click();

            // Wait for the list to appear and be filled with visible, non-empty items
            var items = wait.Until(driver =>
            {
                try
                {
                    var heading = driver.FindElement(By.XPath("//*[contains(text(), 'There are several types of Product Supported:')]"));
                    var ul = heading.FindElement(By.XPath("./following-sibling::*[descendant-or-self::ul][1]//ul[1]"));
                    var lis = ul.FindElements(By.TagName("li"))
                                .Where(li => !string.IsNullOrWhiteSpace(li.Text))
                                .ToList();
                    return lis.Count > 0 ? lis : null;
                }
                catch
                {
                    return null;
                }
            });

            // Print non-empty items
            if (items != null)
            {
                foreach (var item in items)
                {
                    Console.WriteLine(item.Text.Trim());
                }
            }
        }
    }
}