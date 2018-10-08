using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using RelevantCodes.ExtentReports;
using System.Threading;
using NUnit.Framework.Interfaces;

namespace demo
{
    [TestFixture]
    public class DemoExtent
    {

        public ExtentReports extent;
        public ExtentTest test;
        public IWebDriver driver;

        //[Test,Order(1)]
        //public void DemoReportPass()
        //{
        //    test = extent.StartTest("LoginTest");
        //    Assert.True(driver.Title.Equals("Facebook"));
        //    test.Log(LogStatus.Pass, "Assert Pass as consition is true");

        //}

        //[Test,Order(2)]
        //public void DemoReportFail()
        //{
        //    test = extent.StartTest("LoginTest");
        //    Assert.False(driver.Title.Equals("Facebook"));
        //   test.Log(LogStatus.Fail, "Assert Pass as condition is false");

        //}

        [Test,Order(0)]
        public void LoginTest()
        {
            extent = new ExtentReports("C:\\Report\\report.html");
            var test = extent.StartTest("LoginTest", "Invalid login credentials test");

            extent.AddSystemInfo("Host Name", "Vijay")

            .AddSystemInfo("Environment", "local")

            .AddSystemInfo("Username", "vijay");

            test.Log(LogStatus.Info, "validating whether we are able to login with invalid credentials");

            driver = new ChromeDriver(@"C:\Users\vijay\Desktop\chromedriver_win32");
            driver.Navigate().GoToUrl("http://facebook.com");
            driver.Manage().Window.Maximize();

            driver.FindElement(By.XPath("//input[@id='email']")).SendKeys("test");
            driver.FindElement(By.XPath("//input[@id='pass']")).SendKeys("test");
            Thread.Sleep(5000);
            driver.FindElement(By.XPath("//input[@value='Log In']")).Click();

            Thread.Sleep(10000);

            Assert.False(driver.Title.Equals("Facebook"));
            test.Log(LogStatus.Pass, "for invalid user and password not able to login");



        }



        [TearDown]
        //public void GetResult()
        //{
        //    var status = TestContext.CurrentContext.Result.Outcome.Status;
        //    var stackTrace = "<pre>" +
        //    TestContext.CurrentContext.Result.StackTrace + "</pre>";
        //    var errorMessage = TestContext.CurrentContext.Result.Message;

        //    if (status == NUnit.Framework.Interfaces.TestStatus.Failed)
        //    {
        //        test.Log(LogStatus.Fail, stackTrace + errorMessage);
        //    }
        //    extent.EndTest(test);

        //}

        public void EndReport()
        {
            extent.Flush();
            extent.Close();
            driver.Quit();
        }
    }
}

    
