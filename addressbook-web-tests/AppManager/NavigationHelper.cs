using NUnit.Framework;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;

namespace addressbook_web_tests
{
    public  class NavigationHelper : HelperBase
    {
        private string baseURL;

        public NavigationHelper (ApplicationManager manager, string baseURL) :base(manager)
        {
            //this.driver = driver;
            this.baseURL = baseURL;
        }
        public void GotoHomePage()
        {
            driver.Navigate().GoToUrl(baseURL);
        }

        public void GotoGroupsPage()
        {
            driver.FindElement(By.LinkText("groups")).Click();
        }
    }
}
