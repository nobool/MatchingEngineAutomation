using System.Collections.Generic;

public interface IRepertoirePage
{
    void WaitUntilLoaded();
    void ScrollToAdditionalFeatures();
    void OpenProductsSupported();
    List<string> GetSupportedProducts();
}