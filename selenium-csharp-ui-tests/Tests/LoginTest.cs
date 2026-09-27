using NUnit.Framework;
using SeleniumCSharpUITests.Base;
using SeleniumCSharpUITests.Pages;

namespace SeleniumCSharpUITests.Tests
{
    [TestFixture]
    public class LoginTests : BaseTest
    {
        private LoginPage _loginPage;

        [SetUp]
        public void TestSetup()
        {
            _loginPage = new LoginPage(Driver);
            _loginPage.NavigateTo();
        }

        [Test]
        [Category("Login")]
        public void ValidLogin_ShouldShowSuccessMessage()
        {
            _loginPage.LoginWith("tomsmith", "SuperSecretPassword!");

            string message = _loginPage.GetSuccessMessage();

            Assert.That(message, Does.Contain("You logged into a secure area!"),
                "Success message not displayed after valid login");
        }

        [Test]
        [Category("Login")]
        public void InvalidPassword_ShouldShowErrorMessage()
        {
            _loginPage.LoginWith("tomsmith", "wrongpassword");

            string message = _loginPage.GetErrorMessage();

            Assert.That(message, Does.Contain("Your password is invalid!"),
                "Error message not displayed after invalid password");
        }

        [Test]
        [Category("Login")]
        public void InvalidUsername_ShouldShowErrorMessage()
        {
            _loginPage.LoginWith("wronguser", "SuperSecretPassword!");

            string message = _loginPage.GetErrorMessage();

            Assert.That(message, Does.Contain("Your username is invalid!"),
                "Error message not displayed after invalid username");
        }

        [Test]
        [Category("Login")]
        public void EmptyCredentials_ShouldShowErrorMessage()
        {
            _loginPage.ClickLogin();

            string message = _loginPage.GetErrorMessage();

            Assert.That(message, Does.Contain("Your username is invalid!"),
                "Error message not displayed for empty credentials");
        }
    }
}