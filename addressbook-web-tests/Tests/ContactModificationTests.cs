using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
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
            List<ContactData> oldContacts = app.Contacts.GetContactList();
            app.Contacts.Modify(contactIndex, newContactData);
            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts[contactIndex].Firstname = newContactData.Firstname;
            oldContacts[contactIndex].Lastname = newContactData.Lastname; //
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
            
        }
    }
}

