using NUnit.Framework;
using SeleniumCSharpUITests.Base;
using SeleniumCSharpUITests.Pages;

namespace SeleniumCSharpUITests.Tests
{
    [TestFixture]
    public class DynamicLoadingTests : BaseTest
    {
        private DynamicLoadingPage _dynamicLoadingPage;

        [SetUp]
        public void TestSetup()
        {
            _dynamicLoadingPage = new DynamicLoadingPage(Driver);
            _dynamicLoadingPage.NavigateTo();
        }

        [Test]
        [Category("DynamicLoading")]
        public void StartButton_ShouldRevealHiddenElement()
        {
            _dynamicLoadingPage.ClickStart();

            string result = _dynamicLoadingPage.GetFinishText();

            Assert.That(result, Is.EqualTo("Hello World!"),
                "Finish text not displayed after dynamic loading completed");
        }

        [Test]
        [Category("DynamicLoading")]
        public void LoadingIndicator_ShouldAppearAfterStart()
        {
            _dynamicLoadingPage.ClickStart();

            bool loadingShown = _dynamicLoadingPage.IsLoadingIndicatorShown();

            Assert.That(loadingShown, Is.True,
            "Loading indicator should appear after clicking Start");
        }
    }
}