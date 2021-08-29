#include<stdio.h>
#include<stdlib.h>
#include "Structure.h"

#pragma warning (disable:4996)

//Declare Global Variable for whole system Use
Staff user = {};

//The Functions from other Files
void mainMenu(Staff user);
Staff SignIn();

//Program Start
int main() {
	//Before Start the Program, System Require user to sign In Staff ID
	//After signed in, Signed User will assign to user variable
	user = SignIn();

	//After getting user detail, the system will start from mainMenu function
	mainMenu(user);
}