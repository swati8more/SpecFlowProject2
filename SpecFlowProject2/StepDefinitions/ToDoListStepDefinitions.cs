using NUnit.Framework;
using SpecFlowProject2.Pages;
using SpecFlowProject2.Specs.Drivers;

namespace SpecFlowProject2.StepDefinitions
{
    [Binding]
    public class ToDoListStepDefinitions
    {
        private readonly ToDoListPage _toDoListPageObject;
        public ToDoListStepDefinitions(BrowserDriver browserDriver)
        {
            _toDoListPageObject = new ToDoListPage(browserDriver.Current);
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
        }

        [Then(@"User able to added task in the to do list")]
        public void ThenUserAbleToAddedTaskInTheToDoList()
        {
            Assert.IsTrue(_toDoListPageObject.viewTaskInTheList());
        }
    }
}
