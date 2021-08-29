#include<stdio.h>
#include<stdlib.h>
#include<ctime>
#include<ctype.h>
#include "Structure.h"

using namespace std;

#pragma warning (disable:4996)

//Global Structure for Whole POS System use
Orderdetail orderlist[999];
NumberOfCustomerToday allDay[999];
NumberOfCustomerToday today;
SalesReport todaySalesReport;
int numberofItemOrder, targetindex;
int totalDay;

//Useful Function from ASM File
extern "C" {
	int CharCompare(char TChar, char CChar);
	int IDCompare(char TID[], char CID[], int LengthString);
}

//For Read/update number of customer from/to Assignement/Database/numberOfCustomer.txt file
void getNumberofCustomer() {
	char path[51];
	FILE *readFilePtr;
	bool checkID;
	time_t now = time(0);
	tm *local_time = localtime(&now);

	for (int i = 0; i < 999; i++)
	{
		allDay[i] = { "",0 };
	}

	today = { "",0 };

	totalDay = 0;

	sprintf(path, "%s%s", DATABASE, "numberOfCustomer.txt");
	readFilePtr = fopen(path, "r");
	if (readFilePtr == NULL)
	{
		printf("Error - Can't open file\n");
		exit(-1);
	}
	while (fscanf(readFilePtr, "%[^\|]|%d\n", &allDay[totalDay].Date, &allDay[totalDay].number) != EOF) {
		totalDay++;
	}
	fclose(readFilePtr);

	sprintf(today.Date, "%d-%d-%d", (*local_time).tm_mday, (*local_time).tm_mon + 1, (*local_time).tm_year + 1900);
	int same = -1;
	bool existing = false;
	targetindex = 0;

	for (int t = 0; t < totalDay; t++) {
		checkID = true;
		same = IDCompare(today.Date, allDay[t].Date, sizeof(today.Date));
		if (same == 0) {
			checkID = false;
		}

		if (checkID) {
			sprintf(today.Date, "%s", allDay[t].Date);
			today.number = allDay[t].number;
			targetindex = t;
			existing = true;
			break;
		}
	}

	if (!existing) {
		targetindex = totalDay;
		totalDay++;
	}

}
void updateNumberofCustomer() {
	char path[51];
	FILE *readFilePtr;

	allDay[targetindex] = today;

	sprintf(path, "%s%s", DATABASE, "numberOfCustomer.txt");
	readFilePtr = fopen(path, "w");
	if (readFilePtr == NULL)
	{
		printf("Error - Can't open file\n");
		exit(-1);
	}

	for (int k = 0; k < totalDay; k++) {
		fprintf(readFilePtr, "%s|%d\n", allDay[k].Date, allDay[k].number);
	}

	fclose(readFilePtr);
}

