Feature: TC_2.0.0

A short summary of the feature

@tag1
Scenario: [scenario name]
	Given george navigates to playwright docs	
	Then george clicks on GetStarted button in homepage
	And george navigates to trace viewer via sidebar	
	Then george asserts that the viewing trace cli command is "pwsh bin/Debug/netX/playwright.ps1 show-trace trace.zip"
	And george navigates to trace viewer static website