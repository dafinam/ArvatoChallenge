Feature: Currency Conversion Validator

Scenario: Verify that two currencies and amount convert successfully with data from API
	Given I have initialized API service call for Currency Conversion API
	And I want to convert <amount> <from> to <to>
	When Curency Conversion API is Invoked for given data
	Then Verify that the response after conversion is valid
	Examples: 
	| amount | from | to  |
	| 1587   | USD  | NOK |
	| 169000 | NOK  | EUR |
	| 89000  | NOK  | SEK |

Scenario: Verify that API returns error for unknown currencies
	Given I have initialized API service call for Currency Conversion API
	And I want to convert <amount> <from> to <to>
	When Curency Conversion API is Invoked for given data
	Then Verify that the response after conversion is invalid
	Examples: 
	| amount | from | to  |
	| 1587   | USD  | HELLO |
	| -200 | NOK  | EUR |
