#include<stdio.h>
#include<stdlib.h>
#include<ctype.h>
#include<string.h>
#include<regex>
#include "Structure.h"

#pragma warning (disable :4996)

using namespace std;

//Define the Format Pattern For Phone Number
#define PATTERNPHONE "\\d{3}-\\d{7}"

//Useful Functions From ASM Files
extern "C" {
	char CharInput();
	int IDCompare(char TID[], char CID[], int LengthString);
	int CharCompare(char TChar, char CChar);
	void StringInput(char id[], int size);
	void printString(char printStr[]);
}

//Global Variables
Membership membershipUser;
bool newMember;

//Useful Functions From Other Files
void printTitle();

//Reset membership information to null value
void resetMembership() {
	membershipUser = { "","","", 0 };
}
//Read Membership Array from Assignment\Database\Membership List.txt , return number of Membership read
int readMemberFromFile(Membership memberlist[]) {
	char path[51];
	FILE *readFilePtr;
	int i = 0, loop;
	for (i = 0; i < 999; i++)
	{
		memberlist[i] = { "","","", 0.15 };
	}

	i = 0;

	sprintf(path, "%s%s", DATABASE, "Membership List.txt");
	readFilePtr = fopen(path, "r");
	if (readFilePtr == NULL)
	{
		printf("Error - Can't open file\n");
		exit(-1);
	}
	while (fscanf(readFilePtr, "%[^\|]|%[^\|]|%[^\n]\n", &memberlist[i].memberID, &memberlist[i].memberName, &memberlist[i].phonenumber) != EOF) {
		i++;
	}
	fclose(readFilePtr);

	return i;
}
//Save Membership Array into Assignment\Database\Membership List.txt
void updateMemberFile(Membership memberlist[], int number) {
	char path[51];
	FILE *writeFilePtr;
	int i = 0;

	sprintf(path, "%s%s", DATABASE, "Membership List.txt");
	writeFilePtr = fopen(path, "w");
	if (writeFilePtr == NULL)
	{
		printf("Error - Can't open file\n");
		exit(-1);
	}

	for (i = 0; i < number; i++) {
		fprintf(writeFilePtr, "%s|%s|%s\n", memberlist[i].memberID, memberlist[i].memberName, memberlist[i].phonenumber);
	}

	fclose(writeFilePtr);

	return;
}
//Ask user whether have member card or don't have member card
bool askMemberCard() {
	bool repeat, haveMember;
	char yesorno;
	do {
		system("cls");
		printTitle();
		printf("Do you have Membership Card? (Y/N) : ");
		yesorno = CharInput();
		yesorno = toupper(yesorno);

		if (CharCompare(yesorno, 'Y') == 1) {
			haveMember = true;
			repeat = false;
		}
		else if (CharCompare(yesorno, 'N') == 1) {
			haveMember = false;
			repeat = false;
		}
		else {
			printf("Invalid Input , should input Y or N only .\n");
			system("pause");
			repeat = true;
		}
	} while (repeat);
	return haveMember;
}

//Have Membership
//Compare Member ID with existing Membership in Membership Array
Membership MemberIDComparison(char targetMemberID[], Membership memberlist[], int numberofMember) {
	bool checkID;
	int i;
	for (int t = 0; t < numberofMember; t++) {
		checkID = true;
		//ID Check
		i = IDCompare(targetMemberID, memberlist[t].memberID, sizeof(targetMemberID));
		if (i == 0) {
			checkID = false;
		}

		//Membership Found
		if (checkID) {
			return memberlist[t];
		}
	}

	//No Membership Found
	printf("Member ID doesn't Exist\n");
	system("pause");
	return { "","","",0 };
}
//Get Member ID from user
void getMemberID(Membership memberlist[], int numberofMember) {
	char targetMemberID[5];
	float memberDiscount;
	do
	{
		memberDiscount = 0;
		system("cls");
		printTitle();
		printf("\n");

		printf("Enter Membership ID :");
		StringInput(targetMemberID, sizeof(targetMemberID));
		rewind(stdin);

		membershipUser = MemberIDComparison(targetMemberID, memberlist, numberofMember);

		//Check If discount Allowed is 0
	} while (membershipUser.discountAllowed == 0);

	newMember = false;
	return;
}

