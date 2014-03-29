using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace AutomatedUI
{
    public class HomePage
    {
        public static string Url = "http://pluralsight.com";
        private static string PageTitle = "Pluralsight - Hardcore Dev and IT Training";

        [FindsBy(How = How.LinkText, Using = "Categories")]
        private IWebElement categoryLink;

        public void Goto()
        {
            Browser.Goto(Url);
        }

        public bool IsAt()
        {
            return Browser.Title == PageTitle;
        }

        public void SelectCategory(string catName)
        {
            categoryLink.Click();
            var category = Browser.Driver.FindElement(By.XPath("/html/body/div[2]/div[3]/div[4]/div[2]/div[2]/div[2]/div[2]"));
            category.Click();
        }

        public bool IsAtCategoryPage(string catName)
        {
            var catPage = new CatPage();
            PageFactory.InitElements(Browser.Driver, catPage);
            return catPage.CatExpanded;
        }
    }

    public class CatPage
    {
        [FindsBy(How = How.CssSelector, Using = "div#java.categoryHeader expanded")]
        private IWebElement catName;

        public bool CatExpanded
        {
            get { return CheckIfExpanded(catName); }
        }

        public bool CheckIfExpanded(IWebElement catName)
        {
            if (catName != null)
            {
                return true;
            }
            return false;
        }
    }
}