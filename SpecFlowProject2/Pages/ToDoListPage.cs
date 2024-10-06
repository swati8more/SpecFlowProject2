using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SpecFlowProject2.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;

namespace SpecFlowProject2.Pages
{
    internal class ToDoListPage
    {
        public IWebDriver driver;
        private const String url = "https://todomvc.com/examples/react/dist/#/";
        private readonly By addTask = By.Id("todo-input");
        private readonly By viewTask = By.XPath("//*[@data-testid='todo-item-label']");
        private readonly By completedLink = By.XPath("//*[@href='#/completed']");
        private readonly By clearCompletedLink = By.XPath("//*[@class='clear-completed']");
        private readonly By toDoItems = By.XPath("//*[@class='todo-count']");
        private readonly By activeTasks = By.XPath("//*[@href='#/active']");

        public ToDoListPage(IWebDriver driver_)
        {
            driver = driver_;
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

        public string viewTaskInTheList(string var)
        {
            IWebElement addTaskElement = driver.FindElement(viewTask);
            string taskInList = addTaskElement.Text;
            return taskInList;
        }

        public void userClicksOnTheTask(string taskInList)
        {
            By viewTask = By.XPath("//*[text()='"+taskInList+"']/preceding-sibling::input");
            driver.FindElement(viewTask).Click();
        }

        public void userClicksOnCompleteLink() {
            IWebElement taskAsCompleted = driver.FindElement(completedLink);
            taskAsCompleted.Click();
        }

        public void userClicksOnTheClearCompletedTasks()
        {
            IWebElement clearCompleted = driver.FindElement(clearCompletedLink);
            clearCompleted.Click();
        }

        public bool verifyThatTasksAreRemoved()
        {
            IWebElement toDoCount;
            try
            {
                toDoCount = driver.FindElement(toDoItems);
                return false;
            }
            catch (NoSuchElementException exception)
            {
                return true;
            }
        }

        public string userCanSeeTheTotalItemsLeft()
        {
            IWebElement toDoCount = driver.FindElement(toDoItems);
            string itemS=toDoCount.Text;
            return itemS;
        }

        public bool verifyThatTaskIsNotAdded()
        {
            try
            {
                IWebElement addTaskElement = driver.FindElement(viewTask);
                return false;
            }
            catch (NoSuchElementException)
            {
                return true;
            }
        }

        public void userClicksOnActiveLink()
        {
            IWebElement activeTask= driver.FindElement(activeTasks);
            activeTask.Click();
        }
    }
}
