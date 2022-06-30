using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMDB.Collections;
using OpenQA.Selenium.Chrome;
using IMDB.Page;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IMDB.Test

    {
    [TestClass]
    public class ImdbTest : BaseCollections
    {
        [TestInitialize]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(Url);
        }



        [TestMethod]
        public void Startup()

        {

            try
            {

                Imdbpage Driver = new Imdbpage(driver);
                Driver.SearchMovie("The Circus");
                Driver.CheckMovie_1();
                Driver.Photos();
                Driver.CheckLinks();

            }
            catch (Exception)
            {
                throw;
            }


        }
        [TestMethod]
        public void enup()

        {

            try
            {

                Imdbpage Driver = new Imdbpage(driver);
                Driver.SearchMovie("The Jazz Singer");
                Driver.CheckMovie_2();
                Driver.Photos();
                Driver.CheckLinks();

            }
            catch (Exception)
            {
                throw;
            }


        }
        [TestCleanup]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}     