//Doesn't have membership
//Print New Member Information
void printNewMember(int number) {
	char strPrint[50];

	printf("New Membership Information\n");
	for (int i = 0; i < 50; i++) {
		printf("=");
	}
	printf("\n");

	if (number < 9) {
		sprintf(strPrint, "Member ID : M00%d\n", number + 1);
		sprintf(membershipUser.memberID, "M00%d", number + 1);
	}
	else if (number < 99) {
		sprintf(strPrint, "Member ID : M0%d\n", number + 1);
		sprintf(membershipUser.memberID, "M0%d", number + 1);
	}
	else if (number < 999) {
		sprintf(strPrint, "Member ID : M%d\n", number + 1);
		sprintf(membershipUser.memberID, "M%d", number + 1);
	}
	printString(strPrint);

	sprintf(strPrint, "Member Name : %s\n", membershipUser.memberName);
	printString(strPrint);

	sprintf(strPrint, "Member Phone Number : %s\n", membershipUser.phonenumber);
	printString(strPrint);

	for (int i = 0; i < 50; i++) {
		printf("=");
	}
	printf("\nUser Input here :\n");
}
//Add new Member into Membership Array
void addNewMember(int *number, Membership memberlist[]) {
	memberlist[*number] = membershipUser;
	(*number)++;
}
//Get User Input
void userMInput(int i, int *number, Membership memberlist[]) {
	//For NG Input
	int ngTimes = 1;
	bool validation = true;

	//For PhoneNumber
	int numberOfChar = 0;

	switch (i)
	{
	case 1: //For New Member Name
		do
		{
			printf("Name Input in times : %d\n", ngTimes);
			rewind(stdin);
			printf("New Member Name : ");
			StringInput(membershipUser.memberName, sizeof(membershipUser.memberName));

			for (int k = 0; k < sizeof(membershipUser.memberName); k++) {
				if (membershipUser.memberName[k] == 10) {
					membershipUser.memberName[k] = 0;
				}
			}

			validation = true;

			//Null Exception
			if (strcmp(membershipUser.memberName, "") == 0) {
				printf("Null Input Exception.\n\n");
				validation = false;
			}

			ngTimes++;

		} while (validation != true);

		break;
	case 2: //For New Phone Number
		do
		{
			printf("Phone Number Input in times : %d\n", ngTimes);
			rewind(stdin);
			printf("New Member Phone Number : ");
			StringInput(membershipUser.phonenumber, sizeof(membershipUser.phonenumber));

			for (int k = 0; k < sizeof(membershipUser.phonenumber); k++) {
				if (membershipUser.phonenumber[k] == 10) {
					membershipUser.phonenumber[k] = 0;
				}
			}

			validation = true;
			numberOfChar = 0;

			for (int k = 0; k < sizeof(membershipUser.phonenumber); k++) {
				if (membershipUser.phonenumber[k] != 0) {
					numberOfChar++;
				}
			}

			//Null Exception
			if (strcmp(membershipUser.phonenumber, "") == 0) {
				printf("Null Input Exception.\n\n");
				validation = false;
			}//Number of character must be 11
			else if (numberOfChar != 11) {
				printf("Length Input Exception.(Phone must have 11 characters)\n\n");
				validation = false;
			}//Format Exception
			else {
				if (!regex_match(membershipUser.phonenumber, regex(PATTERNPHONE))) {
					printf("Format Input Exception.(Format : 0XX-9999999)\n\n");
					validation = false;
				}
			}

			ngTimes++;

		} while (validation != true);

		break;
	case 3: //For Add new Member into Membership Array
		addNewMember(number, memberlist);
		break;
	default:
		break;
	}
}
//Member Registration Algorithm
void memberRegistration(Membership memberlist[], int *numberofMember) {
	int i = 1;
	membershipUser = { "","","",0.15 };
	do
	{
		system("cls");
		rewind(stdin);
		printTitle();
		printNewMember(*numberofMember);
		userMInput(i, numberofMember, memberlist);
		i++;
	} while (i < 4);
}
//Ask User whether he/she want to have a member card or skip membership
void askforRegistration(Membership memberlist[], int *numberofMember) {
	bool repeat;
	char yesorno;
	newMember = false;
	do {
		system("cls");
		printTitle();
		printf("Do you want have a Membership Card? (Y/N) : ");
		yesorno = CharInput();
		yesorno = toupper(yesorno);

		//If y/Y , membership Registration will start
		if (CharCompare(yesorno, 'Y') == 1) {
			memberRegistration(memberlist, numberofMember);
			newMember = true;
			repeat = false;
		}//If n/N , Skip Membership and Customer name as Guest
		else if (CharCompare(yesorno, 'N') == 1) {
			membershipUser = { "","Guest", "",0 };
			repeat = false;
		}//Otherwise Error Message
		else {
			printf("Invalid Input , should input Y or N only .\n");
			system("pause");
			repeat = true;
		}
	} while (repeat);
	return;
}

//Invoked From Billing Algorithm and return customer Detail
Membership memberAlgorithm(bool *chargeornot) {
	Membership memberlist[999];
	int numberofMember = 0;

	float discountAllowed;

	resetMembership();

	numberofMember = readMemberFromFile(memberlist);

	if (askMemberCard()) { //Have member card
		getMemberID(memberlist, numberofMember);
	}
	else { //Don't have member card
		askforRegistration(memberlist, &numberofMember);
	}

	updateMemberFile(memberlist, numberofMember);

	*chargeornot = newMember;
	return membershipUser;
}