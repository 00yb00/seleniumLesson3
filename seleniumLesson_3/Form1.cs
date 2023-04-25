using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace seleniumLesson_3
{
    public partial class Form1 : Form
    {
        string url = "https://zionet-selenium.bubbleapps.io/version-test";
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        public void connectUser(string email, string password)
        {
            using (IWebDriver webDriver = new ChromeDriver())
            {
                webDriver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(30);
                webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

                webDriver.Navigate().GoToUrl(url);
                WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));

                IWebElement signUpButton = wait.Until<IWebElement>((a) => { return a.FindElement(By.CssSelector("div[class='clickable-element bubble-element Group baTaGzaS bubble-r-container flex row']")); });
                if (signUpButton != null)
                {
                    signUpButton.Click();
                    IWebElement logInButton = wait.Until<IWebElement>((a) => { return a.FindElement(By.CssSelector("h1[class='bubble-element Text baTaHel clickable-element']")); });
                    if (logInButton != null)
                    {
                        logInButton.Click();
                        string regstionUrl = webDriver.Url;
                        webDriver.FindElement(By.CssSelector("input[placeholder='Email Address']"))
                           .SendKeys(email);
                        webDriver.FindElement(By.CssSelector("input[placeholder='Password']"))
                            .SendKeys(password);
                        IWebElement confirmButton = wait.Until<IWebElement>((a) => { return a.FindElement(By.CssSelector("div[class='bubble-element Text baTaHaMaI bubble-r-vertical-center clickable-element']")); });
                        if (confirmButton != null)
                        {
                            confirmButton.Click();
                            System.Threading.Thread.Sleep(5000);    
                            string currectUrl = webDriver.Url;
                            if (currectUrl == regstionUrl)
                            {
                                Console.WriteLine("error the login fail");
                            }
                            else
                            {
                                Console.WriteLine(" the login sucsses");
                            }
                        }
                    }
                }
            }
        }
            //create new user
            private void button1_Click(object sender, EventArgs e)
            {
                using (IWebDriver webDriver = new ChromeDriver())
                {
                    webDriver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(30);
                    webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

                    webDriver.Navigate().GoToUrl(url);
                    WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));

                    IWebElement signUpButton = wait.Until<IWebElement>((a) => { return a.FindElement(By.CssSelector("div[class='clickable-element bubble-element Group baTaGzaS bubble-r-container flex row']")); });
                    if (signUpButton != null)
                    {
                        //put user info in the regstaion page
                        signUpButton.Click();
                        string regstionUrl = webDriver.Url;
                        webDriver.FindElement(By.CssSelector("input[placeholder='Username']"))
                            .SendKeys("shoval choen");
                        webDriver.FindElement(By.CssSelector("input[placeholder='Email Address']"))
                           .SendKeys("shovalchoen123@gmail.com");
                        webDriver.FindElement(By.CssSelector("input[placeholder='Password']"))
                            .SendKeys("shovalchoen123");
                        webDriver.FindElement(By.CssSelector("input[placeholder='Confirm Password']"))
                             .SendKeys("shovalchoen123");
                        IWebElement confirmButton = wait.Until<IWebElement>((a) => { return a.FindElement(By.CssSelector("div[class='bubble-element Text baTaHaMaI bubble-r-vertical-center clickable-element']")); });
                        if (confirmButton != null)
                        {
                            confirmButton.Click();
                        //check if the regstionUrl and the currect url is the same
                        //it's mean the regstaion fail
                        System.Threading.Thread.Sleep(5000);
                        string currectUrl = webDriver.Url;
                        if (currectUrl == regstionUrl)
                            {
                                Console.WriteLine("error the regstaion fail");
                            }
                            else
                            {
                                Console.WriteLine(" the regstaion sucsses");
                            }

                        }
                    }
                }
            }
            //connect user with the wrong email
            private void button2_Click(object sender, EventArgs e)
            {
                connectUser("shovalchoen000@gmail.com", "shovalchoen123");
            }
            //connect user with wrong password
            private void button3_Click(object sender, EventArgs e)
            {
                connectUser("shovalchoen123@gmail.com", "shovalchoen123456");
            }
            //connect user with right email and password
            private void button4_Click(object sender, EventArgs e)
            {
                connectUser("shovalchoen123@gmail.com", "shovalchoen123");
            }
    }
}
