using Microsoft.Playwright;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;
using Reqnroll;
using System.Linq;
using Allure.Net.Commons;
using Allure.NUnit.Attributes;
using PlaywrightBDDTests.Drivers;

[AllureFeature("Related Products")]
[AllureStory("Validation Rules")]
[Binding]
public class RelatedProductsSteps
{
    private readonly PlaywrightDriver driver;
    private IPage page;
    private IPage newPage;

    public RelatedProductsSteps(PlaywrightDriver driver)
    {
        this.driver = driver;
        page = driver.Page;
    }

    [Given(@"user opens wallet search page")]
    public async Task GivenUserOpensWalletSearchPage()
    {
        var products = new ProductsPage(driver);
        await products.OpenWalletPage();
    }

    [When(@"related products are visible")]
    public async Task WhenRelatedProductsVisible()
    {
        await page.WaitForSelectorAsync("a[href*='/itm/']");

        var p = new ProductsPage(driver);

        var popup = await page.RunAndWaitForPopupAsync(async () =>
        {
            await p.ClickFirst();
        });

        newPage = popup;
        await newPage.WaitForLoadStateAsync(LoadState.DOMContentLoaded);
    }

    [Then(@"validate testcase (.*)")]
    public async Task ThenValidateTestcase(int tc)
    {
        var rp = new RelatedProductsPage(driver);

        await newPage.WaitForSelectorAsync("//h2[text()='Similar items']");

        if (tc == 1)
        {
            Assert.IsTrue(await rp.RelatedSectionVisible());
        }

        if (tc == 3)
        {
            int count = await rp.ProductCount();
            Assert.LessOrEqual(count, 6);
        }

        if (tc == 4)
        {
            int count = await rp.ProductCount();
            Assert.AreEqual(6, count);
        }

        if (tc == 5)
        {
            int outOfStock = await newPage.Locator(":has-text('Out of stock')").CountAsync();
            Assert.AreEqual(0, outOfStock);
        }

        if (tc == 8)
        {
            var links = await rp.Links().AllAsync();

            var hrefs = new List<string>();

            foreach (var l in links)
            {
                hrefs.Add(await l.GetAttributeAsync("href"));
            }

            Assert.AreEqual(hrefs.Count, hrefs.Distinct().Count());
        }

        if (tc == 15)
        {
            Assert.Greater(await rp.Images().CountAsync(), 0);
            Assert.Greater(await rp.Titles().CountAsync(), 0);
            Assert.Greater(await rp.Prices().CountAsync(), 0);
        }

        if (tc == 16)
        {
            var imgs = await rp.Images().AllAsync();

            foreach (var img in imgs)
            {
                var src = await img.GetAttributeAsync("src");
                Assert.IsNotNull(src);
            }
        }
    }
}