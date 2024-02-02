﻿using SeleniumTester.PageObjectModels;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using Xunit;

namespace SeleniumTester
{
    public class DriverManTests
    {
        [Fact]
        [Trait("Category", "Smoke")]
        public void _1ChromeSession()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
            var driver = new ChromeDriver();
            var homePage = new HomePage(driver);
            homePage.NavigateTo();
            DemoHelper.Pause();
            driver.Quit();
        }

        [Fact]
        [Trait("Category", "Smoke")]
        public void _2EdgeSession()
        {
            new DriverManager().SetUpDriver(new EdgeConfig());
            var driver = new EdgeDriver();
            var homePage = new HomePage(driver);
            homePage.NavigateTo();
            //DemoHelper.Pause();
            driver.Quit();
        }

        [Fact]
        [Trait("Category", "Smoke")]
        public void _3FirefoxSession()
        {
            new DriverManager().SetUpDriver(new FirefoxConfig());
            var driver = new FirefoxDriver();
            var homePage = new HomePage(driver);
            homePage.NavigateTo();
            DemoHelper.Pause();
            Assert.Equal("MSc Data Science", homePage.DataSci[3].ToString());
            driver.Quit();
        }
    }
}
