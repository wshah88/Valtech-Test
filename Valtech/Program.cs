using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System.Text.RegularExpressions;

//Valtech Test by Wasim Shah on 26th January 2017
namespace Valtech
{
    class Program
    {
        static void Main(string[] args)
        {
            //Maximize the chrome window upon start
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            IWebDriver driver = new ChromeDriver(options);
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            driver.Url = "http://www.valtech.com";            

            //Assert if 'LATEST NEWS' is present
            var latestNews = driver.FindElement(By.CssSelector("div.news-post__listing-header > header.block-header > h2.block-header__heading")).Text;
            Console.WriteLine(latestNews);
            Assert.AreEqual("LATEST NEWS", latestNews);
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));            

            //Work / Cases
            driver.FindElement(By.CssSelector("li.navigation__menu__item > a > span")).Click();
            //driver.FindElement(By.XPath("//*[@id='navigationMenuWrapper']/div/ul/li[1]/a/span")).Click();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            var work = driver.FindElement(By.CssSelector("h1")).Text;
            Assert.AreEqual("Work", driver.FindElement(By.CssSelector("h1")).Text);
            Console.WriteLine(work);

            //Services
            driver.FindElement(By.XPath("//div[@id='navigationMenuWrapper']/div/ul/li[2]/a/span")).Click();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            var services = driver.FindElement(By.CssSelector("h1")).Text;
            Assert.AreEqual("Services", driver.FindElement(By.CssSelector("h1")).Text);
            Console.WriteLine(services);

            //Careers / Jobs
            driver.FindElement(By.XPath("//div[@id='navigationMenuWrapper']/div/ul/li[5]/a/span")).Click();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            var careers = driver.FindElement(By.CssSelector("h1")).Text;
            Assert.AreEqual("Careers", driver.FindElement(By.CssSelector("h1")).Text);
            Console.WriteLine(careers);

            //Navigate to Investors
            //driver.FindElement(By.CssSelector("li.navigation__menu__item > a > span")).Click();
            driver.FindElement(By.XPath("//div[@id='navigationMenuWrapper']/div/ul/li[6]/a/span")).Click();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            var offices = driver.FindElement(By.LinkText("Valtech Offices")).Text;
            Assert.AreEqual("Valtech Offices", driver.FindElement(By.LinkText("Valtech Offices")).Text);
            Console.WriteLine(offices);

            //Navigate to offices page
            driver.FindElement(By.LinkText("Valtech Offices")).Click();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));

            //Count the number of offices and output the number to the console
            List<string> matchingLinks = new List<string>();
            IReadOnlyCollection<IWebElement> links = driver.FindElements(By.ClassName("office__heading"));
            var NoOfOffices = links.Count;
            Console.WriteLine("There are " + NoOfOffices + " Valtech offices in total"); 





        }


    }
}
