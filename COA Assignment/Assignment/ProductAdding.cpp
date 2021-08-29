#include<stdio.h>
#include<stdlib.h>
#include<string.h>
#include<math.h>
#include<ctype.h>
#include "Structure.h"

#pragma warning (disable :4996)

//Declare Global Variable
Food newfood;
Beverage newBeverage;

//Useful Function From ASM Files
extern "C" {
	void printString(char printStr[]);
	void StringInput(char id[], int size);
	int IntInput();
	int CharCompare(char TChar, char CChar);
}

//The Function From Other Files
void printTitle();

//Print New Food Details
void printNewFood(int number) {
	char strPrint[50];

	printf("New Food Details\n");
	for (int i = 0; i < 50; i++) {
		printf("=");
	}
	printf("\n");

	if (number < 9) {
		sprintf(strPrint, "Food ID : F00%d\n", number + 1);
		sprintf(newfood.itemID, "F00%d", number + 1);
	}
	else if (number < 99) {
		sprintf(strPrint, "Food ID : F0%d\n", number + 1);
		sprintf(newfood.itemID, "F0%d", number + 1);
	}
	else if (number < 999) {
		sprintf(strPrint, "Food ID : F%d\n", number + 1);
		sprintf(newfood.itemID, "F%d", number + 1);
	}
	printString(strPrint);

	sprintf(strPrint, "Food Name : %s\n", newfood.foodName);
	printString(strPrint);

	sprintf(strPrint, "Food Price : RM %.2f\n", newfood.price);
	printString(strPrint);

	sprintf(strPrint, "Food Quantity : %d\n", newfood.quantity);
	printString(strPrint);

	for (int i = 0; i < 50; i++) {
		printf("=");
	}
	printf("\nUser Input here :\n");
}
//Add new Food into array
void addNewFood(int *number, Food foodlist[]) {
	foodlist[*number] = newfood;
	(*number)++;
}
//Get user Input by increase order
void foodInput(int i,int *number, Food foodlist[]) {
	//For NG Input
	int ngTimes = 1;
	bool validation = true;

	//For UnitPrice
	bool validationNumber = true;
	int dotnumber = 0;
	char temp[15] = "";

	//For IntInput
	int dataTypeValidation = -1;

	//For Confirm
	char confirm;

	switch (i)
	{
	case 1: //For New Name
		do
		{
			printf("Food Name Input in times : %d\n", ngTimes);
			rewind(stdin);
			printf("New Food Name : ");
			StringInput(newfood.foodName, sizeof(newfood.foodName));

			for (int k = 0; k < sizeof(newfood.foodName); k++) {
				if (newfood.foodName[k] == 10) {
					newfood.foodName[k] = 0;
				}
			}

			validation = true;

			//Null Exception
			if (strcmp(newfood.foodName, "") == 0) {
				printf("Null Input Exception.\n\n");
				validation = false;
			}

			ngTimes++;

		} while (validation != true);

		break;
	case 2: //For New Unit Price
		do {
			memset(temp, 0, sizeof(temp));
			printf("Unit Price Input in times : %d\n", ngTimes);
			rewind(stdin);
			printf("New Food Unit Price : RM ");
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

			//Check Wheter can convert String to Float Number
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
				newfood.price = atof(temp);
				newfood.price = ceil(newfood.price * 100) / 100;
			}
			
			ngTimes++;
		} while (validation != true);
		break;
	case 3: //For New Quantity
		do
		{
			printf("Quantity Input in times : %d\n", ngTimes);
			rewind(stdin);
			printf("New Food Quantity : ");
			newfood.quantity = IntInput();

			validation = true;

			//Data type Exception
			if (newfood.quantity == -1) {
				printf("DataType Input Exception.\n\n");
				validation = false;
			}//Negative Value Exception
			else if (newfood.quantity < 0) {
				printf("Negative Number Exception\n\n");
				validation = false;
			}

			ngTimes++;

		} while (validation != true);

		break;
	case 4: //For Confirm Add new Food
		rewind(stdin);
		printf("Confirm Adding For %s (Y/Otherwise): ", newfood.itemID);
		scanf("%c", &confirm);
		rewind(stdin);

		confirm = toupper(confirm);

		if (CharCompare(confirm, 'Y') == 1) {
			addNewFood(number, foodlist);
			printf("New Food %s were added.\n", newfood.itemID);
		}
		else {
			printf("No New Food were added.\n");
		}

		break;	
	default:
		break;
	}
}

