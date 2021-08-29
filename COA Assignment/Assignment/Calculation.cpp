#include<stdio.h>
#include<stdlib.h>
#include<string.h>
#include<math.h>
#include<ctype.h>
#include "Structure.h"

#pragma warning (disable :4996)

//Define SST to 10%
#define SST 0.1

//Global Variable
int unitprice[999] = { 0 };
int quantity[999] = { 0 };

//Useful Functions From ASM Files
extern "C" {
	int calculateTotalPrice(int unitprice[], int quantity[], int numberofItem);
	int calculateByPercentage(int total, int discountpercentage);
	void printString(char printStr[]);
	void StringInput(char id[], int size);
	int amountPaidCompare(int amountPaid, int GrandTotal);
}

//Functions From Other Files
void printTitle();

//Print Billing Details for Friendly Display for Customer
void printBilling(BillingReceipt *newBill,int numberofOrder, Membership customerDetail) {
	char strPrint[50];

	printf("Billing Information\n");
	for (int i = 0; i < 50; i++) {
		printf("=");
	}
	printf("\n");

	sprintf(strPrint, "Customer Number: %d\n", numberofOrder + 1);
	printString(strPrint);

	sprintf(strPrint, "Customer Name: %s\n\n", customerDetail.memberName);
	printString(strPrint);

	sprintf(strPrint, "SubTotal : RM%.2f\n", (*newBill).total);
	printString(strPrint);

	sprintf(strPrint, "Discount : RM%.2f\n", (*newBill).DiscountAllowed);
	printString(strPrint);

	sprintf(strPrint, "Sales and Service Tax (SST) : RM%.2f\n", (*newBill).SSTCharge);
	printString(strPrint);

	if ((*newBill).MemberCardCharge != 0) {
		sprintf(strPrint, "Additional Charge : RM%.2f\n", (*newBill).MemberCardCharge);
		printString(strPrint);
	}

	sprintf(strPrint, "Grand Total : RM%.2f\n", (*newBill).GrandTotal);
	printString(strPrint);

	sprintf(strPrint, "Round off Value : RM%.2f\n", (*newBill).roundoffValue);
	printString(strPrint);

	sprintf(strPrint, "Total Amount : RM%.2f\n", (*newBill).FinalTotal);
	printString(strPrint);
	

	for (int i = 0; i < 50; i++) {
		printf("=");
	}
	printf("\nUser Input here :\n");
}
//Calculate Sub Total From order list
float calculateTotal(Orderdetail orderlist[], int numberofItemOrder) {
	for (int i = 0; i < numberofItemOrder; i++) {
		//For Float Number , should times 100 into Integer type for Assembly Language
		unitprice[i] = (int)round(orderlist[i].priceUnit * 100);
		quantity[i] = orderlist[i].quantityOrder;
	}
	float total = 0;
	total = ((float)calculateTotalPrice(unitprice, quantity, numberofItemOrder)) / 100;
	return total;
}
//Calculate Discount and Charge
void calculateDiscountandCharge(BillingReceipt *newBill, Membership customer, bool newMember) {
	//Discount Part
	(*newBill).DiscountAllowed = (float)(calculateByPercentage((int)round((*newBill).total*100), (int)round(customer.discountAllowed * 100))) / 100;

	//Membership Charge
	if (newMember) {
		(*newBill).MemberCardCharge = 10;
	}
	else {
		(*newBill).MemberCardCharge = 0;
	}

	//SST Charge
	(*newBill).SSTCharge = (float)(calculateByPercentage((int)round((*newBill).total * 100), (int)round(0.1 * 100))) / 100;

	return;
}
//Calculate Grand Total and Rounded Grand Total
void calculateGrandTotal(BillingReceipt *newBill) {
	int grandTotal = 0;
	int discountAllowed = (*newBill).DiscountAllowed * 100;
	int membershipCharge = (*newBill).MemberCardCharge * 100;
	int sstCharge = (*newBill).SSTCharge * 100;
	int subTotal = (*newBill).total * 100;
	int finalTotal = 0;
	

	_asm { //Calculate Grand Total
		mov eax, subTotal 
		sub eax, discountAllowed //Minus Discount
		add eax, membershipCharge //Plus Additional Charge
		add eax, sstCharge //Plus SST
		mov grandTotal , eax
	}

	//Before divide Grand Total by 100 to Float Number
	_asm { //Round off
		mov eax, grandTotal
		mov edx, 0
		mov ecx, 10D 
		div ecx       //Divide 10 , Quotient to EAX and Remainder (Decimal Places) to EDX
		cmp edx, 0D   
		je skipRound  //If RM0.00, Skip Rounding
		cmp edx, 5D
		jbe roundoff5 //If RM0.01,RM0.02,RM0.03,RM0.04,RM0.05 will go to Round off 5
		ja roundoff10 //If RM0.06,RM0.07,RM0.08,RM0.09 will go to Round off 10

		skipRound :
			mov edx, 0D   //To RM0.00
			jmp endround
		roundoff5 :
			mov edx, 5D   //To RM0.05
			jmp endround
		roundoff10 :
			mov edx, 0D   //To RM0.10
			inc eax
			jmp endround

		endround :
			mov ebx, edx  //Before multiply must move EDX to EBX, because multiply instruction will affect EDX
			mul ecx       //Times back 10
			add eax, ebx  //Add back EBX to EAX
			mov finalTotal, eax
	}

	//Finally , Divide 100 and convert into Float Number
	(*newBill).GrandTotal = (float)grandTotal / 100.0;
	(*newBill).FinalTotal = (float)finalTotal / 100.0;
	(*newBill).roundoffValue = (float)(finalTotal - grandTotal) / 100.0;

	return;
}
//Get Amount Paid From Customer
void getAmountPaid(BillingReceipt *newBill, int numberofOrder, Membership customerDetail) {
	system("cls");
	printTitle();
	printBilling(newBill, numberofOrder,customerDetail);

	//For NG Input
	int ngTimes = 1;
	bool validation = true;

	//For Amount Paid Variable
	bool validationNumber = true;
	int dotnumber = 0;
	char temp[15] = "";
	float amountP;

	do {
		memset(temp, 0, sizeof(temp));
		printf("Amount Paid Input in times : %d\n", ngTimes);
		rewind(stdin);
		printf("Enter Amount Paid : RM ");
		StringInput(temp, sizeof(temp));

		for (int k = 0; k < sizeof(temp); k++) {
			if (temp[k] == 10) {
				temp[k] = 0;
			}
		}

		validation = true;
		validationNumber = true;
		dotnumber = 0;

		//Null Exception
		if (strcmp(temp, "") == 0) {
			printf("Null Input Exception.\n\n");
			validation = false;
		}

		//Check Whether can convert String to Float number
		for (int k = 0; k < sizeof(temp); k++) {
			if (temp[k] != 0) {
				if (!isdigit(temp[k]) && temp[k] != '.') {
					validationNumber = false;
					break;
				}
				else {
					if (temp[k] == '.') {
						dotnumber++;
					}
				}
			}
		}

		//If any character is not digit or dot character
		if (!validationNumber) {
			printf("Some of the character input is not number or \'.\'\n\n");
			validation = false;
		}//If the input have more than 1 dot (Logic : Decimal number must only have 1 dot or 0 dot)
		else if (dotnumber > 1) {
			printf("The \'.\' in Input must not have more than 1 time\n\n");
			validation = false;
		}//Success Convert to float number
		else {
			if (validation) {
				amountP = atof(temp);
				amountP = ceil(amountP * 100) / 100;
				//If Amount Paid >= Total Payment , will Calculate Change Due
				if (amountPaidCompare((int)(amountP * 100), (int)((*newBill).FinalTotal * 100)) != -1) {
					(*newBill).AmountPaid = amountP;
					(*newBill).ChangeDue = (float)(floor(amountPaidCompare((int)round((amountP * 100)), (int)round(((*newBill).FinalTotal * 100))))) / 100;
					(*newBill).ChangeDue *= (float)100.0;
					(*newBill).ChangeDue = (float)(floor((float)(*newBill).ChangeDue));
					(*newBill).ChangeDue /= (float)100.0;
				}//If Amount Paid < Total Payment , will Print Error Message
				else {
					printf("Insufficient Amount Paid\n\n");
					validation = false;
				}
			}	
		}

		ngTimes++;
	} while (validation != true);
	
}