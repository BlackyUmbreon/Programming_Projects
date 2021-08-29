#include<stdio.h>
#include<stdlib.h>
#include<ctype.h>
#include<string.h>
#include "Structure.h"

#pragma warning (disable :4996)

//Global Variables
int removeIndex;

//Functions from other files
void displayStaffList(Staff stafflist[], int number);
void printTitle();

//Useful Functions from ASM files
extern "C" {
	void printString(char printStr[]);
	void StringInput(char id[], int size);
	int IDCompare(char TID[], char CID[], int LengthString);
	int CharCompare(char TChar, char CChar);
}

//Pick Staff from Staff Table
void chooseStaffRemove(Staff stafflist[], int number, Staff user) {
	char staffID[5], strprint[100];
	bool repeat = true, checkID, checkMyself;
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
			checkMyself = false;
			checkID = true;
			//ID Check
			t = IDCompare(staffID, stafflist[i].staffID, sizeof(staffID));
			if (t == 0) {
				checkID = false;
			}

			//Staff Found
			if (checkID) {
				//Myself ID Check
				t = IDCompare(staffID, user.staffID, sizeof(staffID));
				if (t == 1) {
					checkMyself = true;
				}

				//If Not same to user
				if (!checkMyself) {
					removeIndex = i;
					repeat = false;
					break;
				}//If Same will invoke myself Exception
				else
				{
					sprintf(strprint, "You can't remove your own information.\n");
					printString(strprint);
					repeat = true;
					system("pause");
					break;
				}
				
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
//Remove Staff from Array
void removingStaff(Staff stafflist[], int *number) {
	char confirm;

	rewind(stdin);
	printf("Confirm Remove Staff %s (Y/Otherwise): ", stafflist[removeIndex].staffID);
	scanf("%c", &confirm);
	rewind(stdin);

	confirm = toupper(confirm);

	//If y/Y , Target Staff removed from Array
	if (CharCompare(confirm,'Y') == 1) {
		printf("Staff %s were Removed.\n", stafflist[removeIndex].staffID);
		for (int i = removeIndex; i < *number; i++) {
			if (i == (*number - 1)) {
				stafflist[i] = { "","","","","" };
			}
			else {
				strcpy(stafflist[i].staffName,stafflist[i + 1].staffName);
				strcpy(stafflist[i].staffPassword, stafflist[i + 1].staffPassword);
				strcpy(stafflist[i].phonenumber, stafflist[i + 1].phonenumber);
				strcpy(stafflist[i].email, stafflist[i + 1].email);
			}	
		}
		(*number)--;
	}//Otherwise remain the Array
	else {
		printf("No Staff were Removed.\n");
	}
}

//Invoked from Staff Main Menu
void staffRemove(Staff stafflist[], int *number, Staff user) {
	chooseStaffRemove(stafflist, *number, user);
	removingStaff(stafflist, number);
	system("pause");
}