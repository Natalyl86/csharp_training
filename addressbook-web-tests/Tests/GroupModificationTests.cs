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
    public class GroupModificationTests : AuthTestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            int groupIndex = 5;
            app.Groups.EnsureRequiredNumberOfGroups(groupIndex+1);
            GroupData newData = new GroupData("Modified", null, null);
            app.Groups.Modify(groupIndex, newData);
        }
    }
}
