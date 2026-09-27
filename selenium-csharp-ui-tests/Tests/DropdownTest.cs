using NUnit.Framework;
using SeleniumCSharpUITests.Base;
using SeleniumCSharpUITests.Pages;

namespace SeleniumCSharpUITests.Tests
{
    [TestFixture]
    public class DropdownTests : BaseTest
    {
        private DropdownPage _dropdownPage;

        [SetUp]
        public void TestSetup()
        {
            _dropdownPage = new DropdownPage(Driver);
            _dropdownPage.NavigateTo();
        }

        [Test]
        [Category("Dropdown")]
        public void SelectOption1_ShouldBeSelected()
        {
            _dropdownPage.SelectByText("Option 1");

            string selected = _dropdownPage.GetSelectedOption();

            Assert.That(selected, Is.EqualTo("Option 1"),
                "Option 1 was not selected in dropdown");
        }

        [Test]
        [Category("Dropdown")]
        public void SelectOption2_ShouldBeSelected()
        {
            _dropdownPage.SelectByText("Option 2");

            string selected = _dropdownPage.GetSelectedOption();

            Assert.That(selected, Is.EqualTo("Option 2"),
                "Option 2 was not selected in dropdown");
        }

        [Test]
        [Category("Dropdown")]
        public void DefaultOption_ShouldBePlaceholder()
        {
            string selected = _dropdownPage.GetSelectedOption();

            Assert.That(selected, Is.EqualTo("Please select an option"),
                "Default placeholder not shown on page load");
        }
    }
}