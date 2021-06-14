Feature: Put and Delete Scenarios
	User should be able to change his/her account properties via Rest API

Background: 
	Given User is already created

@PUTScenarioSuccess
Scenario: User Changes Email Address Successfully
	And Request configures as PUT
	And existent UserID is set
	And authorization bearer token is set
	And valid email parameters are set
	When PUT request is executed
	Then the http response should be '200'


@PUTScenaioFail
Scenario: User gets a "resource not found" response when sending non-existent user id
	And Request configures as PUT
	And Non-existent UserID is set
	And authorization bearer token is set
	And valid email parameters are set
 	When PUT request is executed
	Then the http response should be '404'

@PUTScenaioFail
Scenario: User gets "Authentication failed" response when sending invalid bearer token
	And Request configures as PUT
	And existent UserID is set
	And authorization invalid bearer token is set
	And valid email parameters are set
 	When PUT request is executed
	Then the http response should be '401'

@DELScenarioSuccess
Scenario: User Deletes His/Her Account Successfully
	And Request configures as DEL
	And existent UserID is set
	And authorization bearer token is set
	When DEL request is executed
	Then the http response should be '204'

@DELScenarioFail
Scenario: User gets "Authentication failed" response when sending invalid bearer token for Delete Request
	And Request configures as DEL
	And existent UserID is set
	And authorization invalid bearer token is set
	When DEL request is executed
	Then the http response should be '401'

@DELScenarioFail
Scenario: User gets "resource not found" response when sending non-existent user id for Delete Request
	And Request configures as DEL
	And Non-existent UserID is set
	And authorization bearer token is set
	When DEL request is executed
	Then the http response should be '404'