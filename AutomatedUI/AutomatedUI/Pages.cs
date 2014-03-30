using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.PageObjects;

namespace AutomatedUI
{
    public static class Pages
    {
        public static HomePage Homepage
        {
            get
            {
                var homePage = new HomePage();
                PageFactory.InitElements(Browser.Driver, homePage);
                return homePage;
            }
        }

        public static DemoPage DemoPage
        {
            get
            {
                var demoPage = new DemoPage();
                PageFactory.InitElements(Browser.Driver, demoPage);
                return demoPage;
            }
        }
    }
}
