Feature: PostScenarios
	User should be able to create an account/user via Rest API


Background: 
	Given request configured as POST
	

@POSTScenarioSuccessfull
Scenario: User creates an account successfully
	And authorization token is set
	And valid body parameters are set
	When Post is executed
	Then the response code should be 201

@POSTScenarioFail
Scenario: User gets an authentication error when missing info is sent
	And authorization token is incorrectly set
	And valid body parameters are set
	When Post is executed
	Then the response code should be 401

@POSTScenarioFail
Scenario: User gets an error when unexpected gender info is sent
	And authorization token is set
	And invalid body parameters are set
	| gender        | status       |
	|InvalidGender  |DeacActive    |
	When Post is executed
	Then the response code should be 422