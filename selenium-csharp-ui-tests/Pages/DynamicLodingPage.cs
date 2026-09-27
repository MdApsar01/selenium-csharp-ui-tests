using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SeleniumCSharpUITests.Pages
{
    public class DynamicLoadingPage
    {
        private readonly IWebDriver _driver;
        private const string Url =
            "https://the-internet.herokuapp.com/dynamic_loading/1";

        private IWebElement StartButton =>
            _driver.FindElement(By.CssSelector("#start button"));

        private IWebElement FinishText =>
            _driver.FindElement(By.Id("finish"));

        public DynamicLoadingPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void NavigateTo() => _driver.Navigate().GoToUrl(Url);

        public void ClickStart() => StartButton.Click();

        public string GetFinishText()
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(15));
            wait.Until(d => FinishText.Displayed);
            return FinishText.Text;
        }
        public bool IsLoadingIndicatorShown()
        {
            try
            {
                var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
                var loading = _driver.FindElement(By.Id("loading"));
                return wait.Until(d => loading.Displayed);
            }
            catch
            {
                return false;
            }
        }
    }
}