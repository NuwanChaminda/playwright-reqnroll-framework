using Reqnroll;
using System.Threading.Tasks;
using PlaywrightBDDTests.Drivers;

[Binding]
public class PlaywrightHooks
{
    private readonly PlaywrightDriver _driver;

    public PlaywrightHooks(PlaywrightDriver driver)
    {
        _driver = driver;
    }

    [BeforeScenario]
    public async Task StartBrowser()
    {
        await _driver.InitializeAsync();
    }

    [AfterScenario]
    public async Task CloseBrowser()
    {
        await _driver.DisposeAsync();
    }
}