//For Read/update Current Sales Report detail from/to Assignement/Database/Sales Report/(*Date*).txt file
void getSalesReport() {
	char path[51];
	char tDate[51];
	FILE *readFilePtr;
	time_t now = time(0);
	tm *local_time = localtime(&now);

	sprintf(tDate, "%d-%d-%d", (*local_time).tm_mday, (*local_time).tm_mon + 1, (*local_time).tm_year + 1900);
	sprintf(path, "%s%s.txt", DATABASESales, tDate);
	readFilePtr = fopen(path, "r");
	if (readFilePtr == NULL)
	{
		//Skip Reading
		todaySalesReport = { "",{""},0,0,0,0,0,0,0,0,0,0 };
		sprintf(todaySalesReport.Date, tDate);
		return;
	}

	fscanf(readFilePtr,"%[^\|]|%d\n", &todaySalesReport.Date, &todaySalesReport.TproductNumber);

	//Get Ordered Product
	for (int i = 0; i < todaySalesReport.TproductNumber; i++) {
		fscanf(readFilePtr, "%[^\|]|%[^\n]\n", &todaySalesReport.ProductSold[i].itemID, &todaySalesReport.ProductSold[i].productName);
		fscanf(readFilePtr, "%d|%f\n", &todaySalesReport.ProductSold[i].quantityOrder, &todaySalesReport.ProductSold[i].priceUnit);
	}

	fscanf(readFilePtr, "%f %f %f %f ", &todaySalesReport.Ttotal, &todaySalesReport.TSSTCharge, &todaySalesReport.TDiscountAllowed, &todaySalesReport.TMemberCardCharge);
	fscanf(readFilePtr, "%f %f %f %f %f\n", &todaySalesReport.TGrandTotal, &todaySalesReport.TroundoffValue, &todaySalesReport.TFinalTotal, &todaySalesReport.TAmountPaid, &todaySalesReport.TChangeDue);
	fclose(readFilePtr);

}
void updateSalesReport() {
	char path[51];
	char tDate[51];
	FILE *readFilePtr;
	time_t now = time(0);
	tm *local_time = localtime(&now);

	sprintf(tDate, "%d-%d-%d", (*local_time).tm_mday, (*local_time).tm_mon + 1, (*local_time).tm_year + 1900);
	sprintf(path, "%s%s.txt", DATABASESales, tDate);
	readFilePtr = fopen(path, "w");

	fprintf(readFilePtr, "%s|%d\n", todaySalesReport.Date, todaySalesReport.TproductNumber);

	//Get Ordered Product
	for (int i = 0; i < todaySalesReport.TproductNumber; i++) {
		fprintf(readFilePtr, "%s|%s\n", todaySalesReport.ProductSold[i].itemID, todaySalesReport.ProductSold[i].productName);
		fprintf(readFilePtr, "%d|%.2f\n", todaySalesReport.ProductSold[i].quantityOrder, todaySalesReport.ProductSold[i].priceUnit);
	}

	fprintf(readFilePtr, "%.2f %.2f %.2f %.2f ", todaySalesReport.Ttotal, todaySalesReport.TSSTCharge, todaySalesReport.TDiscountAllowed, todaySalesReport.TMemberCardCharge);
	fprintf(readFilePtr, "%.2f %.2f %.2f %.2f %.2f\n", todaySalesReport.TGrandTotal, todaySalesReport.TroundoffValue, todaySalesReport.TFinalTotal, todaySalesReport.TAmountPaid, todaySalesReport.TChangeDue);
	fclose(readFilePtr);
}

//The Functions from other files  
void printTitle();
void productMain();
void staffMain(Staff user);
int Orderalgorithm(int numberofOrder, Orderdetail orderlist[]);
void Billingalgorithm(int numberofOrder, Orderdetail orderlist[], int numberofItemOrder, Staff user,SalesReport *todaySalesReport);
void printSalesReport(SalesReport todaySalesReport, int numberofOrder);

//Invoke from Main Function
void mainMenu(Staff user) {
	//Declare modifable variables
	char nextCustomer;
	int choice = -1;

	//Get Sales Report
	getSalesReport();

	do {
		//Get current Number of Customer on today
		getNumberofCustomer();

		//Initialize choice index
		choice = -1;

		//Print Main Menu
		system("cls");
		printTitle();
		printf("Main Menu\n");
		printf("========================\n");
		printf("1.Product Modifying\n");
		printf("2.Staff Modifying\n");
		printf("3.Accepting Order\n");
		printf("4.End System\n");
		printf("=========================\n");

		//Get user Choice
		printf("Please pick choice (1-4) : ");
		rewind(stdin);
		scanf("%d", &choice);

		switch (choice)
		{
		case 1:
			//Product Module
			productMain();
			system("pause");
			break;
		case 2:
			//Staff Module
			staffMain(user);
			system("pause");
			break;
		case 3:
			do {
				//Ordering Module
				numberofItemOrder = Orderalgorithm(today.number, orderlist);

				//For Checking the number of product Order, if zero ordered will skip Billing Module
				if (numberofItemOrder != 0) {
					//Billing Module
					Billingalgorithm(today.number, orderlist, numberofItemOrder, user, &todaySalesReport);

					//Increase Number of Customer by 1
					today.number++;
				}

				//Request Staff for accept next Customer
				system("cls");
				printTitle();
				printf("Next Customer? (y/Otherwise) : ");
				rewind(stdin);
				scanf("%c", &nextCustomer);
				rewind(stdin);
				nextCustomer = toupper(nextCustomer);

				// y/Y is looping , Otherwise will end Ordering module & Billing module
			} while (CharCompare(nextCustomer, 'Y') == 1);
			break;
		case 4:
			//Before End System, will Invoke Printing Sales Report on Today
			printSalesReport(todaySalesReport, numberofItemOrder);
			break;
		default:
			//For other from range 1-4 will Print Error Message
			printf("Invalid Input, The Choice should between 1 to 4\n");
			system("pause");
			break;
		}

		//Update new number of Customer;
		updateNumberofCustomer();
	} while (choice != 4);

	//Before end the program, The program will update the Sales Report detail into Sales Report File
	updateSalesReport();
}