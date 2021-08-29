#include<stdio.h>
#include<stdlib.h>
#include<string.h>
#include<ctype.h>
#include "Structure.h"

#pragma warning (disable:4996)

//Global Variables
char todayDate[21];

//The Functions From Other Files
void printTitle();

//Useful Function From ASM Files
extern "C" {
	char CharInput();
	int CharCompare(char TChar, char CChar);
	void printString(char printStr[]);
}

//Print Sales Report into Assignment/SalesreportPrint/...text
void printToSalesReportTextFile(char line[]) {
	char path[51];
	FILE *appendFilePtr;
	int i = 0;

	sprintf(path, "%s%s(%s).txt", SALESREPORT, "Sales Report", todayDate);
	appendFilePtr = fopen(path, "a");

	//The System will print 1 line by 1 line
	fprintf(appendFilePtr, line);

	fclose(appendFilePtr);

	return;
}
//System will reset the file into blank file
void resetSalesReportFile() {
	char path[51];
	FILE *appendFilePtr;
	int i = 0;

	sprintf(path, "%s%s(%s).txt", SALESREPORT, "Sales Report", todayDate);
	appendFilePtr = fopen(path, "w");

	fclose(appendFilePtr);

	return;
}
//Print Formatted Sales Report on Console Screen Before end of Program
void printSalesReport(SalesReport todaySalesReport, int numberofOrder) {
	//Declare useful variable
	char line[101];
	char line1[51];
	char newLine[2] = "\n";
	char yesorno;
	float pricePrint;

	//Get Today Date for filename
	sprintf(todayDate, "%s", todaySalesReport.Date);

	//Ask User want save/update the before Sales Report to latest Sales Report
	system("cls");
	printTitle();
	//Print Sales Report with Formating
	printf("Sales Report\n");
	printf("===============================\n\n");
	rewind(stdin);
	printf("Before printing Sales Report , Do you want save Sales Report into Text File? (y/Otherwise) : ");
	yesorno = CharInput();
	yesorno = toupper(yesorno);

	//If y/Y , will update the Sales Report, Otherwise will remain the before Sales Report

	if (CharCompare(yesorno, 'Y') == 1) {
		resetSalesReportFile();
	}
	system("cls");
	printTitle();

	//Print Sales Report with Formating
	printf("Sales Report\n");
	printf("===============================\n\n");

	//Title
	sprintf(line, "%50s\n\n", "TARC Food Court");
	printString(line);
	if (CharCompare(yesorno, 'Y') == 1) {
		printToSalesReportTextFile(line);
	}
	
	//System Time Printing
	sprintf(line1, "Date : %s",todaySalesReport.Date);
	sprintf(line, "%s\n", line1);
	printString(line);
	if (CharCompare(yesorno, 'Y') == 1) {
		printToSalesReportTextFile(line);
	}

	//Product Sold
	sprintf(line, "%s\n", "Product Sold");
	printString(line);
	if (CharCompare(yesorno, 'Y') == 1) {
		printToSalesReportTextFile(line);
	}

	sprintf(line, "%-18s %-30s %20s %20s\n", "Product ID", "Product Name", "Quantity Sold", "Price (RM)");
	printString(line);
	if (CharCompare(yesorno, 'Y') == 1) {
		printToSalesReportTextFile(line);
	}

	//For Printing Horizontal Line
	memset(line, 0, sizeof(line));
	for (int i = 0; i < 91; i++) {
		line[i] = '=';
	}
	printString(line);
	printf("\n");
	if (CharCompare(yesorno, 'Y') == 1) {
		printToSalesReportTextFile(line);
	}
	if (CharCompare(yesorno, 'Y') == 1) {
		printToSalesReportTextFile(newLine);
	}

	//Product printing by number of Product Sold
	for (int i = 0; i < todaySalesReport.TproductNumber; i++) {
		pricePrint = todaySalesReport.ProductSold[i].quantityOrder * todaySalesReport.ProductSold[i].priceUnit;
		sprintf(line, "%-18s %-30s %20d %20.2f\n", todaySalesReport.ProductSold[i].itemID, todaySalesReport.ProductSold[i].productName, todaySalesReport.ProductSold[i].quantityOrder, pricePrint);
		printString(line);
		if (CharCompare(yesorno, 'Y') == 1) {
			printToSalesReportTextFile(line);
		}
	}

	//For Printing Horizontal Line
	printf("\n");
	if(CharCompare(yesorno, 'Y') == 1) {
		printToSalesReportTextFile(newLine);
	}
	memset(line, 0, sizeof(line));
	for (int i = 0; i < 91; i++) {
		line[i] = '=';
	}
	printString(line);
	printf("\n");
	if (CharCompare(yesorno, 'Y') == 1) {
		printToSalesReportTextFile(line);
	}
	if (CharCompare(yesorno, 'Y') == 1) {
		printToSalesReportTextFile(newLine);
	}

	//Billing printing
	//SubTotal
	sprintf(line, "%-50s %40.2f\n", "Total Sub Total", todaySalesReport.Ttotal);
	printString(line);
	if (CharCompare(yesorno, 'Y') == 1) {
		printToSalesReportTextFile(line);
	}

	//Discount Allowed
	sprintf(line, "%-50s %40.2f\n", "Total Discount Allowed", todaySalesReport.TDiscountAllowed);
	printString(line);
	if (CharCompare(yesorno, 'Y') == 1) {
		printToSalesReportTextFile(line);
	}

	//Sales and Service Tax
	sprintf(line, "%-50s %40.2f\n", "Total Sales and Service Tax (10%)", todaySalesReport.TSSTCharge);
	printString(line);
	sprintf(line, "%-51s %40.2f\n", "Total Sales and Service Tax (10%%)", todaySalesReport.TSSTCharge);
	if (CharCompare(yesorno, 'Y') == 1) {
		printToSalesReportTextFile(line);
	}

	//Additional Charge
	sprintf(line, "%-50s %40.2f\n", "Total Additional Charge", todaySalesReport.TMemberCardCharge);
	printString(line);
	if (CharCompare(yesorno, 'Y') == 1) {
		printToSalesReportTextFile(line);
	}

	//Grand Total
	sprintf(line, "%-50s %40.2f\n", "Total Grand Total", todaySalesReport.TGrandTotal);
	printString(line);
	if (CharCompare(yesorno, 'Y') == 1) {
		printToSalesReportTextFile(line);
	}

	//Rounded Value
	sprintf(line, "%-50s %40.2f\n", "Total Rounded Value", todaySalesReport.TroundoffValue);
	printString(line);
	if (CharCompare(yesorno, 'Y') == 1) {
		printToSalesReportTextFile(line);
	}

	//Final Total
	sprintf(line, "%-50s %40.2f\n\n", "Total Total Amount", todaySalesReport.TFinalTotal);
	printString(line);
	if (CharCompare(yesorno, 'Y') == 1) {
		printToSalesReportTextFile(line);
	}

	//Amount Paid
	sprintf(line, "%-50s %40.2f\n", "Total Amount Paid", todaySalesReport.TAmountPaid);
	printString(line);
	if (CharCompare(yesorno, 'Y') == 1) {
		printToSalesReportTextFile(line);
	}

	//Change Due
	sprintf(line, "%-50s %40.2f\n\n", "Total Change Due", todaySalesReport.TChangeDue);
	printString(line);
	if (CharCompare(yesorno, 'Y') == 1) {
		printToSalesReportTextFile(line);
	}

	//Thank You Message
	sprintf(line, "%65s\n", "Thank you for using TARC POS System");
	printString(line);
	if (CharCompare(yesorno, 'Y') == 1) {
		printToSalesReportTextFile(line);
	}

	//If Yes will show this message to inform the saved text file location
	if(CharCompare(yesorno, 'Y') == 1){
		sprintf(line, "\n\n%s(%s).txt\n", "Sales Report will save in Sales Report", todaySalesReport.Date);
		printString(line);
	}

	system("pause");
}