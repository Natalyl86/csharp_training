﻿using NUnit.Framework;
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
    public class TestBase
    {
        protected ApplicationManager app;
        
        [SetUp]
        public void SetupTest()
        {
           app = new ApplicationManager();
           app.Navigator.GotoHomePage();
           app.Auth.Login(new AccountData("admin", "secret"));
        }

        [TearDown]
        public void TeardownTest()
        {
            app.Stop();
        }
       
        
        
    }
}