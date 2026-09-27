using OpenQA.Selenium;

namespace SeleniumCSharpUITests.Pages
{
    public class LoginPage
    {
        private readonly IWebDriver _driver;
        private const string Url = 
            "https://the-internet.herokuapp.com/login";

        // Locators
        private IWebElement UsernameField => 
            _driver.FindElement(By.Id("username"));
        private IWebElement PasswordField => 
            _driver.FindElement(By.Id("password"));
        private IWebElement LoginButton => 
            _driver.FindElement(By.CssSelector("button[type='submit']"));
        private IWebElement SuccessMessage => 
            _driver.FindElement(By.CssSelector(".flash.success"));
        private IWebElement ErrorMessage => 
            _driver.FindElement(By.CssSelector(".flash.error"));

        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void NavigateTo() => _driver.Navigate().GoToUrl(Url);

        public void EnterUsername(string username) => 
            UsernameField.SendKeys(username);

        public void EnterPassword(string password) => 
            PasswordField.SendKeys(password);

        public void ClickLogin() => LoginButton.Click();

        public string GetSuccessMessage() => SuccessMessage.Text;

        public string GetErrorMessage() => ErrorMessage.Text;

        public void LoginWith(string username, string password)
        {
            EnterUsername(username);
            EnterPassword(password);
            ClickLogin();
        }
    }
}