#include<stdio.h>
#include<stdlib.h>
#include "Structure.h"

#pragma warning (disable : 4996)

//Useful Functions From ASM Files
extern "C" {
	int TYPECompare(char PTYPE);
	int IDCompare(char TID[], char CID[], int LengthString);
	int stockOut(int Input, int Stock);
}

//Functions From Other Files
void updateFoodFile(Food foodlist[], int number);
void updateBeverageFile(Beverage drinklist[], int number);

//Update Food Array from Orderdetails
void updateFoodarray(Food foodlist[], int index, int quantity) {
	//Minus Quantity
	foodlist[index].quantity = stockOut(quantity, foodlist[index].quantity);
	return;
}
//Update Beverage Array from Orderdetails
void updateBeveragearray(Beverage drinklist[], int index, int quantity) {
	//Minus Quantity
	drinklist[index].quantity = stockOut(quantity, drinklist[index].quantity);
	return;
}
//Find Product ID from Product Array in Orderdetails
void searchProduct(Orderdetail orderlist[], Food foodlist[], Beverage drinklist[], int Fcount, int Dcount, int numberofItemOrder) {
	bool checkID;
	int t;

	for (int o = 0; o < numberofItemOrder; o++) {
		//Determine the first Character of ID , F return 1 , B return 2 , otherwise return -1
		switch (TYPECompare(orderlist[o].itemID[0]))
		{
		case 1: //Food Searching
			for (int i = 0; i < Fcount; i++)
			{
				checkID = true;
				//ID Check
				t = IDCompare(orderlist[o].itemID, foodlist[i].itemID, sizeof(orderlist[o].itemID));
				if (t == 0) {
					checkID = false;
				}

				//Food Found
				if (checkID) {
					updateFoodarray(foodlist, i, orderlist[o].quantityOrder);
					break;
				}
			}
			break;
		case 2: //Beverage Searching
			for (int i = 0; i < Dcount; i++)
			{
				checkID = true;
				//ID Check
				t = IDCompare(orderlist[o].itemID, drinklist[i].itemID, sizeof(orderlist[o].itemID));
				if (t == 0) {
					checkID = false;
				}

				//Beverage Found
				if (checkID) {
					updateBeveragearray(drinklist, i, orderlist[o].quantityOrder);
					break;
				}
			}
			break;
		default:
			break;
		}
	}
}

//Invoke From Ordering Algorithm
void updateProductFile(Orderdetail orderlist[], Food foodlist[], Beverage drinklist[], int Fcount, int Dcount, int numberofItemOrder) {
	searchProduct(orderlist, foodlist, drinklist, Fcount, Dcount, numberofItemOrder);
	updateFoodFile(foodlist, Fcount);
	updateBeverageFile(drinklist, Dcount);
}