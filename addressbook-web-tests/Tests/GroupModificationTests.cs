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
    public class GroupModificationTests : AuthTestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            int groupIndex = 5;
            app.Groups.EnsureRequiredNumberOfGroups(groupIndex+1);
            GroupData newData = new GroupData("Modified", null, null);
            List<GroupData> oldGroups = app.Groups.GetGroupsList();
            app.Groups.Modify(groupIndex, newData);
            List<GroupData> newGroups = app.Groups.GetGroupsList();
            oldGroups[groupIndex].Name = newData.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);


        }
    }
}
