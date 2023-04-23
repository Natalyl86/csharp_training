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
    public class ContactHelper : HelperBase
    {
        public ContactHelper(ApplicationManager manager) : base(manager)
        {
        }
        public ContactHelper Create(ContactData contact)
        {
            manager.Navigator.GotoContactCreationPage();
            FillContactForm(contact);
            SubmitNewContact();
            manager.Navigator.ReturnToHomePage();
            return this;
        }

        public ContactHelper Modify(int c, ContactData newContactData)
        {
            if (!isElementPresent(By.Name("selected[]")))
            {
                ContactData contact = new ContactData("Name", "Last name");
                Create(contact);
            }
            SelectContact(c);
            FillContactForm(newContactData);
            SubmitContactUpdate();
            manager.Navigator.ReturnToHomePage();
            return this;
        }
        public ContactHelper Delete (int del)
        {
            if (!isElementPresent(By.Name("selected[]")))
            {
                ContactData contact = new ContactData("Name", "Last name");
                Create(contact);
            }
            SelectContact(del);
            DeleteContact();
            manager.Navigator.ReturnToHomePage();
            return this;
        }

        public ContactHelper DeleteContact()
        {
            driver.FindElement(By.CssSelector("[value='Delete']")).Click();
            return this;
        }

        private ContactHelper SubmitContactUpdate()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }

        public ContactHelper SelectContact(int c)
        {
            IWebElement e = driver.FindElements(By.ClassName("center"))[c];
            e.Click();
            return this;
        }

        public void SubmitNewContact()
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/input[21]")).Click();
        }
        public void FillContactForm(ContactData contact)
        {
            driver.FindElement(By.Name("firstname")).Click();
            driver.FindElement(By.Name("firstname")).Clear();
            driver.FindElement(By.Name("firstname")).SendKeys(contact.Firstname);
            driver.FindElement(By.Name("lastname")).Click();
            driver.FindElement(By.Name("lastname")).Clear();
            driver.FindElement(By.Name("lastname")).SendKeys(contact.Lastname);
        }
    }
}
