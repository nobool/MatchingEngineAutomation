using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;

[TestFixture]
public class MatchingEngineTests
{
    private IWebDriver _driver;
    private IHomePage _homePage;
    private IRepertoirePage _repertoirePage;
    private IWebDriverFactory _webDriverFactory;

    public MatchingEngineTests()
    {
        _webDriverFactory = new WebDriverFactory();
    }

    [SetUp]
    public void Setup()
    {
        _driver = _webDriverFactory.Create();
        // _driver.Manage().Window.Size = new System.Drawing.Size(1920, 1080);

        _homePage = new HomePage(_driver);
        _repertoirePage = new RepertoirePage(_driver);
    }

    [Test]
    public void Verify_Supported_Product_List()
    {
        try
        {
            _homePage.Open();

            try {
                _homePage.HoverOverModules(); }
            catch (Exception ex) { Assert.Fail($"Failed while clicking over 'Modules': {ex.Message}"); }

            try { _homePage.SelectRepertoireManagementModule(); }
            catch (Exception ex) { Assert.Fail($"Failed while clicking 'Repertoire Management Module': {ex.Message}"); }

            try { _repertoirePage.ScrollToAdditionalFeatures(); }
            catch (Exception ex) { Assert.Fail($"Failed while scrolling to 'Additional Features': {ex.Message}"); }

            try { _repertoirePage.OpenProductsSupported(); }
            catch (Exception ex) { Assert.Fail($"Failed while clicking 'Products Supported': {ex.Message}"); }

            List<string> actual;
            try { actual = _repertoirePage.GetSupportedProducts(); }
            catch (Exception ex) { throw new Exception($"Failed while retrieving supported products: {ex.Message}", ex); }

            Assert.That(actual, Is.EquivalentTo(ProductList.Expected));
        }
        catch (Exception ex)
        {
            Assert.Fail($"Unhandled test failure: {ex.Message}");
        }
    }

    [TearDown]
    public void TearDown()
    {
        _driver.Quit();
    }
}