#include<stdio.h>
#include<stdlib.h>
#include<string.h>
#include<ctype.h>
#include<regex>
#include "Structure.h"

#pragma warning (disable :4996)

using namespace std;

//Define the format pattern of String
#define PATTERNEMAIL "(\\w+)(\\.|_)?(\\w*)@(\\w+)(\\.(\\w+))+"
#define PATTERNPHONE "\\d{3}-\\d{7}"

//Declare Global Variables
Staff newStaff = { "","","","","" };

//Useful Functions From ASM Files
extern "C" {
	void printString(char printStr[]);
	void StringInput(char id[], int size);
	char passwordEncrypted(char password[], int lengthString);
	int CharCompare(char TChar, char CChar);
}

//Functions From Other Files
void printTitle();

//Print New Staff Information
void printNewStaff(int number) {
	char strPrint[50];

	printf("New Staff Information\n");
	for (int i = 0; i < 50; i++) {
		printf("=");
	}
	printf("\n");

	if (number < 9) {
		sprintf(strPrint, "Staff ID : S00%d\n", number + 1);
		sprintf(newStaff.staffID, "S00%d", number + 1);
	}
	else if (number < 99) {
		sprintf(strPrint, "Staff ID : S0%d\n", number + 1);
		sprintf(newStaff.staffID, "S0%d", number + 1);
	}
	else if (number < 999) {
		sprintf(strPrint, "Staff ID : S%d\n", number + 1);
		sprintf(newStaff.staffID, "S%d", number + 1);
	}
	printString(strPrint);

	sprintf(strPrint, "Staff Name : %s\n", newStaff.staffName);
	printString(strPrint);

	sprintf(strPrint, "Staff Password : ", newStaff.staffName);
	printString(strPrint);
	for (int i = 0; i < strlen(newStaff.staffPassword); i++) {
		printf("*");
	}
	printf("\n");

	sprintf(strPrint, "Staff Phone Number : %s\n", newStaff.phonenumber);
	printString(strPrint);

	sprintf(strPrint, "Staff Email : %s\n", newStaff.email);
	printString(strPrint);

	for (int i = 0; i < 50; i++) {
		printf("=");
	}
	printf("\nUser Input here :\n");
}
//Add New Staff into Staff Array
void addNewStaff(int *number, Staff stafflist[]) {
	stafflist[*number] = newStaff;
	(*number)++;
}
//User Input by increasing order
void userInput(int i, int *number, Staff stafflist[]) {
	//For NG Input
	int ngTimes = 1;
	bool validation = true;

	//For Password
	bool validationNumber = false;
	int numberOfChar = 0;

	//For Confirm
	char confirm;
	
	switch (i)
	{
	case 1: //For New Name
		do
		{
			printf("Name Input in times : %d\n", ngTimes);
			rewind(stdin);
			printf("New Staff Name : ");
			StringInput(newStaff.staffName, sizeof(newStaff.staffName));

			for (int k = 0; k < sizeof(newStaff.staffName); k++) {
				if (newStaff.staffName[k] == 10) {
					newStaff.staffName[k] = 0;
				}
			}

			validation = true;

			//Null Exception
			if (strcmp(newStaff.staffName, "") == 0) {
				printf("Null Input Exception.\n\n");
				validation = false;
			}
				
			ngTimes++;

		} while (validation != true);

		break;
	case 2: //For New Password
		do {
			printf("Password Input in times : %d\n", ngTimes);
			rewind(stdin);
			printf("New Staff Password (minimum 5 characters and at least 1 number) : ");
			StringInput(newStaff.staffPassword, sizeof(newStaff.staffPassword));

			for (int k = 0; k < sizeof(newStaff.staffPassword); k++) {
				if (newStaff.staffPassword[k] == 10) {
					newStaff.staffPassword[k] = 0;
				}
			}

			validationNumber = false;
			validation = true;
			numberOfChar = 0;

			for (int k = 0; k < sizeof(newStaff.staffPassword); k++) {
				if (newStaff.staffPassword[k] != 0) {
					numberOfChar++;
					if (isdigit(newStaff.staffPassword[k])) {
						validationNumber = true;
					}
				}
			}

			//Check the number of Character in password is more than 5, and Null Exception
			if (numberOfChar < 5) {
				printf("Password length must be minimum 5 characters.\n\n");
				validation = false;
			}//Format Exception (Must at least 1 number)
			else {
				if (!validationNumber) {
					printf("Password must have at least one number.\n\n");
					validation = false;
				}
			}

			ngTimes++;
		} while (validation != true);

		//Modify the password to Encrypted Password
		passwordEncrypted(newStaff.staffPassword, sizeof(newStaff.staffPassword));

		break;
	case 3: //For new Phone number
		do
		{
			printf("Phone Number Input in times : %d\n", ngTimes);
			rewind(stdin);
			printf("New Staff Phone Number : ");
			StringInput(newStaff.phonenumber, sizeof(newStaff.phonenumber));

			for (int k = 0; k < sizeof(newStaff.phonenumber); k++) {
				if (newStaff.phonenumber[k] == 10) {
					newStaff.phonenumber[k] = 0;
				}
			}

			validation = true;
			numberOfChar = 0;

			for (int k = 0; k < sizeof(newStaff.phonenumber); k++) {
				if (newStaff.phonenumber[k] != 0) {
					numberOfChar++;
				}
			}

			//Null Exception
			if (strcmp(newStaff.phonenumber, "") == 0) {
				printf("Null Input Exception.\n\n");
				validation = false;
			}//Number of character must be 11
			else if (numberOfChar != 11) {
				printf("Length Input Exception.(Phone must have 11 characters)\n\n");
				validation = false;
			}//Format Exception
			else {
				if (!regex_match(newStaff.phonenumber, regex(PATTERNPHONE))) {
					printf("Format Input Exception.(Format : 0XX-9999999)\n\n");
					validation = false;
				}
			}

			ngTimes++;

		} while (validation != true);

		break;
	case 4: //For New Email
		do
		{
			printf("Email Input in times : %d\n", ngTimes);
			rewind(stdin);
			printf("New Staff Email : ");
			StringInput(newStaff.email, sizeof(newStaff.email));

			for (int k = 0; k < sizeof(newStaff.email); k++) {
				if (newStaff.email[k] == 10) {
					newStaff.email[k] = 0;
				}
			}

			validation = true;

			//Null Exception
			if (strcmp(newStaff.email, "") == 0) {
				printf("Null Input Exception.\n\n");
				validation = false;
			}//Format Exception
			else {
				if (!regex_match(newStaff.email, regex(PATTERNEMAIL))) {
					printf("Format Input Exception.(Format : ___@___.com)\n\n");
					validation = false;
				}
			}

			ngTimes++;

		} while (validation != true);

		break;
	case 5: //For Add new Staff Array
		rewind(stdin);
		printf("Confirm Adding For %s (Y/Otherwise): ",newStaff.staffID);
		scanf("%c", &confirm);
		rewind(stdin);
		
		confirm = toupper(confirm);

		//If y/Y , add new staff into Array
		if (CharCompare(confirm, 'Y') == 1) {
			addNewStaff(number, stafflist);
			printf("New Staff %s were added.\n", newStaff.staffID);
		}//Otherwise remain the current Array
		else {
			printf("No New Staff were added.\n");
		}
		break;
	default:
		break;
	}
}

//Invoked from Staff Main Menu
void StaffRegistration(Staff stafflist[], int *number) {
	int i = 1;
	newStaff = { "","","","","" };
	do
	{
		system("cls");
		rewind(stdin);
		printTitle();
		printNewStaff(*number);
		userInput(i, number, stafflist);
		i++;
	} while (i < 6);
	system("pause");
}