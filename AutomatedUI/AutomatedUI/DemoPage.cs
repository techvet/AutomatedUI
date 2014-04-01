using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using RobustHaven.IntegrationTests.KendoExtensions;
using RobustHaven.IntegrationTests.SeleniumExtensions;

namespace AutomatedUI
{
    public class DemoPage
    {
        public static string Url = "http://demos.telerik.com/kendo-ui/web/overview/index.html";

        public KendoGrid kendoGrid
        {
            get { return GetGridById("grid"); }
        }

        private IWebElement TryGetDemoTitleElement(string demoType)
        {
            int count = 0;
            var demoTitle = Browser.DriverContext.FindElement(Browser.Driver, By.CssSelector("h1#exampleTitle strong"));
            while (count < 10)
            {
                if (!demoTitle.Text.Contains(demoType))
                {
                    Thread.Sleep(500);
                    demoTitle = Browser.DriverContext.FindElement(Browser.Driver, By.CssSelector("h1#exampleTitle strong"));
                    count++;
                }
                else
                {
                    break;
                }
            }
            return demoTitle;
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
            var demoElement = TryGetDemoTitleElement(demoType);
            if (demoElement.Text.Contains(demoType))
            {
                return true;
            }
            return false;
        }

        public void ClickDemoLink(string demoType)
        {
            var demoLink = Browser.DriverContext.FindElement(Browser.Driver, By.LinkText(demoType));
            demoLink.Click();
        }

        public KendoGrid GetGridById(string gridId)
        {
            var kendoGrid = new KendoGrid(Browser.Driver as IWebDriver, Browser.Driver.FindElement(By.Id(gridId)));
            return kendoGrid;
        }

        public void EditInlineGridProductName(string prodName)
        {
            Browser.DriverContext.FindElement(Browser.Driver, By.LinkText("Inline editing")).Click();
            Browser.DriverContext.FindElement(Browser.Driver,
                By.XPath("/html/body/div[4]/div[2]/div[2]/div[2]/div/div/div[3]/table/tbody/tr/td[5]/a")).Click();
            var input = Browser.Driver.FindElement(
                By.ClassName("k-textbox"));
            Actions builder = new Actions(Browser.DriverContext);
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
