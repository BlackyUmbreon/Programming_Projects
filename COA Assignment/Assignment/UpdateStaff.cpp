#include<stdio.h>
#include<stdlib.h>
#include"Structure.h"

#pragma warning (disable :4996)

//Update Food Array to Assignement\Database\Staff List.txt
void updateTextFile(Staff stafflist[], int number) {
	char path[51];
	FILE *writeFilePtr;
	int i = 0;

	sprintf(path, "%s%s", DATABASE, "Staff List.txt");
	writeFilePtr = fopen(path, "w");
	if (writeFilePtr == NULL)
	{
		printf("Error - Can't open file\n");
		exit(-1);
	}

	for (i = 0; i < number; i++) {
		fprintf(writeFilePtr, "%s|%s|%s\n%s|%s\n", stafflist[i].staffID, stafflist[i].staffName, stafflist[i].staffPassword, stafflist[i].phonenumber, stafflist[i].email);
	}

	fclose(writeFilePtr);

	return;
}