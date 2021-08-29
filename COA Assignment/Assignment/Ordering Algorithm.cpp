#include<stdio.h>
#include<stdlib.h>
#include "Structure.h"

#pragma warning (disable :4996)

//Global Variables
Food foodlist[999];
Beverage drinklist[999];
int Fcount, Dcount;

//Functions From Other Files
void initializeOrder(Orderdetail orderlist[]);
void readProductforOrder(Food foodlist[],Beverage drinklist[],int *Fcount, int *Dcount);
void orderInput(Orderdetail orderlist[], Food foodlist[], Beverage drinklist[], int Fcount, int Dcount, int *numberofItemOrder, int numberofOrder);
void updateProductFile(Orderdetail orderlist[], Food foodlist[],Beverage drinklist[],int Fcount,int Dcount, int numberofItemOrder);

//Order Algorithm in ordering module
void algorithm(int order, int numberofOrder, Orderdetail orderlist[], int *numberofItemOrder) {
	switch (order)
	{
	case 0: //Before Start Order, Initialize Order detail
		initializeOrder(orderlist);
		break;
	case 1: //Before Start Order, Get Product from Files
		readProductforOrder(foodlist, drinklist, &Fcount, &Dcount);
		break;
	case 2: //Start Product Order detail
		orderInput(orderlist, foodlist, drinklist, Fcount, Dcount, numberofItemOrder, numberofOrder);
		break;
	case 3: //Update Product Array and save into Files
		updateProductFile(orderlist, foodlist, drinklist, Fcount, Dcount, *numberofItemOrder);
		break;
	default:
		break;
	}
}

//Invoked from Main menu
int Orderalgorithm(int numberofOrder, Orderdetail orderlist[]) {
	int i = 0, numberofItemOrder = 0;
	do
	{
		algorithm(i, numberofOrder, orderlist, &numberofItemOrder);
		i++;
	} while (i < 4);
	
	return numberofItemOrder;
}