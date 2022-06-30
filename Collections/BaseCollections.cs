using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMDB.Collections
{
    public class BaseCollections
    {
        public static IWebDriver driver { get; set; }
        public static string Url = "https://www.imdb.com/";
    }
}
