Feature: To do list 

Background: User laned on page
	Given User opens the page in browser
#TP-positive scenarios
@ui @TP_01
Scenario: TP_01:Verify that a user can create a new task with a valid title 
	And User adds the task 'to plan activities'
	Then User able to see added task in the to do list

@ui @TP_02
Scenario: TP_02:Verify that a clicking task user able to mark task as completed
	And User adds the task 'to plan activities'
	Then User able to see added task in the to do list
	And User clicks on the task to mark as complete
	Then User able to see task under completed link

@ui @TP_03
Scenario: TP_03:Verify that after clicking on clear completed tasks are cleared from the list
	And User adds the task 'to plan activities'
	Then User able to see added task in the to do list
	And User clicks on the task to mark as complete
	Then User able to see task under completed link
	And User clicks on clear completed link
	Then All tasks are cleared in the list

@ui @TP_04
Scenario: TP_04:Verify that a user can see the no of items in the list
	And User adds the task 'to plan activities'
	Then User able to see added task in the to do list
	Then User can see the no of items left in the left bottom '1 item left!'

#TN-negative scenarios
@ui @TN_01
Scenario: TN_01:Verify that a user is not able to add task with single character
	And User adds the task 't'
	Then User is not able to add the task

@ui @TN_02
Scenario: TN_02:Verify that a making completed task again active and can see in the active list
	And User adds the task 'to plan activities'
	Then User able to see added task in the to do list
	And User clicks on the task to mark as complete
	Then User able to see task under completed link
	And User again clicks on the task to mark as complete
	Then User able to see task as active again in the active list

@ui @TN_03
Scenario: TN_03:Verify that trying to clear completed tasks without making tasks as completed
	And User adds the task 'to plan activities'
	Then User able to see added task in the to do list
	And User clicks on clear completed link
	Then The task is not cleared from the list

@ui @TN_04
Scenario: TN_04: Verify that upon clicking on task it shows 0 items left in the list
	And User adds the task 'to plan activities'
	Then User able to see added task in the to do list
	And User clicks on the task to mark as complete
	Then User can see the no of items left in the left bottom as '0 items left!'