//Print New Beverage Details
void printNewDrink(int number) {
	char strPrint[50];

	printf("New Beverage Details\n");
	for (int i = 0; i < 50; i++) {
		printf("=");
	}
	printf("\n");

	if (number < 9) {
		sprintf(strPrint, "Beverage ID : B00%d\n", number + 1);
		sprintf(newBeverage.itemID, "B00%d", number + 1);
	}
	else if (number < 99) {
		sprintf(strPrint, "Beverage ID : B0%d\n", number + 1);
		sprintf(newBeverage.itemID, "B0%d", number + 1);
	}
	else if (number < 999) {
		sprintf(strPrint, "Beverage ID : B%d\n", number + 1);
		sprintf(newBeverage.itemID, "B%d", number + 1);
	}
	printString(strPrint);

	sprintf(strPrint, "Beverage Name : %s\n", newBeverage.beverageName);
	printString(strPrint);

	sprintf(strPrint, "Beverage Price : RM %.2f\n", newBeverage.price);
	printString(strPrint);

	sprintf(strPrint, "Beverage Quantity : %d\n", newBeverage.quantity);
	printString(strPrint);

	for (int i = 0; i < 50; i++) {
		printf("=");
	}
	printf("\nUser Input here :\n");
}
//Add new Beverage into array
void addNewDrink(int *number, Beverage drinklist[]) {
	drinklist[*number] = newBeverage;
	(*number)++;
}
//For user Input by increasing order
void drinkInput(int i, int *number, Beverage drinklist[]) {
	//For NG Input
	int ngTimes = 1;
	bool validation = true;

	//For UnitPrice
	bool validationNumber = true;
	int dotnumber = 0;
	char temp[15] = "";

	//For IntInput
	int dataTypeValidation = -1;

	//For Confirm
	char confirm;

	switch (i)
	{
	case 1: //For new Name
		do
		{
			printf("Beverage Name Input in times : %d\n", ngTimes);
			rewind(stdin);
			printf("New Beverage Name : ");
			StringInput(newBeverage.beverageName, sizeof(newBeverage.beverageName));

			for (int k = 0; k < sizeof(newBeverage.beverageName); k++) {
				if (newBeverage.beverageName[k] == 10) {
					newBeverage.beverageName[k] = 0;
				}
			}

			validation = true;

			//Null Exception
			if (strcmp(newBeverage.beverageName, "") == 0) {
				printf("Null Input Exception.\n\n");
				validation = false;
			}

			ngTimes++;

		} while (validation != true);

		break;
	case 2: //For new UnitPrice
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

			//Check Whether can convert String to Float Number
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
				newBeverage.price = atof(temp);
				newBeverage.price = round(newBeverage.price * 100) / 100;
			}

			ngTimes++;
		} while (validation != true);
		break;
	case 3: //For new Quantity
		do
		{
			printf("Quantity Input in times : %d\n", ngTimes);
			rewind(stdin);
			printf("New Beverage Quantity : ");
			newBeverage.quantity = IntInput();

			validation = true;

			//Data type Exception
			if (newBeverage.quantity == -1) {
				printf("DataType Input Exception.\n\n");
				validation = false;
			}//Negative Value Exception
			else if (newBeverage.quantity < 0) {
				printf("Negative Number Exception\n\n");
				validation = false;
			}

			ngTimes++;

		} while (validation != true);

		break;
	case 4: //For Confirm Add new Beverage
		rewind(stdin);
		printf("Confirm Adding For %s (Y/Otherwise): ", newBeverage.itemID);
		scanf("%c", &confirm);
		rewind(stdin);

		confirm = toupper(confirm);

		if (CharCompare(confirm,'Y') == 1) {
			addNewDrink(number, drinklist);
			printf("New Beverage %s were added.\n", newBeverage.itemID);
		}
		else {
			printf("No New Beverage were added.\n");
		}

		break;
	default:
		break;
	}
}

//The Function invoked from Product Main Menu
void FoodAdding(Food foodlist[], int *number) {
	int i = 1;
	newfood = { "","",0,0 };
	do
	{
		system("cls");
		rewind(stdin);
		printTitle();
		printNewFood(*number);
		foodInput(i, number, foodlist);
		i++;
	} while (i < 5);
	system("pause");
}
void BeverageAdding(Beverage drinklist[], int *number) {
	int i = 1;
	newBeverage = { "","",0,0 };
	do
	{
		system("cls");
		rewind(stdin);
		printTitle();
		printNewDrink(*number);
		drinkInput(i, number, drinklist);
		i++;
	} while (i < 5);
	system("pause");
}