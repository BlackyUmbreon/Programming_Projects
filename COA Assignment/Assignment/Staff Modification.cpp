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
Staff target = { "","","","","" };
int targetIndex = -1;

//Functions From Other Files
void displayStaffList(Staff stafflist[], int number);
void printTitle();

//Useful Functions From ASM Files
extern "C" {
	void printString(char printStr[]);
	void StringInput(char id[], int size);
	char passwordEncrypted(char password[], int lengthString);
	int IDCompare(char TID[], char CID[], int LengthString);
	int CharCompare(char TChar, char CChar);
}

//Pick Staff from Staff Table
void chooseStaffModify(Staff stafflist[], int number) {
	char staffID[5], strprint[100];
	bool repeat = true, checkID;
	int t;
	do {
		repeat = true;
		system("cls");
		rewind(stdin);
		printTitle();
		displayStaffList(stafflist, number);

		sprintf(strprint, "Choose Staff ID here : ");
		printString(strprint);
		StringInput(staffID, sizeof(staffID));

		for (int i = 0; i < number; i++)
		{
			checkID = true;
			//ID Check
			t = IDCompare(staffID, stafflist[i].staffID, sizeof(staffID));
			if (t == 0) {
				checkID = false;
			}

			//Staff Found
			if (checkID) {
				target = stafflist[i];
				targetIndex = i;
				repeat = false;
				break;
			}
		}

		//No Staff Found
		if (!checkID) {
			sprintf(strprint, "ID doesn't Exist.\n");
			printString(strprint);
			system("pause");
		}
		
	} while (repeat);

}
//Print Targeted Staff Information
void printStaff() {
	char strPrint[50];

	printf("Staff Information\n");
	for (int i = 0; i < 50; i++) {
		printf("=");
	}
	printf("\n");

	sprintf(strPrint, "Staff ID : %s\n", target.staffID);
	printString(strPrint);

	sprintf(strPrint, "Staff Name : %s\n", target.staffName);
	printString(strPrint);

	sprintf(strPrint, "Staff Password : ", target.staffName);
	printString(strPrint);
	for (int i = 0; i < strlen(target.staffPassword); i++) {
		printf("*");
	}
	printf("\n");

	sprintf(strPrint, "Staff Phone Number : %s\n", target.phonenumber);
	printString(strPrint);

	sprintf(strPrint, "Staff Email : %s\n", target.email);
	printString(strPrint);

	for (int i = 0; i < 50; i++) {
		printf("=");
	}
}
//Update Staff into Array
void updateArray(Staff stafflist[]) {
	char confirm;
	
	rewind(stdin);
	printf("Confirm Update For %s (Y/Otherwise): ", target.staffID);
	scanf("%c", &confirm);
	rewind(stdin);

	confirm = toupper(confirm);

	//If y/Y , Update the staff array
	if (CharCompare(confirm,'Y') == 1) {
		stafflist[targetIndex] = target;
		printf("Staff %s were updated.\n", stafflist[targetIndex].staffID);
	}//Otherwise , remain the current staff array
	else {
		printf("No Staff were updated.\n");
	}
}
//User Input by choice
void userInput(int choice, Staff stafflist[]) {
	//For NG Input
	int ngTimes = 1;
	bool validation = true;

	//For Password
	bool validationNumber = false;
	int numberOfChar = 0;

	system("cls");
	printTitle();
	printStaff();
	printf("\n\n");

	switch (choice)
	{
	case 1: //For New Name
		do
		{
			printf("Name Input in times : %d\n", ngTimes);
			rewind(stdin);
			printf("New Staff Name : ");
			StringInput(target.staffName, sizeof(target.staffName));

			for (int k = 0; k < sizeof(target.staffName); k++) {
				if (target.staffName[k] == 10) {
					target.staffName[k] = 0;
				}
			}

			validation = true;

			//Null Exception
			if (strcmp(target.staffName, "") == 0) {
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
			StringInput(target.staffPassword, sizeof(target.staffPassword));

			for (int k = 0; k < sizeof(target.staffPassword); k++) {
				if (target.staffPassword[k] == 10) {
					target.staffPassword[k] = 0;
				}
			}

			validationNumber = false;
			validation = true;
			numberOfChar = 0;

			for (int k = 0; k < sizeof(target.staffPassword); k++) {
				if (target.staffPassword[k] != 0) {
					numberOfChar++;
					if (isdigit(target.staffPassword[k])) {
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
		passwordEncrypted(target.staffPassword,sizeof(target.staffPassword));

		break;
	case 3: //For new Phone number
		do
		{
			printf("Phone Number Input in times : %d\n", ngTimes);
			rewind(stdin);
			printf("New Staff Phone Number : ");
			StringInput(target.phonenumber, sizeof(target.phonenumber));

			for (int k = 0; k < sizeof(target.phonenumber); k++) {
				if (target.phonenumber[k] == 10) {
					target.phonenumber[k] = 0;
				}
			}

			validation = true;
			numberOfChar = 0;

			for (int k = 0; k < sizeof(target.phonenumber); k++) {
				if (target.phonenumber[k] != 0) {
					numberOfChar++;
				}
			}

			//Null Exception
			if (strcmp(target.phonenumber, "") == 0) {
				printf("Null Input Exception.\n\n");
				validation = false;
			}//Number of character must be 11
			else if (numberOfChar != 11) {
				printf("Length Input Exception.(Phone must have 11 characters)\n\n");
				validation = false;
			}//Format Exception
			else {
				if (!regex_match(target.phonenumber, regex(PATTERNPHONE))) {
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
			StringInput(target.email, sizeof(target.email));

			for (int k = 0; k < sizeof(target.email); k++) {
				if (target.email[k] == 10) {
					target.email[k] = 0;
				}
			}

			validation = true;

			//Null Exception
			if (strcmp(target.email, "") == 0) {
				printf("Null Input Exception.\n\n");
				validation = false;
			}//Format Exception
			else {
				if (!regex_match(target.email, regex(PATTERNEMAIL))) {
					printf("Format Input Exception.(Format : ___@___.com)\n\n");
					validation = false;
				}
			}

			ngTimes++;

		} while (validation != true);

		break;
	case 5: //For Update Array
		updateArray(stafflist);
		system("pause");
		break;
	default: //Otherwise Error Message
		printf("Invalid Input.\n");
		system("pause");
		break;
	}
}
//Called From StaffModification
void staffModify(Staff stafflist[]) {
	int choice = -1;
	do {
		choice = -1;
		system("cls");
		printTitle();
		printStaff();
		printf("\n\n");

		printf("Staff Modification Menu\n");
		printf("========================\n");
		printf("1.Name\n");
		printf("2.Password\n");
		printf("3.Phone Number\n");
		printf("4.Email\n");
		printf("5.Exit\n");
		printf("=========================\n");
		printf("Please pick choice (1-5) : ");
		rewind(stdin);
		scanf("%d", &choice);

		userInput(choice, stafflist);
	
	} while (choice != 5);
}

//Invoked From Staff Main Menu
void staffModification(Staff stafflist[], int number) {
	chooseStaffModify(stafflist, number);
	staffModify(stafflist);
}