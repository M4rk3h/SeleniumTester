using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager;

namespace SeleniumTester
{
    public class fromBard
    {
        private WebDriver driver;

        [SetUp]
        public void Setup()
        {
            // Replace with your desired path to ChromeDriver
            new DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();
        }

        [Test]
        public void TestIfGoogleUkIsPresent()
        {
            // Open Google in a Chrome Driver
            driver.Navigate().GoToUrl("https://www.google.co.uk/");
            // Maximise window
            driver.Manage().Window.Maximize();
            DemoHelper.Pause();

            // Cookie Popup - Click Accept
            IWebElement acceptAll = driver.FindElement(By.Id("L2AGLb"));
            acceptAll.Click();

            // Find the element for gmail
            IWebElement aboutElement = driver.FindElement(By.XPath("/html/body/div[1]/div[1]/a[1]"));

            // Assert that the element is not null and contains the text "Google"
            Assert.NotNull(aboutElement);
            Assert.IsTrue(aboutElement.Text.Contains("About"));
            DemoHelper.Pause();

            aboutElement.Click();
            DemoHelper.Pause();
            Assert.IsTrue(driver.Title.Contains("Google - About Google, our culture and company news"));

            var twentyFiveImg = driver.FindElement(By.XPath("/html/body/main/div/section[5]/div/div[2]/div/div/a/div/div/picture/img"));
            Actions actions = new Actions(driver);
            actions.MoveToElement(twentyFiveImg);
            actions.Perform();
            DemoHelper.Pause();
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
