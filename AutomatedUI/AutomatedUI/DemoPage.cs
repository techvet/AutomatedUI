using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
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

        public void EditInlineGridProductName()
        {
            Browser.Driver.FindElement(By.LinkText("Inline editing")).Click();
            var tableRow = kendoGrid.GetTableRowByModelId(1);
            var edit = tableRow.FindElement(By.LinkText("Edit"));
            edit.Click();
            tableRow.FindElement(By.ClassName("k-textbox")).Click();
            tableRow.FindElement(By.ClassName("k-textbox")).SendKeys("Chai2");
            tableRow.FindElement(By.ClassName("k-textbox")).Click();
            Thread.Sleep(1000);

            var scriptExec = (IWebDriver) Browser.Driver;
            IJavaScriptExecutor js = (IJavaScriptExecutor) Browser.Driver;
            js.ExecuteScript(@"$(""#grid"").data(""kendoGrid"").saveRow();");
            tableRow.FindElement(By.LinkText("Update")).Click();
        }

        public bool CanEditProductName(string prodName)
        {
            EditInlineGridProductName();
            var tableRow = kendoGrid.GetTableRowByModelId(1);
            if (prodName == tableRow.FindElement(By.CssSelector("td")).Text)
            {
                return true;
            }
            return false;
        }


    }
}
