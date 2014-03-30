using System;
using AutomatedUI;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class UnitTest1
    {
        //[TestMethod]
        //public void Can_Go_To_Homepage()
        //{
        //    Pages.Homepage.Goto();
        //    Assert.IsTrue(Pages.Homepage.IsAt());
        //}

        //[TestMethod]
        //public void CanGo_To_Category()
        //{
        //    Pages.Homepage.Goto();
        //    Pages.Homepage.SelectCategory("Java");
        //    Assert.IsTrue(Pages.Homepage.IsAtCategoryPage("Java"));
        //}

        [TestMethod]
        public void Can_Go_To_Demo_Page()
        {
            Pages.DemoPage.Goto();
            Pages.DemoPage.ClickDemoLink("Grid");
            Assert.IsTrue(Pages.DemoPage.IsAt("Grid"));
        }

        [TestMethod]
        public void Can_Edit_Inline_Grid_Row()
        {
            Pages.DemoPage.Goto();
            Pages.DemoPage.ClickDemoLink("Grid");
            Assert.IsTrue(Pages.DemoPage.CanEditProductName("TestProductName"));
        }

        [TestCleanup]
        public void CleanUp()
        {
            Browser.Close();
        }
    }
}
