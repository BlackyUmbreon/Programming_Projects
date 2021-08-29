#include<stdio.h>
#include<stdlib.h>
#include"Structure.h"

#pragma warning (disable :4996)

//Get Food Array From Assignemnt\Database\Food List.txt
int readFoodFromFile(Food foodlist[999]) {
	char path[51];
	FILE *readFilePtr;
	int i = 0;

	for(i = 0; i < 999;i++)
	{
		foodlist[i] = { "","",0,0 };
	}

	i = 0;

	sprintf(path, "%s%s", DATABASE, "Food List.txt");
	readFilePtr = fopen(path, "r");
	if (readFilePtr == NULL)
	{
		printf("Error - Can't open file\n");
		exit(-1);
	}
	while (fscanf(readFilePtr, "%[^\|]|%[^\n]\n", &foodlist[i].itemID, &foodlist[i].foodName) != EOF) {
		fscanf(readFilePtr, "%f %d\n", &foodlist[i].price, &foodlist[i].quantity);
		i++;
	}
	fclose(readFilePtr);

	return i;
}

//Get Beverage Array From Assignemnt\Database\Beverage List.txt
int readBeverageFromFile(Beverage beveragelist[]) {
	char path[51];
	FILE *readFilePtr;
	int i = 0;

	for (i = 0; i < 999; i++)
	{
		beveragelist[i] = { "","",0,0 };
	}

	i = 0;

	sprintf(path, "%s%s", DATABASE, "Beverage List.txt");
	readFilePtr = fopen(path, "r");
	if (readFilePtr == NULL)
	{
		printf("Error - Can't open file\n");
		exit(-1);
	}
	while (fscanf(readFilePtr, "%[^\|]|%[^\n]\n", &beveragelist[i].itemID, &beveragelist[i].beverageName) != EOF) {
		fscanf(readFilePtr, "%f %d\n", &beveragelist[i].price, &beveragelist[i].quantity);
		i++;
	}
	fclose(readFilePtr);

	return i;
}