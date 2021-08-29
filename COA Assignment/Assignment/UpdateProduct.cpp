#include<stdio.h>
#include<stdlib.h>
#include"Structure.h"

#pragma warning (disable :4996)

//Update Food Array to Assignement\Database\Food List.txt
void updateFoodFile(Food foodlist[],int number) {
	char path[51];
	FILE *writeFilePtr;
	int i = 0;

	sprintf(path, "%s%s", DATABASE, "Food List.txt");
	writeFilePtr = fopen(path, "w");
	if (writeFilePtr == NULL)
	{
		printf("Error - Can't open file\n");
		exit(-1);
	}

	for (i = 0; i < number; i++) {
		fprintf(writeFilePtr, "%s|%s\n", foodlist[i].itemID, foodlist[i].foodName);
		fprintf(writeFilePtr, "%.2f %d\n", foodlist[i].price, foodlist[i].quantity);
	}

	fclose(writeFilePtr);

	return;
}

//Update Food Array to Assignement\Database\Beverage List.txt
void updateBeverageFile(Beverage drinklist[],int number) {
	char path[51];
	FILE *writeFilePtr;
	int i = 0;

	sprintf(path, "%s%s", DATABASE, "Beverage List.txt");
	writeFilePtr = fopen(path, "w");
	if (writeFilePtr == NULL)
	{
		printf("Error - Can't open file\n");
		exit(-1);
	}

	for (i = 0; i < number; i++) {
		fprintf(writeFilePtr, "%s|%s\n", drinklist[i].itemID, drinklist[i].beverageName);
		fprintf(writeFilePtr, "%.2f %d\n", drinklist[i].price, drinklist[i].quantity);
	}

	fclose(writeFilePtr);

	return;
}
