using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace Akbank.UITests.PageModels {
    public class BasePage {
        private IWebDriver webDriver;

        public BasePage(IWebDriver webDriver) {
            this.webDriver = webDriver;
            PageFactory.InitElements(this.webDriver, this);
        }

        public void ScrollInToView(IWebElement element) {
            Wait(5);
            IJavaScriptExecutor js = (IJavaScriptExecutor)webDriver;
            js.ExecuteScript("arguments[0].scrollIntoView(true);", element);
        }

        public void ClickElement(IWebElement element) {
            Wait(15, element);
            element.Click();
        }

        public void SetText(IWebElement element, string text) {
            Wait(15, element);
            element.SendKeys(text);
            element.SendKeys(Keys.Tab);
        }

        public void Clear(IWebElement element) {
            Wait(15, element);
            element.Clear();
        }

        public string GetCurrentUrl() {
            return webDriver.Url;
        }

        public void Wait(int second, IWebElement element) {
            WebDriverWait wait = new WebDriverWait(this.webDriver, TimeSpan.FromSeconds(second));
            wait.Until(ExpectedConditions.ElementToBeClickable(element));
        }

        public void Wait(int second) {
            Thread.Sleep(TimeSpan.FromSeconds(second));
        }
    }
}
