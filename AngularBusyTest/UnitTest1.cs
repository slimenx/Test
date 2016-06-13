using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System.Collections.Generic;
using System.Linq;

namespace AngularBusyTest
{
    [TestClass]
    public class UnitTest1
    {
        private IWebDriver _driver;

        private void arrange()
        {
            _driver = new ChromeDriver();
            _driver.Navigate().GoToUrl("http://cgross.github.io/angular-busy/demo/");
        }

        #region helpful elements commented
        //<button class="btn btn-default pull-right" ng-click="demo()">Demo</button>
        //<div class="cg-busy-default-text ng-binding">Please Wait...</div>
        //<div class="cg-busy cg-busy-animation ng-scope ng-hide" ng-show="$cgBusyIsActive()" style="">
        //<input type="text" class="form-control ng-pristine ng-valid" id="message" ng-model="message">
        //<input type="text" class="form-control ng-pristine ng-valid" id="durationInput" ng-model="minDuration">
        #endregion

        #region test

        [TestMethod]
        public void TestMethod1()
        {
            arrange();

            #region act

            _driver.FindElement(By.ClassName("btn")).Click();

            #endregion

            #region assert

            Assert.IsTrue(isBusy());
            Assert.IsTrue(isBusyTextEqual("Please Wait..."));

            #endregion
        }

        [TestMethod]
        public void TestMethod2()
        {
            arrange();
            string message = "Waiting";

            #region act

            var messageTextBox = _driver.FindElement(By.Id("message"));
            messageTextBox.Clear();
            messageTextBox.SendKeys(message);

            _driver.FindElement(By.ClassName("btn")).Click();

            #endregion

            #region assert

            Assert.IsTrue(isBusy());
            Assert.IsTrue(isBusyTextEqual(message));

            #endregion
        }

        [TestMethod]
        public void TestMethod3()
        {
            arrange();
            string message = "Waiting";
            int duration = 5000;

            #region act

            var messageTextBox = _driver.FindElement(By.Id("message"));
            messageTextBox.Clear();
            messageTextBox.SendKeys(message);

            var durationTextBox = _driver.FindElement(By.Id("durationInput"));
            durationTextBox.Clear();
            durationTextBox.SendKeys(duration.ToString());

            _driver.FindElement(By.ClassName("btn")).Click();

            #endregion

            #region assert

            //making sure that busy stays for duration
            System.Threading.Thread.Sleep(duration - 100);
            Assert.IsTrue(isBusy());
            Assert.IsTrue(isBusyTextEqual(message));

            //making sure that busy is gone after duration
            System.Threading.Thread.Sleep(200);
            Assert.IsTrue(!isBusy());

            #endregion
        }

        #endregion

        #region helpers

        private bool isBusy()
        {
            return (from c in _driver.FindElement(By.ClassName("cg-busy-animation")).GetAttribute("class").Split(' ')
                    where c == "ng-hide"
                    select c).Count() == 0;
        }
        
        private bool isBusyTextEqual(string text)
        {
            return _driver.FindElement(By.ClassName("cg-busy-default-text")).Text == text;
        }

        #endregion

    }
}
