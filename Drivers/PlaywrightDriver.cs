using Microsoft.Playwright;
using System.Threading.Tasks;
using PlaywrightBDDTests.Drivers;

namespace PlaywrightBDDTests.Drivers
{
    public class PlaywrightDriver
    {
        private IPlaywright _playwright;
        private IBrowser _browser;
        private IBrowserContext _context;

        public IPage Page { get; private set; }

        public async Task InitializeAsync()
        {
            _playwright = await Playwright.CreateAsync();

            _browser = await _playwright.Chromium.LaunchAsync(
                new BrowserTypeLaunchOptions
                {
                    Headless = true
                });

            _context = await _browser.NewContextAsync();

            Page = await _context.NewPageAsync();
        }

        public async Task DisposeAsync()
        {
            await Page.CloseAsync();
            await _context.CloseAsync();
            await _browser.CloseAsync();
        }
    }
}