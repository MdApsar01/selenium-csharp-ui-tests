using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SeleniumCSharpUITests.Pages
{
    public class DropdownPage
    {
        private readonly IWebDriver _driver;
        private const string Url = 
            "https://the-internet.herokuapp.com/dropdown";

        private IWebElement DropdownElement => 
            _driver.FindElement(By.Id("dropdown"));

        public DropdownPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void NavigateTo() => _driver.Navigate().GoToUrl(Url);

        public void SelectByText(string text)
        {
            var select = new SelectElement(DropdownElement);
            select.SelectByText(text);
        }

        public string GetSelectedOption()
        {
            var select = new SelectElement(DropdownElement);
            return select.SelectedOption.Text;
        }
    }
}