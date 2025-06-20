/// <summary>
/// Centralized XPath and selector constants used across page objects.
/// </summary>
public static class ElementSelectors
{
    public const string ModulesLinkText = "Modules";
    public const string RepertoireModulePartialLinkText = "Repertoire Management Module";
    public const string AdditionalFeaturesXPath = "//*[contains(text(), 'Additional Features')]";
    public const string ProductsSupportedXPath = "//*[text()='Products Supported']";
    public const string ProductSupportHeadingXPath = "//*[contains(text(), 'There are several types of Product Supported:')]";
    public const string ProductListXPath = "./following-sibling::*[descendant-or-self::ul][1]//ul[1]";
}