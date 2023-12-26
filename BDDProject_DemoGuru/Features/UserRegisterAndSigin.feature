Feature: UserRegisterAndSigin

Background: User will be on Homepage


@tag1
Scenario: User Registration and Sigin
	
	When User will click on the Register tab
	Then User will be on register page
	When user will enter first name '<Firstname>'
	And user will enter last name '<Lastname>'
    And user will enter  phone number'<PhoneNumber>'
	And user will enter  email'<Emailid>'
	And user will enter  address'<Address>'
	And user will enter  city'<City>'
	And user will enter  state'<State>'
	And user will enter  country'<Country>'
	And user will enter  pincode'<Pincode>'
	And user will enter  username  '<Username>'
	And user will enter  password  '<Password>'
	And user will enter Confirm password  '<ConfirmPassword>'
	When user click on submit 
	Then user will be on sigin page
	When User will click on sigin
	And  user will enter  usernames  '<Username>'
	And user will enter  password  '<Password>'
	When user click on submit 
	Then user will successfully login into the page

 Examples: 
    | Firstname | Lastname | Emailid        | PhoneNumber | Address    | City  | State  | Country | Pincode | Username | Password    | ConfirmPassword |
    | Amal      | john     | john@gmail.com | 8923456781  | Amal Nivas | Kochi | Kerala | India   | 653595  | Amal     | Password123 | Password123     |
