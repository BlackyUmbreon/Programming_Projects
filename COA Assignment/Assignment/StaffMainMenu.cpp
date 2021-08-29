#include<stdio.h>
#include<stdlib.h>
#include "Structure.h"

#pragma warning (disable :4996)

//Functions From other Files
void printTitle();
int readStaffFromFile(Staff stafflist[]);
void displayStaffList(Staff stafflist[], int number);
void StaffRegistration(Staff stafflist[], int *number);
void staffModification(Staff stafflist[], int number);
void updateTextFile(Staff stafflist[], int number);
void staffRemove(Staff stafflist[], int *number, Staff user);

//Print Menu and get choices , Invoked from Main Menu
void staffMain(Staff user) {
	int choice = -1, number = 0;
	Staff stafflist[999];

	do {
		choice = -1;
		system("cls");
		printTitle();
		printf("\n");
		number = readStaffFromFile(stafflist);
		displayStaffList(stafflist, number);

		printf("Staff List Modification Menu\n");
		printf("========================\n");
		printf("1.Staff Registration\n");
		printf("2.Staff Information Modifying\n");
		printf("3.Staff Removing\n");
		printf("4.Exit Staff Module\n");
		printf("=========================\n");

		//Get Choices from menu
		printf("Please pick choice (1-4) : ");
		rewind(stdin);
		scanf("%d", &choice);

		switch (choice)
		{
		case 1: //For Staff Registration
			StaffRegistration(stafflist, &number);
			break;
		case 2: //For Staff Modification
			staffModification(stafflist,number);
			break;
		case 3: //For Staff Removing
			staffRemove(stafflist, &number, user);
			break;
		case 4: //Back to main menu
			printf("Back to the main menu\n");
			break;
		default: //Otherwise Error message
			printf("Invalid Input!\n");
			system("pause");
			break;
		}

		//Update Staff into File after some modifying in array
		updateTextFile(stafflist,number);

	} while (choice != 4);
}