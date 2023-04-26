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
    public class GroupRemovalTests : AuthTestBase
    {
        [Test]
        public void GroupRemovalTest()
        {
            int groupIndex = 5;
            app.Groups.EnsureRequiredNumberOfGroups(groupIndex+1);
            List<GroupData> oldGroups = app.Groups.GetGroupsList();
            app.Groups.Remove(groupIndex);
            List<GroupData> newGroups = app.Groups.GetGroupsList();
            oldGroups.RemoveAt(groupIndex);
            Assert.AreEqual(oldGroups, newGroups);
        }
                  
    }
}
