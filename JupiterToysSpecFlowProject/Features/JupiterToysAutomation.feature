Feature: Jupiter Toys Automation

@HubScenario
Scenario: Hub scenario Jupiter toy automation
	Given the user opens the jupiter toys application
	And the user navigates to the shop tab
	And the user adds following toys to the cart
	| ToyName		| Quantity |
	| KiaToys24		|     2    |
	| Cute Kratos   |     3    |
	Then the user navigates to the cart tab
	And the user validates all the items subprice and total price
	And the user clicks Check Out button
	And the user checks out using same delivery details
	| FieldName    | FieldValue		|
	| First Name   | Shreesh		|
	| Last Name    | Karthi			|
	| Email        | sk30@gmail.com |
	| Phone Number | 0456314971		|
	| Address      | 2, Coppin Close|
	| Suburb       | Hampton Park   |
	| State        | VIC            |
	| Postcode     | 3976           |
	And the user finishes payment with below details
	| Card Number      | Card Type | Name on Card        | Expiry Date | CVV |
	| 1234567812345678 | VISA      | Shreesh Karthikeyan | 08/12       | 340 |
	Then the user verifies the details on the confirm order screen and confirms it
	Then the user finally obtains the order number and payment status
