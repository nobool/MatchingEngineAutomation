/// <summary>
/// Stores configuration constants like base URLs.
/// </summary>
public static class TestConfig
{
    public const string BaseUrl = "https://www.matchingengine.com/";

    // Check if running in headless mode (default to false if not set)
    public static bool Headless
    {
        get
        {
            var value = Environment.GetEnvironmentVariable("HEADLESS");
            return value?.ToLower() == "true";
        }
    }
}