using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace SeleniumTester.PageObjectModels
{
    internal class HomePage
    {
        private readonly IWebDriver Driver;
        private const string PageUrl = "https://mjbaber.co.uk/";
        private const string PageTitle = "Mark James Baber - Welcome!";

        public HomePage(IWebDriver driver)
        {
            Driver = driver;
        }

        public string DataSci => Driver.FindElement(By.CssSelector("html body div.container-fluid.p-5.bg-dark.text-white.text-center h1")).Text;
        public void ClickContactFooterLink() => Driver.FindElement(By.Id("ContactFooter")).Click();
        public void ClickLiveChatFooterLink() => Driver.FindElement(By.Id("LiveChat")).Click();
        public void ClickAboutUsLink() => Driver.FindElement(By.Id("LearnAboutUs")).Click();
        public bool IsCookieMessagePresent => Driver.FindElements(By.Id("CookiesBeingUsed")).Any();

        public void NavigateTo()
        {
            Driver.Navigate().GoToUrl(PageUrl);
            EnsurePageLoaded();
        }

        /// <summary>
        /// Checks that the URL and page title are as expected
        /// </summary>
        /// <param name="onlyCheckUrlStartsWithExpectedText">Set to false to do an exact match of URL. Set to true to ignore fragments, query string, etc at end of browser URL</param>
        public void EnsurePageLoaded(bool onlyCheckUrlStartsWithExpectedText = true)
        {
            bool urlIsCorrect;
            if (onlyCheckUrlStartsWithExpectedText)
            {
                urlIsCorrect = Driver.Url.StartsWith(PageUrl);
            }
            else
            {
                urlIsCorrect = Driver.Url == PageUrl;
            }

            bool pageHasLoaded = urlIsCorrect && (Driver.Title == PageTitle);
            if (!pageHasLoaded)
            {
                throw new Exception($"Failed to load page. Page URL = '{Driver.Url}'");
            }
        }
    }
}
