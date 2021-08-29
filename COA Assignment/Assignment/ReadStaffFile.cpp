#include<stdio.h>
#include<stdlib.h>
#include"Structure.h"

#pragma warning (disable :4996)

//Read Staff List from Assignment\Database\Staff List.txt , return the number of Staff read
int readStaffFromFile(Staff stafflist[]) {
	char path[51];
	FILE *readFilePtr;
	int i = 0, loop;

	for (i = 0; i < 999; i++)
	{
		stafflist[i] = { "","","","","" };
	}

	i = 0;

	sprintf(path, "%s%s", DATABASE, "Staff List.txt");
	readFilePtr = fopen(path, "r");
	if (readFilePtr == NULL)
	{
		printf("Error - Can't open file\n");
		exit(-1);
	}
	while (fscanf(readFilePtr, "%[^\|]|%[^\|]|%[^\n]\n%[^\|]|%[^\n]\n", &stafflist[i].staffID, &stafflist[i].staffName, &stafflist[i].staffPassword, &stafflist[i].phonenumber, &stafflist[i].email) != EOF) {	
		i++;
	}
	fclose(readFilePtr);

	return i;
}