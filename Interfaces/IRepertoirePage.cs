using System.Collections.Generic;

public interface IRepertoirePage
{
    void ScrollToAdditionalFeatures();
    void OpenProductsSupported();
    List<string> GetSupportedProducts();
}