using OpenQA.Selenium;

namespace SeleniumCSharpUITests.Pages
{
    public class CheckboxPage
    {
        private readonly IWebDriver _driver;
        private const string Url = 
            "https://the-internet.herokuapp.com/checkboxes";

        private IWebElement Checkbox1 => 
            _driver.FindElements(By.CssSelector("input[type='checkbox']"))[0];
        private IWebElement Checkbox2 => 
            _driver.FindElements(By.CssSelector("input[type='checkbox']"))[1];

        public CheckboxPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void NavigateTo() => _driver.Navigate().GoToUrl(Url);

        public bool IsCheckbox1Checked() => Checkbox1.Selected;
        public bool IsCheckbox2Checked() => Checkbox2.Selected;

        public void CheckCheckbox1() 
        { 
            if (!Checkbox1.Selected) Checkbox1.Click(); 
        }

        public void UncheckCheckbox2() 
        { 
            if (Checkbox2.Selected) Checkbox2.Click(); 
        }

        public void ToggleCheckbox1() => Checkbox1.Click();
        public void ToggleCheckbox2() => Checkbox2.Click();
    }
}