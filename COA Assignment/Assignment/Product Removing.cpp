#include<stdio.h>
#include<stdlib.h>
#include<ctype.h>
#include<string.h>
#include "Structure.h"

#pragma warning (disable :4996)

//Global Variable
int removeFIndex;
int removeDIndex;

//The Function From other Files
void displayFoodList(Food foodlist[], int number);
void displayBeverageList(Beverage drinklist[], int number);
void printTitle();

//Useful Function From ASM File
extern "C" {
	int CharCompare(char TChar, char CChar);
	void printString(char printStr[]);
	void StringInput(char id[], int size);
	int IDCompare(char TID[], char CID[], int LengthString);
}

//Pick Food by ID
void chooseFoodRemove(Food foodlist[], int number) {
	char foodID[5], strprint[100];
	bool repeat = true, checkID;
	int t;
	do {
		repeat = true;
		system("cls");
		rewind(stdin);
		printTitle();
		displayFoodList(foodlist, number);

		sprintf(strprint, "Choose Food ID here : ");
		printString(strprint);
		StringInput(foodID, sizeof(foodID));

		for (int i = 0; i < number; i++)
		{
			checkID = true;
			//ID Check
			t = IDCompare(foodID, foodlist[i].itemID, sizeof(foodID));
			if (t == 0) {
				checkID = false;
			}

			//Food Found
			if (checkID) {
				removeFIndex = i;
				repeat = false;
				break;
			}
		}

		//No Food Found
		if (!checkID) {
			sprintf(strprint, "ID doesn't Exist.\n");
			printString(strprint);
			system("pause");
		}
	} while (repeat);
}
//Remove Food Function
void removingFood(Food foodlist[], int *number) {
	char confirm;

	rewind(stdin);
	printf("Confirm Remove Food %s (Y/Otherwise): ", foodlist[removeFIndex].itemID);
	scanf("%c", &confirm);
	rewind(stdin);

	confirm = toupper(confirm);

	//If Y/y will remove the food from array
	if (CharCompare(confirm, 'Y') == 1) {
		printf("Food %s were Removed.\n", foodlist[removeFIndex].itemID);
		for (int i = removeFIndex; i < *number; i++) {
			if (i == (*number - 1)) {
				foodlist[i] = { "","",0,0 };
			}
			else {
				strcpy(foodlist[i].foodName, foodlist[i + 1].foodName);
				foodlist[i].price = foodlist[i + 1].price;
				foodlist[i].quantity = foodlist[i + 1].quantity;
			}
		}
		(*number)--;
	}//Otherwise will remain the array
	else {
		printf("No Food were Removed.\n");
	}
}

//Pick Food by ID
void chooseBeverageRemove(Beverage drinklist[], int number) {
	char beverageID[5], strprint[100];
	bool repeat = true, checkID;
	int t;
	do {
		repeat = true;
		system("cls");
		rewind(stdin);
		printTitle();
		displayBeverageList(drinklist, number);

		sprintf(strprint, "Choose Beverage ID here : ");
		printString(strprint);
		StringInput(beverageID, sizeof(beverageID));

		for (int i = 0; i < number; i++)
		{
			checkID = true;
			//ID Check
			t = IDCompare(beverageID, drinklist[i].itemID, sizeof(beverageID));
			if (t == 0) {
				checkID = false;
			}

			//Beverage Found
			if (checkID) {
				removeDIndex = i;
				repeat = false;
				break;
			}
		}

		//No Beverage Found
		if (!checkID) {
			sprintf(strprint, "ID doesn't Exist.\n");
			printString(strprint);
			system("pause");
		}
	} while (repeat);
}
//Remove Beverage Function
void removingBeverage(Beverage drinklist[], int *number) {
	char confirm;

	rewind(stdin);
	printf("Confirm Remove Beverage %s (Y/Otherwise): ", drinklist[removeDIndex].itemID);
	scanf("%c", &confirm);
	rewind(stdin);

	confirm = toupper(confirm);

	//If Y/y will remove the Beverage from array
	if (CharCompare(confirm, 'Y') == 1) {
		printf("Beverage %s were Removed.\n", drinklist[removeDIndex].itemID);
		for (int i = removeDIndex; i < *number; i++) {
			if (i == (*number - 1)) {
				drinklist[i] = { "","",0,0 };
			}
			else {
				strcpy(drinklist[i].beverageName, drinklist[i + 1].beverageName);
				drinklist[i].price = drinklist[i + 1].price;
				drinklist[i].quantity = drinklist[i + 1].quantity;
			}
		}
		(*number)--;
	}//Otherwise will remain the array
	else {
		printf("No Beverage were Removed.\n");
	}
}

//Functions Invoked from Product Main Menu
void foodRemove(Food foodlist[], int *number) {
	chooseFoodRemove(foodlist, *number);
	removingFood(foodlist, number);
	system("pause");
}
void beverageRemove(Beverage drinklist[], int *number) {
	chooseBeverageRemove(drinklist, *number);
	removingBeverage(drinklist, number);
	system("pause");
}