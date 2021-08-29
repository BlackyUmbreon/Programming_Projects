#include<stdio.h>
#include<stdlib.h>
#include<ctime>
#include<string.h>
#include "Structure.h"

using namespace std;

#pragma warning (disable :4996)

//Get System Date
typedef struct {
	char wday[20];
	char date[20];
}Date;
time_t now = time(0);
tm *local_time = localtime(&now);

//Useful Functions From ASM Files
extern "C" void printString(char printStr[]);

//Functions From Other Files
void printTitle();

//Get System Date with format ( Sunday , 1 January 2020 )
void getCurrentDate(Date *todayDate) {
	switch ((*local_time).tm_wday)
	{
	case 0:
		sprintf((*todayDate).wday, "Sunday");
		break;
	case 1:
		sprintf((*todayDate).wday, "Monday");
		break;
	case 2:
		sprintf((*todayDate).wday, "Tuesday");
		break;
	case 3:
		sprintf((*todayDate).wday, "Wednesday");
		break;
	case 4:
		sprintf((*todayDate).wday, "Thursday");
		break;
	case 5:
		sprintf((*todayDate).wday, "Friday");
		break;
	case 6:
		sprintf((*todayDate).wday, "Saturday");
		break;
	default:
		break;
	}

	switch ((*local_time).tm_mon)
	{
	case 0:
		sprintf((*todayDate).date, "%d January %d", (*local_time).tm_mday, (*local_time).tm_year + 1900);
		break;
	case 1:
		sprintf((*todayDate).date, "%d February %d", (*local_time).tm_mday, (*local_time).tm_year + 1900);
		break;
	case 2:
		sprintf((*todayDate).date, "%d March %d", (*local_time).tm_mday, (*local_time).tm_year + 1900);
		break;
	case 3:
		sprintf((*todayDate).date, "%d April %d", (*local_time).tm_mday, (*local_time).tm_year + 1900);
		break;
	case 4:
		sprintf((*todayDate).date, "%d May %d", (*local_time).tm_mday, (*local_time).tm_year + 1900);
		break;
	case 5:
		sprintf((*todayDate).date, "%d June %d", (*local_time).tm_mday, (*local_time).tm_year + 1900);
		break;
	case 6:
		sprintf((*todayDate).date, "%d July %d", (*local_time).tm_mday, (*local_time).tm_year + 1900);
		break;
	case 7:
		sprintf((*todayDate).date, "%d August %d", (*local_time).tm_mday, (*local_time).tm_year + 1900);
		break;
	case 8:
		sprintf((*todayDate).date, "%d September %d", (*local_time).tm_mday, (*local_time).tm_year + 1900);
		break;
	case 9:
		sprintf((*todayDate).date, "%d October %d", (*local_time).tm_mday, (*local_time).tm_year + 1900);
		break;
	case 10:
		sprintf((*todayDate).date, "%d November %d", (*local_time).tm_mday, (*local_time).tm_year + 1900);
		break;
	case 11:
		sprintf((*todayDate).date, "%d December %d", (*local_time).tm_mday, (*local_time).tm_year + 1900);
		break;
	default:
		break;
	}
}
//Print Receipt into specific File in Assignment\Receipt\.....txt
void appendReceipttoTextFile(char line[]) {
	char path[51];
	char todayDate[21];
	FILE *appendFilePtr;
	int i = 0;

	sprintf(todayDate, "%d-%d-%d", (*local_time).tm_mday, (*local_time).tm_mon + 1, (*local_time).tm_year + 1900);

	sprintf(path, "%s%s(%s).txt", RECEIPT, "Receipt", todayDate);
	appendFilePtr = fopen(path, "a");

	fprintf(appendFilePtr, line);

	fclose(appendFilePtr);

	return;
}
//Print Receipt on the console Screen
void printReceipt(Staff user, Orderdetail orderlist[], Membership customer, BillingReceipt billing, int numberOfOrder, int numberOfItemOrder) {
	Date todayDate;
	char line[101];
	char line1[51];
	char line2[51];
	char newLine[2] = "\n";
	float pricePrint;
	getCurrentDate(&todayDate);

	system("cls");
	printTitle();

	printf("\nBilling Receipt\n");
	printf("===============================\n\n");

	sprintf(line,"%50s\n\n", "TARC Food Court");
	printString(line);
	appendReceipttoTextFile(line);
	
	//System Time Printing
	sprintf(line1, "Date : %s , %s", todayDate.wday, todayDate.date);
	sprintf(line2, "Time : %d:%d:%d", (*local_time).tm_hour, (*local_time).tm_min, (*local_time).tm_sec);
	sprintf(line, "%-50s %40s\n", line1, line2);
	printString(line);
	appendReceipttoTextFile(line);

	//Customer and Staff Printing
	sprintf(line1, "Customer %d : %s", numberOfOrder + 1, customer.memberName);
	sprintf(line2, "Staff : %s", user.staffName);
	sprintf(line, "%-50s %40s\n\n", line1, line2);
	printString(line);
	appendReceipttoTextFile(line);

	sprintf(line, "%-18s %-30s %20s %20s\n", "Product ID", "Product Name", "Quantity", "Price (RM)");
	printString(line);
	appendReceipttoTextFile(line);

	memset(line, 0, sizeof(line));
	for (int i = 0; i < 91; i++) {
		line[i] = '=';
	}
	printString(line);
	printf("\n");
	appendReceipttoTextFile(line);
	appendReceipttoTextFile(newLine);

	//Order printing
	for (int i = 0; i < numberOfItemOrder; i++) {
		pricePrint = orderlist[i].quantityOrder * orderlist[i].priceUnit;
		sprintf(line, "%-18s %-30s %20d %20.2f\n", orderlist[i].itemID, orderlist[i].productName, orderlist[i].quantityOrder, pricePrint);
		printString(line);
		appendReceipttoTextFile(line);
	}

	printf("\n");
	appendReceipttoTextFile(newLine);
	memset(line, 0, sizeof(line));
	for (int i = 0; i < 91; i++) {
		line[i] = '=';
	}
	printString(line);
	printf("\n");
	appendReceipttoTextFile(line);
	appendReceipttoTextFile(newLine);

	//Billing printing
	sprintf(line, "%-50s %40.2f\n", "Sub Total", billing.total);
	printString(line);
	appendReceipttoTextFile(line);

	if (billing.DiscountAllowed != 0) {
		sprintf(line, "%-50s %40.2f\n", "Discount Allowed", billing.DiscountAllowed);
		printString(line);
		appendReceipttoTextFile(line);
	}
	
	sprintf(line, "%-50s %40.2f\n", "Sales and Service Tax (10%)", billing.SSTCharge);
	printString(line);
	sprintf(line, "%-51s %40.2f\n", "Sales and Service Tax (10%%)", billing.SSTCharge);
	appendReceipttoTextFile(line);

	if (billing.MemberCardCharge != 0) {
		sprintf(line, "%-50s %40.2f\n", "Additional Charge", billing.MemberCardCharge);
		printString(line);
		appendReceipttoTextFile(line);
	}
	
	sprintf(line, "%-50s %40.2f\n", "Grand Total", billing.GrandTotal);
	printString(line);
	appendReceipttoTextFile(line);
	sprintf(line, "%-50s %40.2f\n", "Rounded Value", billing.roundoffValue);
	printString(line);
	appendReceipttoTextFile(line);
	sprintf(line, "%-50s %40.2f\n\n", "Total Amount", billing.FinalTotal);
	printString(line);
	appendReceipttoTextFile(line);

	sprintf(line, "%-50s %40.2f\n", "Amount Paid", billing.AmountPaid);
	printString(line);
	appendReceipttoTextFile(line);
	sprintf(line, "%-50s %40.2f\n\n", "Change Due", billing.ChangeDue);
	printString(line);
	appendReceipttoTextFile(line);

	sprintf(line, "%65s\n", "Thank you for visiting TARC Food Court");
	printString(line);
	appendReceipttoTextFile(line);

	appendReceipttoTextFile(newLine);
	appendReceipttoTextFile(newLine);
	appendReceipttoTextFile(newLine);

	sprintf(line1, "%d-%d-%d", (*local_time).tm_mday, (*local_time).tm_mon + 1, (*local_time).tm_year + 1900);
	sprintf(line, "\n\n%s(%s).txt\n", "Receipt detail will save in Receipt", line1);
	printString(line);
	system("pause");

	return;
}

