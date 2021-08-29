#include<stdio.h>
#include<stdlib.h>
#include<string.h>
#include "Structure.h"

#pragma warning (disable:4996)

//The Function From Other Files
void printTitle();
int readStaffFromFile(Staff stafflist[]);

//Useful Functions From ASM File
extern "C" {
	int passwordCompare(char Tpassword[], char Cpassword[], int LengthString);
	int IDCompare(char TID[], char CID[], int LengthString);
	void StringInput(char id[], int size);
}

//System must Compare the password typed and current password , 1 return if success , 0 return if fail
int passwordComparison(Staff *loginStaff, Staff stafflist[],int number) {
	bool checkID, checkPassword;
	int i , numberofChar, numbeofCharP;
	
	//Check One by one from Staff Array
	for (int t = 0; t < number; t++) {
		numberofChar = 0;
		numbeofCharP = 0;
		checkID = true;
		//User ID Check
		i = IDCompare((*loginStaff).staffID, stafflist[t].staffID, sizeof((*loginStaff).staffID));
		if (i == 0) {
			checkID = false;
		}

		//Modify the password ( new Line character "\n" to "\0" ) and count the number of character to compare
		for (int k = 0; k < sizeof(stafflist[t].staffPassword); k++) {
			if ((*loginStaff).staffPassword[k] == 10) {
				(*loginStaff).staffPassword[k] = 0;
			}
			else if ((*loginStaff).staffPassword[k] != 0) {
				numberofChar++;
			}

			if (stafflist[t].staffPassword[k] != 0) {
				numbeofCharP++;
			}
		}

		//If the Staff ID is found from Array , will start compare Password
		if (checkID) {
			checkPassword = true;
			//To Determine whether the password is null or less than the limit number of password character
			if (numberofChar < 5) {
				checkPassword = false;
			}//To Determine whether the number of password type is equal to number of Staff's password
			else if (numberofChar != numbeofCharP) {
				checkPassword = false;
			}

			//Password Check
			i = passwordCompare((*loginStaff).staffPassword, stafflist[t].staffPassword,sizeof((*loginStaff).staffPassword));
			if (i == 0) {
				checkPassword = false;
			}

			printf("\nLogin Message\n");
			printf("====================\n");

			//For Login Success
			if (checkPassword == true) {
				printf("Login successful as %s.\n", (*loginStaff).staffID);
				system("pause");
				strcpy((*loginStaff).staffName, stafflist[t].staffName);
				return 1;
			}//For Incorrect Password
			else {
				printf("Incorrect Password\n");
				system("pause");
				return 0;
			}
		}//If staff ID not found will continue to next Staff ID 
		else {
			continue;
		}
	}
	
	//For ID doesn't Exist
	printf("\nLogin Message\n");
	printf("====================\n");
	printf("Staff ID doesn't exist\n");
	system("pause");
	return 0;

}
void printLogin() {
	//Just Print the Title
	printf("User Sign In\n");
	printf("====================\n\n");
}

//SignIn Algorithm
Staff SignIn() {
	//Declare user
	Staff loginStaff = { "","","","","" };
	Staff stafflist[999];

	//Get Staff array from Staff File and return the number of Staff Read
	int number = readStaffFromFile(stafflist);

	//For Looping if failed to signIn
	int validSignIn = 0;

	do
	{
		//Initialize user
		loginStaff = { "","","","","" };

		system("cls");
		printTitle();
		printf("\n");
		printLogin();

		//Require user to enter ID and Password
		printf("Enter Staff ID :");
		StringInput(loginStaff.staffID,sizeof(loginStaff.staffID));
		rewind(stdin);

		printf("Enter Staff Password :");
		StringInput(loginStaff.staffPassword, sizeof(loginStaff.staffPassword));
		rewind(stdin);

		//Invoke passwordComparison Function and get returned number (0/1)
		validSignIn = passwordComparison(&loginStaff, stafflist, number);
	} while (validSignIn == 0);
	//If 0 (Failed Signed In) , will loop until login successful

	//After sign In will return user detail
	return loginStaff;
}