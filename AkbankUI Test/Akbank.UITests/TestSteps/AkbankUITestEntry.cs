using Akbank.UITests.PageModels;
using Akbank.UITests.Utils;
using OpenQA.Selenium;
using System;
using System.IO;
using System.Reflection;
using TechTalk.SpecFlow;

namespace Akbank.UITests.TestSteps {
    [Binding, Scope(Feature = "AkbankUITestEntry")]
    public class AkbankUITestEntry {
        public static IWebDriver WebDriver { get; set; }
        public BasePage basePage;
        public AkbankUITest stepDetails;
        public BrowserUtils browser;
        string driverPath = String.Empty;

        public AkbankUITestEntry() {
            browser = new BrowserUtils();
            driverPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            WebDriver = browser.SetupChromeDriver(driverPath);
            basePage = new BasePage(WebDriver);
            stepDetails = new AkbankUITest(WebDriver);
        }

        [StepDefinition("Enter Akbank Home Page '(.*)'")]
        public void OpenBrowserWithUrl(string url) {
            WebDriver.Navigate().GoToUrl(url);
        }
        
        [StepDefinition("Scroll down to the bottom of the page")]
        public void ScrollDownBottomOfPage() {
            stepDetails.ScrollDownBottomOfPage();
        }
        
        [StepDefinition("Click on Kredi Hesaplama")]
        public void ClickTextCalculateCredit() {
            stepDetails.ClickTextCalculateCredit();
        }
        
        [StepDefinition("Enter '(.*)' tl in Tutar field")]
        public void SetAmount(string amount) {
            stepDetails.SetAmount(amount);
        }
        
        [StepDefinition("Choose SİGORTASIZ")]
        public void SelectInsuranceType() {
            stepDetails.SelectInsuranceType();
        }

        [StepDefinition("Set vade as '(.*)'")]
        public void SetMonth(string month) {
            stepDetails.SetMonth(month);
        }

        [StepDefinition("Click Hesaplama Detayları")]
        public void ClickButtonDetail() {
            stepDetails.ClickButtonDetail();
        }
        
        [StepDefinition("Check Masraf ve Maliyet Oranları is opened")]
        public void CheckListedCost() {
            stepDetails.CheckListedCost();
        }
        
        [StepDefinition("Click Ödeme Planı")]
        public void ClickButtonPaymentDetail() {
            stepDetails.ClickButtonPaymentDetail();
        }
        
        [StepDefinition("Check Ödeme Planı is opened")]
        public void CheckPaymentDetail() {
            stepDetails.CheckPaymentDetail();
        }

        [StepDefinition("Scroll down on the Ödeme Planı page until 20th is seen")]
        public void ScrollDownForPaymentDetail() {
            stepDetails.ScrollDownForPaymentDetail();
        }

        [AfterScenario]
        public void AfterScenario() {
            WebDriver.Quit();
        }
    }
}


