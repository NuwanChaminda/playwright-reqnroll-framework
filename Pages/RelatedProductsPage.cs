using Microsoft.Playwright;
using System.Threading.Tasks;
using PlaywrightBDDTests.Drivers;

public class RelatedProductsPage
{
    private readonly IPage _page;

    private const string RELATED_SECTION = "section:has-text('Similar items')";
    private const string PRODUCT_CARDS = "//a[@class='wwfl']";
    private const string PRODUCT_TITLE = "//div[@class='fkTT']/div/h3";
    private const string PRODUCT_PRICE = "[class*=price]";
    private const string PRODUCT_IMAGE = "//div[@class='recs-image-wrap-below-hero']/div/img";
    private const string ALL_LINKS = "a[href *= '/itm/']";

    public RelatedProductsPage(PlaywrightDriver driver)
    {
        _page = driver.Page;
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
        return _page.Locator(ALL_LINKS);
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