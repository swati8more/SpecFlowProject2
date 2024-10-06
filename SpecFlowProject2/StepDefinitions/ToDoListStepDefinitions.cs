using NUnit.Framework;
using OpenQA.Selenium;
using SpecFlowProject2.Pages;

namespace SpecFlowProject2.StepDefinitions
{
    [Binding]
    public class ToDoListStepDefinitions
    {
        private readonly ToDoListPage _toDoListPageObject;
        
        public ToDoListStepDefinitions(IWebDriver driver)
        {
            _toDoListPageObject = new ToDoListPage(driver);
        }

        [Given(@"User opens the page in browser")]
        public void GivenUserOpensThePageInBrowser()
        {
            _toDoListPageObject.GotoPage();
        }

        [Given(@"User adds the task '([^']*)'")]
        public void GivenUserAddsTheTask(string tasks)
        {
            _toDoListPageObject.addTaskInList(tasks);
            ScenarioContext.Current["task"] = tasks;
        }

        [Then(@"User able to see added task in the to do list")]
        [Then(@"User able to see task under completed link")]
        public void ThenUserAbleToSeeAddedTaskInTheToDoList()
        {
            var value = ScenarioContext.Current["task"];
            string var = value.ToString();
            Assert.AreEqual(_toDoListPageObject.viewTaskInTheList(var), var);
        }

        [Then(@"User clicks on the task to mark as complete")]
        public void ThenUserClicksOnTheTaskToMarkAsComplete()
        {
            var value = ScenarioContext.Current["task"];
            string var=value.ToString();
            _toDoListPageObject.userClicksOnTheTask(var);
        }

        [Then(@"User clicks on clear completed link")]
        public void ThenUserClicksOnClearCompletedLink()
        {
            _toDoListPageObject.userClicksOnTheClearCompletedTasks();
        }

        [Then(@"All tasks are cleared in the list")]
        public void ThenAllTasksAreClearedInTheList()
        {
            Assert.IsTrue(_toDoListPageObject.verifyThatTasksAreRemoved());
        }

        [Then(@"User can see the no of items left in the left bottom '([^']*)'")]
        [Then(@"User can see the no of items left in the left bottom as '([^']*)'")]
        public void ThenUserCanSeeTheNoOfItemsLeftInTheLeftBottom(string Noitems)
        {
           Assert.AreEqual(_toDoListPageObject.userCanSeeTheTotalItemsLeft(),Noitems);
        }

        [Then(@"User is not able to add the task")]
        public void ThenUserIsNotAbleToAddTheTask()
        {
            Assert.IsTrue(_toDoListPageObject.verifyThatTaskIsNotAdded());
        }

        [Then(@"User able to see task as active again in the active list")]
        public void ThenUserAbleToSeeTaskAsActiveAgainInTheActiveList()
        {
            _toDoListPageObject.userClicksOnActiveLink();
            var value = ScenarioContext.Current["task"];
            string var = value.ToString();
            Assert.AreEqual(_toDoListPageObject.viewTaskInTheList(var), var);
        }

        [Then(@"User again clicks on the task to mark as complete")]
        [Then(@"The task is not cleared from the list")]
        public void ThenUserAgainClicksOnTheTaskToMarkAsComplete()
        {
            var value = ScenarioContext.Current["task"];
            string var = value.ToString();
            _toDoListPageObject.addTaskInList(var);
        }

    }
}
