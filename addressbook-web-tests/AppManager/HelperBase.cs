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
    public class HelperBase
    {
        protected IWebDriver driver;
        public ApplicationManager manager;

        public HelperBase (ApplicationManager manager)
        {
            this.manager = manager;
            driver = manager.Driver;
        }
    }
}