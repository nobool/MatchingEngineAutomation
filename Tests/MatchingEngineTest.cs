using NUnit.Framework;
using OpenQA.Selenium;

[TestFixture]
public class MatchingEngineTests
{
    private IWebDriver _driver;
    private HomePage _homePage;
    private RepertoirePage _repertoirePage;

    [SetUp]
    public void Setup()
    {
        _driver = WebDriverFactory.CreateChromeDriver();
        _driver.Manage().Window.Maximize();

        _homePage = new HomePage(_driver);
        _repertoirePage = new RepertoirePage(_driver);
    }

    [Test]
    public void Should_Display_Correct_Supported_Products()
    {
        _homePage.Open();

        _homePage.HoverOverModules();

        _homePage.SelectRepertoireManagementModule();

        _repertoirePage.ScrollToAdditionalFeatures();

        _repertoirePage.OpenProductsSupported();

        List<string> actual = _repertoirePage.GetSupportedProducts();

        if (actual == null)
        {
            Console.WriteLine("DEBUG: Returned product list is NULL.");
        }
        else if (actual.Count == 0)
        {
            Console.WriteLine("DEBUG: Returned product list is EMPTY.");
        }
        else
        {
            Console.WriteLine("DEBUG: Product list items retrieved:");
            foreach (var item in actual)
            {
                Console.WriteLine($" - {item}");
            }
        }

        Console.WriteLine("Running assertion against expected values...");
        Assert.That(actual, Is.EquivalentTo(ProductList.Expected));
    }

    [TearDown]
    public void TearDown()
    {
        _driver.Quit();
    }
}