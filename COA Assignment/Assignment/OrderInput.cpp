#include<stdio.h>
#include<stdlib.h>
#include<ctype.h>
#include<string.h>
#include "Structure.h"

#pragma warning (disable :4996)

//Global Variables
Orderdetail neworder = { "","",0,0,0 };
int index = 0;
char Producttype;

//Useful Functions From ASM Files
extern "C" {
	int CharCompare(char TChar, char CChar);
	int IDCompare(char TID[], char CID[], int LengthString);
	int TYPECompare(char PTYPE);
	void printString(char printStr[]);
	void StringInput(char id[], int size);
	int IntInput();
	char CharInput();
	int stockOut(int Input, int Stock);
	int zeroStock(int Stock);
}

//Functions from other Files
void printTitle();
void displayFoodList(Food foodlist[], int number);
void displayBeverageList(Beverage drinklist[], int number);

//Display Order Detail in Table Form
void displayOrderList(Orderdetail orderlist[], int *numberofItemOrder) {
	char strPrint[100];

	printf("Orderdetail Table List\n");
	printf("===========================\n\n");

	sprintf(strPrint, "%-15s %-40s %-20s %-10s\n", "Product ID", "Product Name", "Unit Price (RM)", "Quantity Order");
	printString(strPrint);
	for (int i = 0; i < 100; i++) {
		printf("=");
	}
	printf("\n");

	for (int i = 0; i < *numberofItemOrder; i++) {
		sprintf(strPrint, "%-15s %-40s %-20.2f %-10d\n", orderlist[i].itemID, orderlist[i].productName, orderlist[i].priceUnit, orderlist[i].quantityOrder);
		printString(strPrint);
	}

	printf("\n\n");
	return;
}
//Reset New Order Detail into Null Value
void resetneworder() {
	neworder = { "","",0,0,0 };
	index = 0;
	Producttype = 'F';
}
//Display New Order Detail
void printNewOrder(int numberofOrder) {
	char strPrint[150];

	printf("New Order Details : No.%d Customer\n", numberofOrder + 1);
	for (int i = 0; i < 65; i++) {
		printf("=");
	}
	printf("\n");

	sprintf(strPrint, "Product ID : %s\n", neworder.itemID);
	printString(strPrint);

	sprintf(strPrint, "Product Name : %s\n", neworder.productName);
	printString(strPrint);

	sprintf(strPrint, "Product Price : RM %.2f\n", neworder.priceUnit);
	printString(strPrint);

	sprintf(strPrint, "Product Current Quantity : %d\n", neworder.currentQuantity);
	printString(strPrint);

	sprintf(strPrint, "Product Quantity Order : %d\n", neworder.quantityOrder);
	printString(strPrint);

	for (int i = 0; i < 50; i++) {
		printf("=");
	}
	printf("\nUser Input here :\n");
}
//Pick Food ID from Food Table to order
void chooseFoodOrder(Food foodlist[], int number) {
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
				//Check Whether the quantity is Zero Stock
				if (zeroStock(foodlist[i].quantity) == 1) {
					index = i;
					repeat = false;
					break;
				}//Out of Stock message will invoke if Quantity is 0
				else {
					sprintf(strprint, "Out of Stock Exception\n");
					printString(strprint);
					system("pause");
					break;
				}	
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
//Pick Beverage ID from Food Table to order
void chooseBeverageOrder(Beverage drinklist[], int number) {
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
				//Check Whether the quantity is Zero Stock
				if (zeroStock(drinklist[i].quantity) == 1) {
					index = i;
					repeat = false;
					break;
				}//Out of Stock message will invoke if Quantity is 0
				else {
					sprintf(strprint, "Out of Stock Exception\n");
					printString(strprint);
					system("pause");
					break;
				}
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
//Get Product ID from User and Quantity Order
void getNewOrder(Food foodlist[], Beverage drinklist[], int Fcount, int Dcount, int i, int numberofOrder) {
	//For NG Input
	int ngTimes = 1;
	bool validation = true;

	//For TypeInput, Product ID
	char type;

	//For IntInput
	int dataTypeValidation = -1;

	//For Confirm
	char confirm;

	system("cls");
	printTitle();
	printNewOrder(numberofOrder);

	switch (i)
	{
	case 1: //Get Product ID by Product Type
		do
		{
			printf("Product ID Input in times : %d\n", ngTimes);
			rewind(stdin);
			printf("Enter Product Type (F/B) : ");
			type = CharInput();
			type = toupper(type);
			validation = true;
			index = 0;
			
			//F return 1
			if (TYPECompare(type) == 1) {
				system("cls");
				printTitle();
				
				//Get Food ID
				chooseFoodOrder(foodlist, Fcount);
				strcpy(neworder.itemID, foodlist[index].itemID);
				strcpy(neworder.productName, foodlist[index].foodName);
				neworder.priceUnit = foodlist[index].price;
				neworder.currentQuantity = foodlist[index].quantity;
				Producttype = 'F';
			}//B return 2
			else if (TYPECompare(type) == 2) {
				system("cls");
				printTitle();

				//Get Beverage ID
				chooseBeverageOrder(drinklist, Dcount);
				strcpy(neworder.itemID, drinklist[index].itemID);
				strcpy(neworder.productName, drinklist[index].beverageName);
				neworder.priceUnit = drinklist[index].price;
				neworder.currentQuantity = drinklist[index].quantity;
				Producttype = 'B';
			}//Otherwise return -1, Error Message
			else {
				printf("\nProduct Type Input Exception.\n\n");
				validation = false;
			}
			ngTimes++;

		} while (validation != true);

		break;
	case 2: //Get Quantity
		do
		{
			printf("Quantity Order Input Input in times : %d\n", ngTimes);
			rewind(stdin);
			printf("Enter Quantity Order : ");
			neworder.quantityOrder = IntInput();

			validation = true;

			//Data Type Exception
			if (neworder.quantityOrder == -1) {
				printf("DataType Input Exception.\n\n");
				validation = false;
			}//Negative Value Exception
			else if (neworder.quantityOrder < 0) {
				printf("Negative Number Exception\n\n");
				validation = false;
			}
			else {
				//F return 1, B return 2
				switch (TYPECompare(Producttype))
				{
				case 1:
					//If Quantity Order > Stock Quantity , Error Message
					if (stockOut(neworder.quantityOrder, foodlist[index].quantity) == -1) {
						validation = false;
					} //If Quantity Order <= Stock Quantity 
					else {	
						validation = true;
					}
					break;
				case 2:
					//If Quantity Order > Stock Quantity , Error Message
					if (stockOut(neworder.quantityOrder, drinklist[index].quantity) == -1) {
						validation = false;
					} //If Quantity Order <= Stock Quantity 
					else {
						validation = true;
					}
					break;
				default:
					break;
				}	
			}

			ngTimes++;

		} while (validation != true);

		break;
	default:
		break;
	}
}
//Update Order details Array By Modifying
void updateOrderlist(Orderdetail orderlist[], int *numberofItemOrder) {
	bool existOrder = false, checkID;
	int t, targetOrderIndex;
	char confirm;

	//For Match Product ID by existing Product in Order Array
	for (int i = 0; i < *numberofItemOrder; i++)
	{
		checkID = true;
		targetOrderIndex = -1;

		t = IDCompare(neworder.itemID, orderlist[i].itemID, sizeof(neworder.itemID));
		if (t == 0) {
			checkID = false;
		}

		//Existing Product Found
		if (checkID) {
			existOrder = true;
			targetOrderIndex = i;
			break;
		}

	}

	system("cls");
	printTitle();
	displayOrderList(orderlist, numberofItemOrder);

	//If Existing Order Found
	if (existOrder) {
		//If Quantity to order is zero, will ask User to remove target Order details from Order array
		if (zeroStock(neworder.quantityOrder) == -1) {
			rewind(stdin);
			printf("Confirm Remove Product Ordered %s (Y/Otherwise): ", neworder.itemID);
			scanf("%c", &confirm);
			rewind(stdin);

			confirm = toupper(confirm);

			//If Y/y , remove Order details from Order array
			if (CharCompare(confirm, 'Y') == 1) {
				for (int i = targetOrderIndex; i < *numberofItemOrder; i++) {
					if (i == (*numberofItemOrder - 1)) {
						orderlist[i] = { "","",0,0,0 };
					}
					else {
						strcpy(orderlist[i].itemID, orderlist[i+1].itemID);
						strcpy(orderlist[i].productName, orderlist[i + 1].productName);
						orderlist[i].priceUnit = orderlist[i + 1].priceUnit;
						orderlist[i].currentQuantity = orderlist[i + 1].currentQuantity;
						orderlist[i].quantityOrder = orderlist[i + 1].quantityOrder;
					}
				}
				(*numberofItemOrder)--;
				system("cls");
				printTitle();
				displayOrderList(orderlist, numberofItemOrder);
				printf("Product Ordered %s were Removed.\n", neworder.itemID);
			} //Otherwise , Remain the order array
			else {
				system("cls");
				printTitle();
				displayOrderList(orderlist, numberofItemOrder);
				printf("No Product Ordered were Removed.\n");
			}
		} //If Quantity to order is not zero, will ask User to Modify target Order details In Order array
		else if (zeroStock(neworder.quantityOrder) == 1) {
			rewind(stdin);
			printf("Confirm Modify Product Ordered %s (Y/Otherwise): ", neworder.itemID);
			scanf("%c", &confirm);
			rewind(stdin);

			confirm = toupper(confirm);

			//If Y/y , modify Existing Order details In Order array
			if (CharCompare(confirm, 'Y') == 1) {
				orderlist[targetOrderIndex] = neworder;
				system("cls");
				printTitle();
				displayOrderList(orderlist, numberofItemOrder);
				printf("Product Ordered %s were Modified.\n", neworder.itemID);
			} //Otherwise , Remain the order array
			else {
				system("cls");
				printTitle();
				displayOrderList(orderlist, numberofItemOrder);
				printf("No Product Ordered were Modified.\n");
			}
		}
	}//If No Existing Order Found
	else {
		//If Quantity to order is zero, will Print No Product Added and Skip Update Order details
		if (zeroStock(neworder.quantityOrder) == -1) {
			system("cls");
			printTitle();
			displayOrderList(orderlist, numberofItemOrder);
			printf("No Product Ordered were Added.\n");
		} //If Quantity to order is not zero, will ask User to Add New Order details Into Order array
		else if (zeroStock(neworder.quantityOrder) == 1) {
			rewind(stdin);
			printf("Confirm Add new Product Ordered %s (Y/Otherwise): ", neworder.itemID);
			scanf("%c", &confirm);
			rewind(stdin);

			confirm = toupper(confirm);

			//If Y/y , Add New Order details Into Order array
			if (CharCompare(confirm, 'Y') == 1) {
				orderlist[*numberofItemOrder] = neworder;
				(*numberofItemOrder)++;
				system("cls");
				printTitle();
				displayOrderList(orderlist, numberofItemOrder);
				printf("Product Ordered %s were Added.\n", neworder.itemID);
			} //Otherwise , Remain the order array
			else {
				system("cls");
				printTitle();
				displayOrderList(orderlist, numberofItemOrder);
				printf("No Product Ordered were Added.\n");
			}
		}
	}
	system("pause");
}
//Invoked From Ordering Algorithm
void orderInput(Orderdetail orderlist[], Food foodlist[], Beverage drinklist[], int Fcount, int Dcount, int *numberofItemOrder, int numberofOrder) {
	int order = 0;
	char repeat = 'F';
	do
	{
		order = 0;
		do
		{
			switch (order)
			{
			case 0:
				resetneworder();
				break;
			case 1:
				getNewOrder(foodlist, drinklist, Fcount, Dcount, order, numberofOrder);
				break;
			case 2:
				getNewOrder(foodlist, drinklist, Fcount, Dcount, order, numberofOrder);
				break;
			case 3:
				updateOrderlist(orderlist, numberofItemOrder);
				break;
			default:
				break;
			}
			order++;
		} while (order < 4);

		//Ask User to order Next Product Order
		system("cls");
		printTitle();
		displayOrderList(orderlist, numberofItemOrder);
		rewind(stdin);
		printf("Continue Message\n");
		printf("===========================\n");
		printf("Continue Add new Product to order? (Y/Otherwise): ");
		scanf("%c", &repeat);
		rewind(stdin);

		repeat = toupper(repeat);

		//If Y/y will loop again and accept the new order details
	} while (CharCompare(repeat,'Y') == 1);

	return;
}