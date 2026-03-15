using Microsoft.Playwright;
using System.Threading.Tasks;
using PlaywrightBDDTests.Drivers;

public class ProductsPage
{
    private readonly IPage _page;

    private const string RELATED_SECTION = "section:has-text('Similar items')";
    private const string PRODUCT_SEARCH = "//a[@class='s-card__link image-treatment']/img[@loading='eager']";
    private const string PRODUCT_CARDS = "//a[@class='wwfl']";
    private const string PRODUCT_TITLE = "h3, [role=heading]";
    private const string PRODUCT_PRICE = "[class*=price]";
    private const string PRODUCT_IMAGE = "img";

    private const string URL = "https://www.ebay.com/sch/i.html?_nkw=wallet+slim";

    public ProductsPage(PlaywrightDriver driver)
    {
        _page = driver.Page;
    }

    public async Task OpenWalletPage()
    {
        await _page.GotoAsync(URL);
    }

    public async Task<bool> RelatedSectionVisible()
    {
        return await _page.Locator(RELATED_SECTION).IsVisibleAsync();
    }

    public async Task<int> ProductCount()
    {
        return await _page.Locator(PRODUCT_CARDS).CountAsync();
    }

    public ILocator Titles()
    {
        return _page.Locator(PRODUCT_TITLE);
    }

    public ILocator Prices()
    {
        return _page.Locator(PRODUCT_PRICE);
    }

    public ILocator Images()
    {
        return _page.Locator(PRODUCT_IMAGE);
    }

    public ILocator Links()
    {
        return _page.Locator(PRODUCT_SEARCH);
    }

    public async Task ClickFirst()
    {
        await Links().First.ClickAsync();
    }

    public async Task WaitForProducts()
    {
        await _page.WaitForSelectorAsync(PRODUCT_CARDS);
    }
}