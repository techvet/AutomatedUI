using System;
using AutomatedUI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestFixtureSetUp]
        public void Init()
        {
            var driver = Browser.DriverContext;
        }

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
            Assert.IsTrue(Pages.DemoPage.CanEditProductName("TestRow"));
        }

        [TestCleanup]
        public void CleanUp()
        {
            Browser.Close();
        }
    }
}
