using OpenQA.Selenium;

namespace SeleniumCSharpUITests.Pages
{
    public class AlertPage
    {
        private readonly IWebDriver _driver;
        private const string Url =
            "https://the-internet.herokuapp.com/javascript_alerts";

        private IWebElement AlertButton =>
            _driver.FindElement(By.XPath("//button[text()='Click for JS Alert']"));
        private IWebElement ConfirmButton =>
            _driver.FindElement(By.XPath("//button[text()='Click for JS Confirm']"));
        private IWebElement PromptButton =>
            _driver.FindElement(By.XPath("//button[text()='Click for JS Prompt']"));
        private IWebElement ResultText =>
            _driver.FindElement(By.Id("result"));

        public AlertPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void NavigateTo() => _driver.Navigate().GoToUrl(Url);

        public void TriggerAlert() => AlertButton.Click();
        public void TriggerConfirm() => ConfirmButton.Click();
        public void TriggerPrompt() => PromptButton.Click();

        public void AcceptAlert()
        {
            _driver.SwitchTo().Alert().Accept();
        }

        public void DismissAlert()
        {
            _driver.SwitchTo().Alert().Dismiss();
        }

        public string GetAlertText()
        {
            return _driver.SwitchTo().Alert().Text ?? string.Empty;
        }

        public void TypeInPrompt(string text)
        {
            _driver.SwitchTo().Alert().SendKeys(text);
            _driver.SwitchTo().Alert().Accept();
        }

        public string GetResultText() => ResultText.Text;
    }
}