#include<stdio.h>
#include<stdlib.h>
#include<string.h>
#include<ctype.h>
#include<math.h>
#include "Structure.h"

#pragma warning (disable :4996)

//Declare Global Variables
Food foodtarget = { "","",0,0 };
Beverage beveragetarget = { "","",0,0 };
int targetFIndex = -1;
int targetDIndex = -1;

//The Functions from other Files
void displayFoodList(Food foodlist[], int number);
void displayBeverageList(Beverage drinklist[], int number);
void printTitle();

//Useful Function From ASM Files
extern "C" {
	int CharCompare(char TChar, char CChar);
	void printString(char printStr[]);
	void StringInput(char id[], int size);
	int IDCompare(char TID[], char CID[], int LengthString);
}

//Pick Food by Food ID
void chooseFoodModify(Food foodlist[], int number) {
	char foodID[5], strprint[100];
	bool repeat = true, checkID;
	int t;
	do {
		repeat = true;
		system("cls");
		rewind(stdin);
		printTitle();
		displayFoodList(foodlist, number);

		//Require user to end Food ID from Food Table
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

			//Existing ID
			if (checkID) {
				foodtarget = foodlist[i];
				targetFIndex = i;
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
//Print The Target Food Detail
void printFood() {
	char strPrint[50];

	printf("Food Details\n");
	for (int i = 0; i < 50; i++) {
		printf("=");
	}
	printf("\n");

	sprintf(strPrint, "Food ID : %s\n", foodtarget.itemID);
	printString(strPrint);

	sprintf(strPrint, "Food Name : %s\n", foodtarget.foodName);
	printString(strPrint);

	sprintf(strPrint, "Food Unit Price : RM%.2f\n", foodtarget.price);
	printString(strPrint);

	sprintf(strPrint, "Food Quantity : %d\n", foodtarget.quantity);
	printString(strPrint);

	for (int i = 0; i < 50; i++) {
		printf("=");
	}
}
//Require user to Update the current Food detail in Food Array to latest Food detail
void updateFoodArray(Food foodlist[]) {
	char confirm;

	rewind(stdin);
	printf("Confirm Update For %s (Y/Otherwise): ", foodtarget.itemID);
	scanf("%c", &confirm);
	rewind(stdin);

	confirm = toupper(confirm);

	//If y/Y , will Update the food in Food Array
	if (CharCompare(confirm, 'Y') == 1) {
		foodlist[targetFIndex] = foodtarget;
		printf("Food %s were updated.\n", foodlist[targetFIndex].itemID);
	}// Otherwise will remain the current Food Array
	else {
		printf("No Food were updated.\n");
	}
}
//User Input from choosing index to change the value
void userFoodInput(int choice, Food foodlist[]) {
	//For NG Input
	int ngTimes = 1;
	bool validation = true;

	//For UnitPrice
	bool validationNumber = true;
	int dotnumber = 0;
	char temp[15] = "";

	system("cls");
	printTitle();
	printFood();
	printf("\n\n");

	switch (choice)
	{
	case 1: //For Input new Name
		do
		{
			printf("Name Input in times : %d\n", ngTimes);
			rewind(stdin);
			printf("New Food Name : ");
			StringInput(foodtarget.foodName, sizeof(foodtarget.foodName));

			//Remove '\n'
			for (int k = 0; k < sizeof(foodtarget.foodName); k++) {
				if (foodtarget.foodName[k] == 10) {
					foodtarget.foodName[k] = 0;
				}
			}

			validation = true;

			//Null Exception
			if (strcmp(foodtarget.foodName, "") == 0) {
				printf("Null Input Exception.\n\n");
				validation = false;
			}

			ngTimes++;

		} while (validation != true);

		break;
	case 2: //For Input new Unit Price
		do {
			memset(temp, 0, sizeof(temp));
			printf("Unit Price Input in times : %d\n", ngTimes);
			rewind(stdin);
			printf("New Beverage Unit Price : RM ");
			StringInput(temp, sizeof(temp));

			for (int k = 0; k < sizeof(temp); k++) {
				if (temp[k] == 10) {
					temp[k] = 0;
				}
			}

			validation = true;
			validationNumber = true;
			dotnumber = 0;

			//Null Exception
			if (strcmp(temp, "") == 0) {
				printf("Null Input Exception.\n\n");
				validation = false;
			}

			//Check Whether can convert String to Float number
			for (int k = 0; k < sizeof(temp); k++) {
				if (temp[k] != 0) {
					if (!isdigit(temp[k]) && temp[k] != '.') {
						validationNumber = false;
						break;
					}
					else {
						if (temp[k] == '.') {
							dotnumber++;
						}
					}
				}
			}

			//If any character is not digit or dot character
			if (!validationNumber) {
				printf("Some of the character input is not number or \'.\'\n\n");
				validation = false;
			}//If the input have more than 1 dot (Logic : Decimal number must only have 1 dot or 0 dot)
			else if (dotnumber > 1) {
				printf("The \'.\' in Input must not have more than 1 time\n\n");
				validation = false;
			}//Success Convert to float number
			else {
				foodtarget.price = atof(temp);
				foodtarget.price = round(foodtarget.price * 100) / 100;
			}

			ngTimes++;
		} while (validation != true);
		break;
	case 3: //For End of Modifying
		updateFoodArray(foodlist);
		system("pause");
		break;
	default: //Otherwise Error message
		printf("Invalid Input.\n");
		system("pause");
		break;
	}
}
//Called from foodModification Function
void foodModify(Food foodlist[]) {
	int choice = -1;
	do {
		//Menu Printing
		choice = -1;
		system("cls");
		printTitle();
		printFood();
		printf("\n\n");

		printf("Food Modification Menu\n");
		printf("========================\n");
		printf("1.Food Name\n");
		printf("2.Unit Price\n");
		printf("3.Exit\n");
		printf("=========================\n");

		//Get Choice From User Input
		printf("Please pick choice (1-3) : ");
		rewind(stdin);
		scanf("%d", &choice);

		userFoodInput(choice, foodlist);

	} while (choice != 3);
}

//Pick Beverage by Beverage ID
void chooseBeverageModify(Beverage drinklist[], int number) {
	char drinkID[5], strprint[100];
	bool repeat = true, checkID;
	int t;
	do {
		repeat = true;
		system("cls");
		rewind(stdin);
		printTitle();
		displayBeverageList(drinklist, number);

		//Require user to end Beverage ID from Beverage Table
		sprintf(strprint, "Choose Beverage ID here : ");
		printString(strprint);
		StringInput(drinkID, sizeof(drinkID));

		for (int i = 0; i < number; i++)
		{
			checkID = true;
			//ID Check
			t = IDCompare(drinkID, drinklist[i].itemID, sizeof(drinkID));
			if (t == 0) {
				checkID = false;
			}

			//Existing ID
			if (checkID) {
				beveragetarget = drinklist[i];
				targetDIndex = i;
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
//Print The Target Beverage Detail
void printBeverage() {
	char strPrint[50];

	printf("Beverage Details\n");
	for (int i = 0; i < 50; i++) {
		printf("=");
	}
	printf("\n");

	sprintf(strPrint, "Beverage ID : %s\n", beveragetarget.itemID);
	printString(strPrint);

	sprintf(strPrint, "Beverage Name : %s\n", beveragetarget.beverageName);
	printString(strPrint);

	sprintf(strPrint, "Beverage Unit Price : RM%.2f\n", beveragetarget.price);
	printString(strPrint);

	sprintf(strPrint, "Beverage Quantity : %d\n", beveragetarget.quantity);
	printString(strPrint);

	for (int i = 0; i < 50; i++) {
		printf("=");
	}
}
//Require user to Update the current Beverage detail in Beverage Array to latest Beverage detail
void updateBeverageArray(Beverage drinklist[]) {
	char confirm;

	rewind(stdin);
	printf("Confirm Update For %s (Y/Otherwise): ", beveragetarget.itemID);
	scanf("%c", &confirm);
	rewind(stdin);

	confirm = toupper(confirm);

	//If y/Y , will Update the Beverage in Beverage Array
	if (CharCompare(confirm, 'Y') == 1) {
		drinklist[targetDIndex] = beveragetarget;
		printf("Beverage %s were updated.\n", drinklist[targetDIndex].itemID);
	}// Otherwise will remain the current Beverage Array
	else {
		printf("No Beverage were updated.\n");
	}
}
//User Input from choosing index to change the value
void userBeverageInput(int choice, Beverage drinklist[]) {
	//For NG Input
	int ngTimes = 1;
	bool validation = true;

	//For UnitPrice
	bool validationNumber = true;
	int dotnumber = 0;
	char temp[15] = "";

	system("cls");
	printTitle();
	printBeverage();
	printf("\n\n");

	switch (choice)
	{
	case 1: //For Input new Name
		do
		{
			printf("Name Input in times : %d\n", ngTimes);
			rewind(stdin);
			printf("New Beverage Name : ");
			StringInput(beveragetarget.beverageName, sizeof(beveragetarget.beverageName));

			//Remove '\n'
			for (int k = 0; k < sizeof(beveragetarget.beverageName); k++) {
				if (beveragetarget.beverageName[k] == 10) {
					beveragetarget.beverageName[k] = 0;
				}
			}

			validation = true;

			//Null Exception
			if (strcmp(beveragetarget.beverageName, "") == 0) {
				printf("Null Input Exception.\n\n");
				validation = false;
			}

			ngTimes++;

		} while (validation != true);

		break;
	case 2: //For Input new Unit Price
		do {
			memset(temp, 0, sizeof(temp));
			printf("Unit Price Input in times : %d\n", ngTimes);
			rewind(stdin);
			printf("New Beverage Unit Price : RM ");
			StringInput(temp, sizeof(temp));

			for (int k = 0; k < sizeof(temp); k++) {
				if (temp[k] == 10) {
					temp[k] = 0;
				}
			}

			validation = true;
			validationNumber = true;
			dotnumber = 0;

			//Null Exception
			if (strcmp(temp, "") == 0) {
				printf("Null Input Exception.\n\n");
				validation = false;
			}

			//Check Whether can convert String to Float number
			for (int k = 0; k < sizeof(temp); k++) {
				if (temp[k] != 0) {
					if (!isdigit(temp[k]) && temp[k] != '.') {
						validationNumber = false;
						break;
					}
					else {
						if (temp[k] == '.') {
							dotnumber++;
						}
					}
				}
			}

			//If any character is not digit or dot character
			if (!validationNumber) {
				printf("Some of the character input is not number or \'.\'\n\n");
				validation = false;
			}//If the input have more than 1 dot (Logic : Decimal number must only have 1 dot or 0 dot)
			else if (dotnumber > 1) {
				printf("The \'.\' in Input must not have more than 1 time\n\n");
				validation = false;
			}//Success Convert to float number
			else {
				beveragetarget.price = atof(temp);
				beveragetarget.price = round(beveragetarget.price * 100) / 100;
			}

			ngTimes++;
		} while (validation != true);
		break;
	case 3: // For End of Modifying
		updateBeverageArray(drinklist);
		system("pause");
		break;
	default: //Otherwise Error message
		printf("Invalid Input.\n");
		system("pause");
		break;
	}
}
//Called from beverageModification Function
void beverageModify(Beverage drinklist[]) {
	int choice = -1;
	do {
		//Menu Printing
		choice = -1;
		system("cls");
		printTitle();
		printBeverage();
		printf("\n\n");

		printf("Beverage Modification Menu\n");
		printf("========================\n");
		printf("1.Beverage Name\n");
		printf("2.Unit Price\n");
		printf("3.Exit\n");
		printf("=========================\n");

		//Get Choice From User Input
		printf("Please pick choice (1-3) : ");
		rewind(stdin);
		scanf("%d", &choice);

		userBeverageInput(choice, drinklist);

	} while (choice != 3);
}

//Functions invoked from Product Main Menu
void foodModification(Food foodlist[], int number) {
	chooseFoodModify(foodlist, number);
	foodModify(foodlist);
}
void beverageModification(Beverage drinklist[], int number) {
	chooseBeverageModify(drinklist, number);
	beverageModify(drinklist);
}