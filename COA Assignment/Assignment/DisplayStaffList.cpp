#include<stdio.h>
#include<stdlib.h>
#include "Structure.h"

#pragma warning (disable :4996)

//Useful Functions From ASM Files
extern "C" void printString(char printStr[]);

//Display Staff Array in Table Form
void displayStaffList(Staff stafflist[], int number) {
	char strPrint[100];

	printf("Staff Table List\n");
	printf("=====================\n\n");

	sprintf(strPrint,"%-10s %-40s %-20s %-20s\n", "Staff ID", "Staff Name", "Phone Number", "Email");
	printString(strPrint);
	for (int i = 0; i < 100; i++) {
		printf("=");
	}
	printf("\n");

	for (int i = 0; i < number; i++) {
		sprintf(strPrint,"%-10s %-40s %-20s %-20s\n", stafflist[i].staffID, stafflist[i].staffName, stafflist[i].phonenumber, stafflist[i].email);
		printString(strPrint);
	}

	printf("\n\n");
	return;

}
