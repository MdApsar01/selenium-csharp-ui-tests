using NUnit.Framework;
using SeleniumCSharpUITests.Base;
using SeleniumCSharpUITests.Pages;

namespace SeleniumCSharpUITests.Tests
{
    [TestFixture]
    public class AlertTests : BaseTest
    {
        private AlertPage _alertPage;

        [SetUp]
        public void TestSetup()
        {
            _alertPage = new AlertPage(Driver);
            _alertPage.NavigateTo();
        }

        [Test]
        [Category("Alerts")]
        public void SimpleAlert_ShouldBeAccepted()
        {
            _alertPage.TriggerAlert();
            string alertText = _alertPage.GetAlertText();
            _alertPage.AcceptAlert();

            Assert.That(alertText, Is.EqualTo("I am a JS Alert"),
                "Alert text does not match expected");
            Assert.That(_alertPage.GetResultText(), 
                Is.EqualTo("You successfully clicked an alert"),
                "Result message not shown after accepting alert");
        }

        [Test]
        [Category("Alerts")]
        public void ConfirmAlert_Accept_ShouldShowConfirmed()
        {
            _alertPage.TriggerConfirm();
            _alertPage.AcceptAlert();

            Assert.That(_alertPage.GetResultText(),
                Is.EqualTo("You clicked: Ok"),
                "Result message not shown after accepting confirm");
        }

        [Test]
        [Category("Alerts")]
        public void ConfirmAlert_Dismiss_ShouldShowCancelled()
        {
            _alertPage.TriggerConfirm();
            _alertPage.DismissAlert();

            Assert.That(_alertPage.GetResultText(),
                Is.EqualTo("You clicked: Cancel"),
                "Result message not shown after dismissing confirm");
        }

        [Test]
        [Category("Alerts")]
        public void PromptAlert_ShouldAcceptTypedText()
        {
            _alertPage.TriggerPrompt();
            _alertPage.TypeInPrompt("Mohamed Apsar");

            Assert.That(_alertPage.GetResultText(),
                Is.EqualTo("You entered: Mohamed Apsar"),
                "Typed text not reflected in result message");
        }
    }
}