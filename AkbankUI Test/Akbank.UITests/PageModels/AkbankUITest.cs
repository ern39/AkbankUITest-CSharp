using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Collections.Generic;

namespace Akbank.UITests.PageModels {
    public class AkbankUITest : BasePage {
        private IWebDriver webDriver;

        public AkbankUITest(IWebDriver webDriver) : base(webDriver) {
            this.webDriver = webDriver;
        }

        #region WebElements
        [FindsBy(How = How.Id, Using = "ctl00_ucFooterMenu_rptMain_ctl02_rptChild_ctl00_linkChild")]
        public IWebElement txtCalculateCredit;

        [FindsBy(How = How.ClassName, Using = "open-tooltip")]
        public IWebElement txtCalculateDetails;
        
        [FindsBy(How = How.XPath, Using = "//*[@id='ctl00_ctl43_g_26e16d7b_ef03_46b5_a437_2bc263507602']/div[1]/div/div[2]/div[1]/div/div[1]/div/div[2]/div[3]/a[2]")]
        public IWebElement btnDecrease;
        
        [FindsBy(How = How.Id, Using = "t-credit-price")]
        public IWebElement txtAmount;
        
        [FindsBy(How = How.XPath, Using = "//label[@for='insuredType2']")]
        public IWebElement rbInsurance;
        
        [FindsBy(How = How.XPath, Using = "//div[@class='tabs-content oran active'][@id='content-1']")]
        public IWebElement txtCostRates;
        
        [FindsBy(How = How.Id, Using = "accordion2")]
        public IWebElement txtPaymentPlan;
        
        [FindsBy(How = How.XPath, Using = "//div[@class='tabs-content plan active jspScrollable'][@id='content-2']")]
        public IWebElement txtListedPaymentDetail;
        
        [FindsBy(How = How.XPath, Using = "//*[@id='ctl00_ctl43_g_26e16d7b_ef03_46b5_a437_2bc263507602']/div[1]/div/div[2]/div[1]/div/div[1]/div/div[2]/div[1]")]
        public IWebElement txtMonth;

        [FindsBy(How = How.XPath, Using = "//*[@id='content-2']/div/div[1]/table/tbody/tr[*]/td[1]")]
        public IList<IWebElement> txtListPaymentPlan;

        #endregion

        public void ScrollDownForPaymentDetail()
        {
            foreach (IWebElement element in txtListPaymentPlan)
            {
                ScrollInToView(element);
                string elementMonth = element.Text.Trim();
                if (elementMonth == "20")
                {
                    break;
                }
            }
        }

        public void ScrollDownBottomOfPage() {
            ScrollInToView(txtCalculateCredit);
        }
        
        public void ClickTextCalculateCredit() {
            ClickElement(txtCalculateCredit);
        }
        
        public void SetAmount(string amount) {
            ClickElement(txtAmount);
            Clear(txtAmount);
            SetText(txtAmount, amount);
        }

        public void SelectInsuranceType() {
            ClickElement(rbInsurance);
        }

        public void ClickButtonDetail() {
            ClickElement(txtCalculateDetails);
        }

        public void ClickButtonPaymentDetail() {
            ClickElement(txtPaymentPlan);
        }

        public void CheckListedCost() {
            Wait(15, txtCostRates);
            if (!txtCostRates.Displayed) {
                Assert.Fail("Cost Rates cannot be loaded!");
            }
        }
        
        public void CheckPaymentDetail() {
            Wait(15, txtListedPaymentDetail);
            if (!txtListedPaymentDetail.Displayed) {
                Assert.Fail("Listed Payment Detail cannot be loaded!");
            }
        }

        public void SetMonth(string month) {
            for (int i = 0; i < 8; i++) {
                ClickElement(btnDecrease);
            }
        }
    }
}
