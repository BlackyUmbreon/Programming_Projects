#include<stdio.h>
#include<stdlib.h>
#include "Structure.h"

#pragma warning (disable :4996)

//Useful Function From ASM File
extern "C" void printString(char printStr[]);

//Display Food Table by Formating
void displayFoodList(Food foodlist[], int number) {
	char strPrint[100];

	printf("Food Table List\n");
	printf("=====================\n\n");

	sprintf(strPrint, "%-15s %-40s %-20s %-10s\n", "Food ID", "Food Name", "Unit Price (RM)", "Quantity");
	printString(strPrint);
	for (int i = 0; i < 100; i++) {
		printf("=");
	}
	printf("\n");

	for (int i = 0; i < number; i++) {
		sprintf(strPrint,"%-15s %-40s %-20.2f %-10d\n", foodlist[i].itemID, foodlist[i].foodName, foodlist[i].price, foodlist[i].quantity);
		printString(strPrint);
	}
	
	printf("\n\n");
	return;
	
}

//Display Baverage Table by Formating
void displayBeverageList(Beverage beveragelist[], int number) {
	char strPrint[100];

	printf("Beverage Table List\n");
	printf("=====================\n\n");

	sprintf(strPrint, "%-15s %-40s %-20s %-10s\n", "Beverage ID", "Beverage Name", "Unit Price (RM)", "Quantity");
	printString(strPrint);
	for (int i = 0; i < 100; i++) {
		printf("=");
	}
	printf("\n");

	for (int i = 0; i < number; i++) {
		sprintf(strPrint, "%-15s %-40s %-20.2f %-10d\n", beveragelist[i].itemID, beveragelist[i].beverageName, beveragelist[i].price, beveragelist[i].quantity);
		printString(strPrint);
	}

	printf("\n\n");
	return;

}