using System;
using Reqnroll;
using Allure.Net.Commons;

namespace PlaywrightBDDTests.Hooks
{
    [Binding]
    public class AllureHooks
    {
        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            Environment.SetEnvironmentVariable("ALLURE_CONFIG", "allureConfig.json");
        }
    }
}