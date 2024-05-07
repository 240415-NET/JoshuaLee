	Workout Tracking App - SweatyMcSweatyface
	1. Functional Requirements:
 
		a. User Registration and Authentication
			i. Allow users to create accounts by providing necessary information (e.g., username, email, password).
			ii. **Implement secure authentication mechanisms (e.g., hashing passwords) for user login.
			iii. **Provide password reset functionality (via email) for forgotten passwords.
 
		a. User Profile Management:
			i. Enable users to update their profile information (e.g., name, age, weight, height).
			ii. Store and manage user profiles in the SQL database.
 
		a. Fitness Tracking Features:
			i. Workout Logging
				1) Allow users to log different types of workouts (e.g., running, cycling, weightlifting) along with details such as duration, distance, sets, reps, notes, etc.
				2) Store workout logs in the database associating them with the respective user.
			ii. Goal Setting and Tracking
				1) Enable users to set fitness goals (e.g., weight loss, muscle gain, running distance) and track progress over time.
					a) Include BMI Calculator functionality
			iii. **Calorie and Nutrition Tracking (optional):
				1) **Implement a feature for users to track daily calorie intake and nutritional information (e.g., macros).
 
		a. **Dashboard and Reporting
			i. **Provide users with a dashboard displaying summary statistics (e.g., total workouts completed, progress towards goals).
			ii. **Generate reports or visualizations (e.g., charts, graphs) to help users visualize their fitness progress.
	
	**Not sure if there will be time for these items or if we will know how to do them by the time this project is due, so they are up in the air.


# Planning Document

## I want to...
* Create a C# Console App
* User interactions through the console with exception handling
* Single User
* Persist data to a local file on my machine*
* Separate my code/logic into 3-4 layers. (Presentation (UI the user sees), Data Access (Communicating with our data store), Controllers/Business Logic, Models)

# Application:

* Workout Tracker
	* Multiple accounts must be creatable
	* Different types of workouts
		* Running
		* Cycling
		* Weights
		* etc
	* Need to store details about workouts
		* Workout Name
		* Sets/Weights/Increse/Decrease from last time
		* Distance
		* Workout time
		* Average Speed calculation

# Sweaty McSweatface

## Models
* User:
	* userId (int)
	* userName (string)

* Workouts:
	* workoutId (int)
	* Category (string)
	* Length (Timespan?)

	* Running/Cycling Class/Category
		* totalDistance (double)
		* averageSpeed (double)
		* bestTime (double) --- Running best time based on lowest averageSpeed

	* WeightRoom Class/Category
		* Weight (double)
		* Sets (double)
		* Reps (int)

	
# User Stories/Features:

* As an app user, I want to be able to:
	* Manually Create a userName
	* Automatically generate a userId via GUID

User Stories/Features
As a User I want to be able to create a profile and log in
Present options via a menu in the console to the user (Presentation layer)
We want to take their input and either (Presentation layer)
create a new profile with a given username, and an auto-generated userID (business logic/controller)
~~ we need to then store this profile in our data store (data access layer) ~~
~~ if a given username already exists, prompt the user to provide a different username ~~
