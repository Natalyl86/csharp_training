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
            if (driver.Url == baseURL)
            {
                return;
            }
            driver.Navigate().GoToUrl(baseURL);
        }

        public void GotoGroupsPage()
        {
            if (driver.Url == baseURL + "/group.php"
                && isElementPresent(By.Name("new")))
            {
                return;
            }
                driver.FindElement(By.LinkText("groups")).Click();
            
        }
        public void GotoContactCreationPage()
        {
            driver.FindElement(By.LinkText("add new")).Click();
        }
        public void ReturnToHomePage()
        {
            driver.FindElement(By.LinkText("home")).Click();
        }
    }
}
