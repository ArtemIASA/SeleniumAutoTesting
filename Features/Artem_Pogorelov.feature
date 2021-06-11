Feature: EpamTest

@search
Scenario: Search 
	Given I am at "https://www.epam.com/" page
	When I write "automation" as keyword and press search
	Then the "automation" search results should be on the screen

@contactPage
Scenario: Make an inquiry
	Given I am at "https://www.epam.com/about/who-we-are/contact" page
	When I write "1234" as name and press submit
	Then I get error message 

@changeLang
Scenario: Change region and language
	Given I am at "https://www.epam.com/" page
	When I click on "Россия(Русский)" option 
	Then I get redirect to "https://www.epam-group.ru"

@servicesPage
Scenario: Open page
	Given I am at "https://www.epam.com/" page
	When I click on "Services" page
	Then I get redirect to "https://www.epam.com/services"

@searchJobs
Scenario: Search jobs by skills
	Given I am at "https://www.epam.com/careers" page
	And I choose "Software Engineering/Technology" skills
	When I click on "Find" button
	Then I get Software Engineering jobs

@officeInfo
Scenario: Open office info
	Given I am at "https://www.epam.com" page
	When I click on "Mexico" image
	Then I get "Mexico" office info

@openSocial
Scenario: Open social media page
	Given I am at "https://www.epam.com/" page
	When I choose "instagram" icon 
	Then I get redirect to "https://www.instagram.com/epamsystems/"

@registerPage
Scenario: Open page for event 
	Given I am at "https://www.epam.com/about/who-we-are/events" page
	When I click on "Modern Commerce Day" link
	Then I get redirect to "https://www.epam.com/about/who-we-are/events/2021/modern-commerce-day"
