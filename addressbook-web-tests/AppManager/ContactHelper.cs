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
            manager.Navigator.GotoHomePage();
            SelectContact(c);
            FillContactForm(newContactData);
            SubmitContactUpdate();
            manager.Navigator.ReturnToHomePage();
            return this;
        }
        public ContactHelper Delete (int del)
        {
            SelectContact(del);
            DeleteContact();
            manager.Navigator.ReturnToHomePage();
            return this;
        }

        public ContactHelper EnsureRequiredNumberOfContacts(int requiredNumber)
        {
            int existingNumber = driver.FindElements(By.Name("selected[]")).Count;
            if (existingNumber < requiredNumber)
            {
                int recordsToCreate = requiredNumber - existingNumber;

                for (int i = 0; i < recordsToCreate; i++)
                {
                    ContactData contact = new ContactData("Name", "Last name");
                    Create(contact);
                }
            }
            return this;
        }

        public ContactHelper DeleteContact()
        {
            driver.FindElement(By.CssSelector("[value='Delete']")).Click();
            return this;
        }

        public List<ContactData> GetContactList()
        {
            List<ContactData> contacts = new List<ContactData>();
            manager.Navigator.GotoHomePage();
            ICollection<IWebElement> elements = driver.FindElements(By.Name("entry"));
            foreach (IWebElement element in elements)
            {
                IList<IWebElement> cells = element.FindElements(By.TagName("td"));
                contacts.Add(new ContactData(cells[2].Text, cells[1].Text));
            }
            return contacts;
        }

        private ContactHelper SubmitContactUpdate()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }

        public ContactHelper SelectContact(int c)
        {
            driver.FindElement(By.XPath("(//img[@alt='Edit'])[" + (c) + "]")).Click();
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
