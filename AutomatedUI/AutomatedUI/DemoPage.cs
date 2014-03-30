using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.PageObjects;
using RobustHaven.IntegrationTests.KendoExtensions;
using RobustHaven.IntegrationTests.SeleniumExtensions;

namespace AutomatedUI
{
    public class DemoPage
    {
        public static string Url = "http://demos.telerik.com/kendo-ui/web/overview/index.html";


        [FindsBy(How = How.CssSelector, Using = "h1#exampleTitle strong")]
        private IWebElement demoTitlElement;

        public KendoGrid kendoGrid
        {
            get { return GetGridById("grid"); }
        }

        public void Goto()
        {
            Browser.Goto(Url);
        }

        public void Goto(string demoType)
        {
            Browser.Goto(Url);

        }

        public bool IsAt(string demoType)
        {
            demoType = demoType + " /";
            if (demoType == demoTitlElement.Text)
            {
                return true;
            }
            return false;
        }

        public void ClickDemoLink(string demoType)
        {
            var demoLink = Browser.Driver.FindElement(By.LinkText(demoType));
            demoLink.Click();
        }

        public KendoGrid GetGridById(string gridId)
        {
           var kendoGrid = new KendoGrid(Browser.Driver as IWebDriver, Browser.Driver.FindElement(By.Id(gridId)));
            return kendoGrid;
        }

        public void EditInlineGridProductName(string prodName)
        {
            Thread.Sleep(1000);
            Browser.Driver.FindElement(By.LinkText("Inline editing")).Click();
            Thread.Sleep(1000);
            //var tableRow = kendoGrid.GetTableRowByModelId(1);
            //var edit = tableRow.FindElement(By.XPath("/html/body/div[4]/div[2]/div[2]/div[2]/div/div/div[3]/table/tbody/tr/td[5]/a"));
            //edit.Click();
            //tableRow.FindElement(By.Name("ProductName")).SendKeys("BLAH");
            //tableRow.FindElement(
            //    By.CssSelector("span.k-link > span.k-icon.k-i-arrow-s")).Click();
            ////tableRow.FindElement(
            ////    By.CssSelector("input.k-formatted-value.k-input")).Clear();
            ////tableRow.FindElement(
            ////    By.CssSelector("input.k-formatted-value.k-input")).SendKeys("20");
            //tableRow.FindElement(By.LinkText("Update")).Click();

            Browser.Driver.FindElement(
                By.XPath("/html/body/div[4]/div[2]/div[2]/div[2]/div/div/div[3]/table/tbody/tr/td[5]/a")).Click();
            var input = Browser.Driver.FindElement(
                By.ClassName("k-textbox"));
            Actions builder = new Actions((IWebDriver)Browser.Driver);
            builder.MoveToElement(input).DoubleClick(input).Build().Perform();
            input.Clear();
            input.SendKeys(prodName);
            Browser.Driver.FindElement(By.LinkText("Update")).Click();

        }

        public bool CanEditProductName(string prodName)
        {
            EditInlineGridProductName(prodName);
            var tableRow = kendoGrid.GetTableRowByModelId(1);
            if (prodName == tableRow.FindElement(By.CssSelector("td")).Text)
            {
                return true;
            }
            return false;
        }


    }
}
