#include<stdio.h>
#include<stdlib.h>
#include "Structure.h"

#pragma warning (disable :4996)

//Functions From Other Files
void printTitle();
int readFoodFromFile(Food foodlist[]);
void displayFoodList(Food foodlist[], int number);
int readBeverageFromFile(Beverage drinklist[]);
void displayBeverageList(Beverage drinklist[], int number);
void FoodAdding(Food foodlist[], int *number);
void BeverageAdding(Beverage drinklist[], int *number);
void foodModification(Food foodlist[], int number);
void beverageModification(Beverage drinklist[], int number);
void foodRemove(Food foodlist[], int *number);
void beverageRemove(Beverage drinklist[], int *number);
void StockF(Food foodlist[], int number);
void StockD(Beverage drinklist[], int number);
void updateFoodFile(Food foodlist[], int number);
void updateBeverageFile(Beverage drinklist[], int number);

//Print Menu
void MenuPrint(int type) {
	if (type == 1) {
		printf("Food List Modification Menu\n");
		printf("========================\n");
		printf("1.Food Adding\n");
		printf("2.Food Modifying\n");
		printf("3.Food Removing\n");
		printf("4.Stock in/Stock Out\n");
		printf("5.Change Product Type\n");
		printf("6.Exit Product Module\n");
		printf("=========================\n");
	}
	else if (type == 2) {
		printf("Beverage List Modification Menu\n");
		printf("========================\n");
		printf("1.Beverage Adding\n");
		printf("2.Beverage Modifying\n");
		printf("3.Beverage Removing\n");
		printf("4.Stock in/Stock Out\n");
		printf("5.Change Product Type\n");
		printf("6.Exit Product Module\n");
		printf("=========================\n");
	}
	
}

//Invoke From Main Menu
void productMain() {
	int choice = -1, number = 0;
	int type = 1;
	Food foodlist[999];
	Beverage drinklist[999];

	do {
		choice = -1;
		system("cls");
		printTitle();
		printf("\n");

		if (type == 1) { //For Food
			number = readFoodFromFile(foodlist);
			displayFoodList(foodlist, number);
		}
		else if (type == 2) { //For Beverage
			number = readBeverageFromFile(drinklist);
			displayBeverageList(drinklist, number);
		}
		
		
		MenuPrint(type);
		printf("Please pick choice (1-6) : ");
		rewind(stdin);
		scanf("%d", &choice);

		switch (choice)
		{
		case 1://For Adding
			if (type == 1) {
				FoodAdding(foodlist,&number);
			}
			else if (type == 2) {
				BeverageAdding(drinklist, &number);
			}
			break;
		case 2://For Modifying
			if (type == 1) {
				foodModification(foodlist, number);
			}
			else if (type == 2) {
				beverageModification(drinklist, number);
			}
			break;
		case 3://For Removing
			if (type == 1) {
				foodRemove(foodlist, &number);
			}
			else if (type == 2) {
				beverageRemove(drinklist, &number);
			}
			break;
		case 4://For Stocking
			if (type == 1) {
				StockF(foodlist, number);
			}
			else if (type == 2) {
				StockD(drinklist, number);
			}
			break;
		case 5://For Changing Product Type
			if (type == 1) {
				type = 2;
			}
			else if (type == 2) {
				type = 1;
			}
			break;
		case 6://Back to main menu
			printf("Back to the main menu\n");
			break;
		default://Otherwise Error message
			printf("Invalid Input!\n");
			system("pause");
			break;
		}

		//Update Product into File after some modifying in array
		if (choice != 5) {
			if (type == 1) {
				updateFoodFile(foodlist, number);
			}
			else if (type == 2) {
				updateBeverageFile(drinklist, number);
			}
		}
		
	} while (choice != 6);
}