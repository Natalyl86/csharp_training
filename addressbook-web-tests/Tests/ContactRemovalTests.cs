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
    public class ContactRemovalTests : AuthTestBase
    {
        [Test]
        public void ContactRemovalTest()
        {
            int contactIndex = 2;
            app.Contacts.EnsureRequiredNumberOfContacts(contactIndex);
            List<ContactData> oldContacts = app.Contacts.GetContactList();
            app.Contacts.Delete(contactIndex);
            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts.RemoveAt(contactIndex);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
