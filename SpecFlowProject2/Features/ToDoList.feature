Feature: To do list 

@ui
Scenario: Verify that a user can create a new task with a valid title 
	Given User opens the page in browser
	And User adds the task 'to plan activities'
	Then User able to added task in the to do list