using NUnit.Framework;
using SeleniumCSharpUITests.Base;
using SeleniumCSharpUITests.Pages;

namespace SeleniumCSharpUITests.Tests
{
    [TestFixture]
    public class CheckboxTests : BaseTest
    {
        private CheckboxPage _checkboxPage;

        [SetUp]
        public void TestSetup()
        {
            _checkboxPage = new CheckboxPage(Driver);
            _checkboxPage.NavigateTo();
        }

        [Test]
        [Category("Checkbox")]
        public void Checkbox1_ShouldBeUncheckedByDefault()
        {
            Assert.That(_checkboxPage.IsCheckbox1Checked(), Is.False,
                "Checkbox 1 should be unchecked on page load");
        }

        [Test]
        [Category("Checkbox")]
        public void Checkbox2_ShouldBeCheckedByDefault()
        {
            Assert.That(_checkboxPage.IsCheckbox2Checked(), Is.True,
                "Checkbox 2 should be checked on page load");
        }

        [Test]
        [Category("Checkbox")]
        public void CheckCheckbox1_ShouldBeChecked()
        {
            _checkboxPage.CheckCheckbox1();

            Assert.That(_checkboxPage.IsCheckbox1Checked(), Is.True,
                "Checkbox 1 should be checked after clicking");
        }

        [Test]
        [Category("Checkbox")]
        public void UncheckCheckbox2_ShouldBeUnchecked()
        {
            _checkboxPage.UncheckCheckbox2();

            Assert.That(_checkboxPage.IsCheckbox2Checked(), Is.False,
                "Checkbox 2 should be unchecked after clicking");
        }

        [Test]
        [Category("Checkbox")]
        public void ToggleCheckbox1_ShouldChangeState()
        {
            bool stateBefore = _checkboxPage.IsCheckbox1Checked();
            _checkboxPage.ToggleCheckbox1();
            bool stateAfter = _checkboxPage.IsCheckbox1Checked();

            Assert.That(stateAfter, Is.Not.EqualTo(stateBefore),
                "Checkbox 1 state should change after toggle");
        }
    }
}