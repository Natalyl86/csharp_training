using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;

namespace addressbook_web_tests
{
    [TestFixture]
    public class GroupCreationTests : AuthTestBase
    {
        [Test]
        public void GroupCreationTest()
        {
            GroupData group = new GroupData("aaa");
            List<GroupData> oldGroups = app.Groups.GetGroupsList();
            app.Groups.Create(group);
            List<GroupData> newGroups = app.Groups.GetGroupsList();
            Assert.AreEqual(oldGroups.Count + 1, newGroups.Count);
        }

        [Test]
        public void EmptyGroupCreationTest()
        {
            GroupData group = new GroupData("");
            List<GroupData> oldGroups = app.Groups.GetGroupsList();
            app.Groups.Create(group);
            List<GroupData> newGroups = app.Groups.GetGroupsList();
            Assert.AreEqual(oldGroups.Count + 1, newGroups.Count);
        }
    }
}

