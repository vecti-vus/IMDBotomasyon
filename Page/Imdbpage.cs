using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMDB.Collections;
using OpenQA.Selenium;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;

namespace IMDB.Page
{
    public class Imdbpage : BaseCollections
    {
        IWebDriver browser;


        By DIRECTOR = By.XPath("//span[@class='ipc-metadata-list-item__label'][contains(text(),'Director')]//following::a[1]");
        By WRITER = By.XPath("//span[@class='ipc-metadata-list-item__label'][contains(text(),'Writer')]//following::a[1]");
        By STARS_1 = By.XPath("//a[@class='ipc-metadata-list-item__label ipc-metadata-list-item__label--link']//following::a[1]");
        By STARS_2 = By.XPath("//a[@class='ipc-metadata-list-item__label ipc-metadata-list-item__label--link']//following::a[2]");
        By STARS_3 = By.XPath("//a[@class='ipc-metadata-list-item__label ipc-metadata-list-item__label--link']//following::a[3]");
        By SEARCH = By.Id("suggestion-search");
        By MOVIE = By.Id("suggestion-search");
        By MOVIE_CLICK = By.Id("react-autowhatever-1--item-0");
        By PHOTOS = By.XPath("//h3[@class='ipc-title__text'][contains(text(),'Photos')]");
        By PHOTOS_1 = By.XPath("//div[@id='media_index_thumbnail_grid']//a");
        By WRITER_1 = By.XPath("//span[@class='ipc-metadata-list-item__label'][contains(text(),'Writer')]//following::a[2]");
        By WRITER_2 = By.XPath("//span[@class='ipc-metadata-list-item__label'][contains(text(),'Writer')]//following::a[3]");




        public Imdbpage(IWebDriver driver)
        {
            this.browser = driver;
        }
        public void SearchMovie(string t1)
        {
            Thread.Sleep(2000);
            browser.FindElement(SEARCH).Click();
            Thread.Sleep(2000);
            browser.FindElement(MOVIE).SendKeys(t1);
            Thread.Sleep(2000);
            browser.FindElement(MOVIE_CLICK).Click();
            Thread.Sleep(2000);
        }
        public void CheckMovie_1()
        {
            Thread.Sleep(2000);
            string confimation = browser.FindElement(DIRECTOR).Text;
            Assert.AreEqual("Charles Chaplin", confimation);
            string confimation_1 = browser.FindElement(WRITER).Text;
            Assert.AreEqual("Charles Chaplin", confimation_1);
            string confimation_2 = browser.FindElement(STARS_1).Text;
            Assert.AreEqual("Charles Chaplin", confimation_2);
            string confimation_3 = browser.FindElement(STARS_2).Text;
            Assert.AreEqual("Merna Kennedy", confimation_3);
            string confimation_4 = browser.FindElement(STARS_3).Text;
            Assert.AreEqual("Al Ernest Garcia", confimation_4);
        }
        public void CheckMovie_2()
        {
            Thread.Sleep(2000);
            string confimation = browser.FindElement(DIRECTOR).Text;
            Assert.AreEqual("Alan Crosland", confimation);
            string confimation_1 = browser.FindElement(WRITER).Text;
            Assert.AreEqual("Samson Raphaelson", confimation_1);
            string confimation_2 = browser.FindElement(WRITER_1).Text;
            Assert.AreEqual("Alfred A. Cohn", confimation_2);
            string confimation_3 = browser.FindElement(WRITER_2).Text;
            Assert.AreEqual("Jack Jarmuth", confimation_3);
            string confimation_4 = browser.FindElement(STARS_1).Text;
            Assert.AreEqual("Al Jolson", confimation_4);
            string confimation_5 = browser.FindElement(STARS_2).Text;
            Assert.AreEqual("May McAvoy", confimation_5);
            string confimation_6 = browser.FindElement(STARS_3).Text;
            Assert.AreEqual("Warner Oland", confimation_6);
        }

        public void Photos()
        {
            Thread.Sleep(2000);
            browser.FindElement(PHOTOS).Click();

        }

        public void CheckLinks()
        {

            IList<IWebElement> links = driver.FindElements(PHOTOS_1);
            foreach (IWebElement link in links)
            {
                var url = link.GetAttribute("href");
                IsLinkWorking(url);
            }
        }

        public static bool IsLinkWorking(string urll)
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(urll);
            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    response.Close();
                    return true;
                }
                else
                    return false;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }



    }

}
