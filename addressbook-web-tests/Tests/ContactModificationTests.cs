using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace addressbook_web_tests
{
    [TestFixture]
    public class ContactModificationTests : AuthTestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            int contactIndex = 2;
            app.Contacts.EnsureRequiredNumberOfContacts(contactIndex);
            ContactData newContactData = new ContactData("Contact", "Modified");
            app.Contacts.Modify(contactIndex, newContactData);

        }
    }
}

