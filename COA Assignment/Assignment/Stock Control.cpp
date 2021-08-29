#include<stdio.h>
#include<stdlib.h>
#include<ctype.h>
#include<string.h>
#include "Structure.h"

#pragma warning (disable :4996)

//Global Variable
int StockFIndex;
int StockDIndex;
Food foodStock = { "","",0,0 };
Beverage beverageStock = { "","",0,0 };

//Functions from other Files
void displayFoodList(Food foodlist[], int number);
void displayBeverageList(Beverage drinklist[], int number);
void printTitle();

//Useful Function from ASM files
extern "C" {
	void printString(char printStr[]);
	void StringInput(char id[], int size);
	int IntInput();
	int IDCompare(char TID[], char CID[], int LengthString);
	int CharCompare(char TChar, char CChar);
	int stockIn(int Input, int Stock);
	int stockOut(int Input, int Stock);
}

//Pick Food By Food ID
void chooseFoodStock(Food foodlist[], int number) {
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
				foodStock = foodlist[i];
				StockFIndex = i;
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
//Print TargetFood
void printStockFood() {
	char strPrint[50];

	printf("Food Details\n");
	for (int i = 0; i < 50; i++) {
		printf("=");
	}
	printf("\n");

	sprintf(strPrint, "Food ID : %s\n", foodStock.itemID);
	printString(strPrint);

	sprintf(strPrint, "Food Name : %s\n", foodStock.foodName);
	printString(strPrint);

	sprintf(strPrint, "Food Unit Price : RM%.2f\n", foodStock.price);
	printString(strPrint);

	sprintf(strPrint, "Food Quantity : %d\n", foodStock.quantity);
	printString(strPrint);

	for (int i = 0; i < 50; i++) {
		printf("=");
	}
}
//Update Food to Array
void updateFStock(Food foodlist[]) {
	char confirm;

	rewind(stdin);
	printf("Confirm Update For %s (Y/Otherwise): ", foodStock.itemID);
	scanf("%c", &confirm);
	rewind(stdin);

	confirm = toupper(confirm);

	//If Y/y will update array
	if (CharCompare(confirm, 'Y') == 1) {
		foodlist[StockFIndex] = foodStock;
		printf("Food %s were updated.\n", foodlist[StockFIndex].itemID);
	}//Otherwise remain the array
	else {
		printf("No Food were updated.\n");
	}
}
//User Input by choosing order
void UserInputFQuantity(int choice, Food foodlist[]) {
	//For NG Input
	int ngTimes = 1;
	bool validation = true;

	//Get quantity
	int quantity = -1;

	system("cls");
	printTitle();
	printStockFood();
	printf("\n\n");

	switch (choice)
	{
	case 1: //Stock In
		do
		{
			printf("Quantity Input in times : %d\n", ngTimes);
			rewind(stdin);
			printf("Stock in Food Quantity : ");
			quantity = IntInput();

			validation = true;

			//Datatype Exception
			if (quantity == -1) {
				printf("DataType Input Exception.\n\n");
				validation = false;
			}//Negative Value Exception
			else if (quantity < 0) {
				printf("Negative Number Exception\n\n");
				validation = false;
			}
			else {//Stock in
				foodStock.quantity = stockIn(quantity, foodStock.quantity);
			}

			ngTimes++;

		} while (validation != true);

		break;
	case 2: //Stock Out
		do
		{
			printf("Quantity Input in times : %d\n", ngTimes);
			rewind(stdin);
			printf("Stock out Food Quantity : ");
			quantity = IntInput();

			validation = true;

			//Datatype Exception
			if (quantity == -1) {
				printf("DataType Input Exception.\n\n");
				validation = false;
			}//Negative Value Exception
			else if (quantity < 0) {
				printf("Negative Number Exception\n\n");
				validation = false;
			}
			else {
				//If input > current , will out of stock Exception
				if (stockOut(quantity, foodStock.quantity) == -1) {
					validation = false;
				}//Else will stock out
				else {
					foodStock.quantity = stockOut(quantity, foodStock.quantity);
				}	
			}

			ngTimes++;

		} while (validation != true);

		break;
	case 3: //End of Stocking
		updateFStock(foodlist);
		system("pause");
		break;
	default: //Otherwise Error Message
		printf("Invalid Input.\n");
		system("pause");
		break;
	}
}
//Called from StockF
void foodStocking(Food foodlist[]) {
	int choice = -1;
	do {
		choice = -1;
		system("cls");
		printTitle();
		printStockFood();
		printf("\n\n");

		printf("Food Stocking Menu\n");
		printf("========================\n");
		printf("1.Stock In\n");
		printf("2.Stock Out\n");
		printf("3.Exit\n");
		printf("=========================\n");
		printf("Please pick choice (1-3) : ");
		rewind(stdin);
		scanf("%d", &choice);

		UserInputFQuantity(choice, foodlist);

	} while (choice != 3);
}

//Pick Beverage By Beverage ID
void chooseBeverageStock(Beverage drinklist[], int number) {
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
				beverageStock = drinklist[i];
				StockDIndex = i;
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
//Print TargetBeverage
void printStockBeverage() {
	char strPrint[50];

	printf("Beverage Details\n");
	for (int i = 0; i < 50; i++) {
		printf("=");
	}
	printf("\n");

	sprintf(strPrint, "Beverage ID : %s\n", beverageStock.itemID);
	printString(strPrint);

	sprintf(strPrint, "Beverage Name : %s\n", beverageStock.beverageName);
	printString(strPrint);

	sprintf(strPrint, "Beverage Unit Price : RM%.2f\n", beverageStock.price);
	printString(strPrint);

	sprintf(strPrint, "Beverage Quantity : %d\n", beverageStock.quantity);
	printString(strPrint);

	for (int i = 0; i < 50; i++) {
		printf("=");
	}
}
//Update Beverage to Array
void updateDStock(Beverage drinklist[]) {
	char confirm;

	rewind(stdin);
	printf("Confirm Update For %s (Y/Otherwise): ", beverageStock.itemID);
	scanf("%c", &confirm);
	rewind(stdin);

	confirm = toupper(confirm);

	//If Y/y will update array
	if (CharCompare(confirm, 'Y') == 1) {
		drinklist[StockDIndex] = beverageStock;
		printf("Beverage %s were updated.\n", drinklist[StockDIndex].itemID);
	}//Otherwise remain the array
	else {
		printf("No Beverage were updated.\n");
	}
}
//User Input by choosing order
void UserInputDQuantity(int choice, Beverage drinklist[]) {
	//For NG Input
	int ngTimes = 1;
	bool validation = true;

	//Get quantity
	int quantity = -1;

	system("cls");
	printTitle();
	printStockBeverage();
	printf("\n\n");

	switch (choice)
	{
	case 1: //Stock In
		do
		{
			printf("Quantity Input in times : %d\n", ngTimes);
			rewind(stdin);
			printf("Stock in Beverage Quantity : ");
			quantity = IntInput();

			validation = true;

			//Datatype Exception
			if (quantity == -1) {
				printf("DataType Input Exception.\n\n");
				validation = false;
			}//Negative Value Exception
			else if (quantity < 0) {
				printf("Negative Number Exception\n\n");
				validation = false;
			}
			else {//Stock in
				beverageStock.quantity = stockIn(quantity, beverageStock.quantity);
			}

			ngTimes++;

		} while (validation != true);

		break;
	case 2:
		do
		{
			printf("Quantity Input in times : %d\n", ngTimes);
			rewind(stdin);
			printf("Stock out Beverage Quantity : ");
			quantity = IntInput();

			validation = true;

			//Datatype Exception
			if (quantity == -1) {
				printf("DataType Input Exception.\n\n");
				validation = false;
			}//Negative Value Exception
			else if (quantity < 0) {
				printf("Negative Number Exception\n\n");
				validation = false;
			}
			else {
				//If input > current , will out of stock Exception
				if (stockOut(quantity, beverageStock.quantity) == -1) {
					validation = false;
				}//Else will stock out
				else {
					beverageStock.quantity = stockOut(quantity, beverageStock.quantity);
				}
			}

			ngTimes++;

		} while (validation != true);

		break;
	case 3: //End of Stocking
		updateDStock(drinklist);
		system("pause");
		break;
	default: //Otherwise Error Message

		printf("Invalid Input.\n");
		system("pause");
		break;
	}
}
//Called from StockD
void beverageStocking(Beverage drinklist[]) {
	int choice = -1;
	do {
		choice = -1;
		system("cls");
		printTitle();
		printStockBeverage();
		printf("\n\n");

		printf("Beverage Stocking Menu\n");
		printf("========================\n");
		printf("1.Stock In\n");
		printf("2.Stock Out\n");
		printf("3.Exit\n");
		printf("=========================\n");
		printf("Please pick choice (1-3) : ");
		rewind(stdin);
		scanf("%d", &choice);

		UserInputDQuantity(choice, drinklist);

	} while (choice != 3);
}

//The Function Invoked from Product Main Menu
void StockF(Food foodlist[], int number) {
	chooseFoodStock(foodlist, number);
	foodStocking(foodlist);
}
void StockD(Beverage drinklist[], int number) {
	chooseBeverageStock(drinklist, number);
	beverageStocking(drinklist);
}