using System.Threading.Tasks;
using Reqnroll;
using Microsoft.Playwright;
using Allure.Net.Commons;
using PlaywrightBDDTests.Drivers;

namespace PlaywrightBDDTests.Hooks
{
    [Binding]
    public class TestHooks
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly PlaywrightDriver _driver;

        public TestHooks(ScenarioContext scenarioContext, PlaywrightDriver driver)
        {
            _scenarioContext = scenarioContext;
            _driver = driver;
        }

        [AfterScenario]
        public async Task TakeScreenshot()
{
    try
    {
        if (_driver.Page != null)
        {
            var screenshot = await _driver.Page.ScreenshotAsync();

            AllureApi.AddAttachment(
                "Screenshot",
                "image/png",
                screenshot
            );
        }
    }
    catch
    {
        // ignore if page already closed
    }
}
    }
}