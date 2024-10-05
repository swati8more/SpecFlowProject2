using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SpecFlowProject2.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;

namespace SpecFlowProject2.Pages
{
    internal class ToDoListPage : ExtentReport
    {
        IWebDriver driver;
        String url = "https://todomvc.com/examples/react/dist/#/";
        private readonly By addTask = By.Id("todo-input");
        private readonly By viewTask = By.XPath("//*[@data-testid='todo-item-label']");

        public ToDoListPage(IWebDriver driver)
        {
            this.driver = driver;
        }
        public void initializeDriver()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }
        public void GotoPage()
        {
            driver.Url = url;
        }
        public void TearDownBrowser()
        {
            driver.Quit();
        }
        public void addTaskInList(string taskInList)
        {
            IWebElement addTaskElement = driver.FindElement(addTask);
            addTaskElement.SendKeys(taskInList);
            addTaskElement.SendKeys(Keys.Enter);
        }

        public bool viewTaskInTheList()
        {
            IWebElement addTaskElement = driver.FindElement(viewTask);
            string taskInList = addTaskElement.Text;
            bool isPresent = addTaskElement.Displayed;
            return isPresent;
        }
    }
}
