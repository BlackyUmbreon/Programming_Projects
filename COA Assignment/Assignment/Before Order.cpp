#include<stdio.h>
#include<stdlib.h>
#include<string.h>
#include "Structure.h"

#pragma warning (disable:4996)

//Initialize Orderdetail Array into Null Value
void initializeOrder(Orderdetail orderlist[]) {
	for (int i = 0; i < 999; i++) {
		orderlist[i] = { "","",0,0,0 };
	}
	return;
}

//Read Food and Beverage from Assignment\Database\Food List.txt and Assignment\Database\Beverage List.txt
//To prepare Product Array to sell
void readProductforOrder(Food foodlist[], Beverage drinklist[], int *Fcount, int *Dcount) {
	char path[51];
	FILE *readFilePtr;
	for (int i = 0; i < 999; i++)
	{
		foodlist[i] = { "","",0,0 };
	}

	*Fcount = 0;

	sprintf(path, "%s%s", DATABASE, "Food List.txt");
	readFilePtr = fopen(path, "r");
	if (readFilePtr == NULL)
	{
		printf("Error - Can't open file\n");
		exit(-1);
	}
	while (fscanf(readFilePtr, "%[^\|]|%[^\n]\n", &foodlist[*Fcount].itemID, &foodlist[*Fcount].foodName) != EOF) {
		fscanf(readFilePtr, "%f %d\n", &foodlist[*Fcount].price, &foodlist[*Fcount].quantity);
		(*Fcount)++;
	}
	fclose(readFilePtr);

	memset(path, 0, sizeof(path));

	for (int i = 0; i < 999; i++)
	{
		drinklist[i] = { "","",0,0 };
	}

	*Dcount = 0;

	sprintf(path, "%s%s", DATABASE, "Beverage List.txt");
	readFilePtr = fopen(path, "r");
	if (readFilePtr == NULL)
	{
		printf("Error - Can't open file\n");
		exit(-1);
	}
	while (fscanf(readFilePtr, "%[^\|]|%[^\n]\n", &drinklist[*Dcount].itemID, &drinklist[*Dcount].beverageName) != EOF) {
		fscanf(readFilePtr, "%f %d\n", &drinklist[*Dcount].price, &drinklist[*Dcount].quantity);
		(*Dcount)++;
	}
	fclose(readFilePtr);

	return;
}