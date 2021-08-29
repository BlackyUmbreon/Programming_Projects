#include<stdio.h>
#include<stdlib.h>

#pragma warning (disable:4996)

//Print Title Function
void printTitle() {
	int i;
	for (i = 0; i < 100; i++) {
		printf("=");
	}
	printf("\n%50s\n","Tarc Food Court");
	for (i = 0; i < 100; i++) {
		printf("=");
	}
	printf("\n");
	return;
}