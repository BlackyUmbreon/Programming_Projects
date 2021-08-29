#include<stdio.h>
#include<stdlib.h>
#include "Structure.h"

#pragma warning (disable :4996)

//Global Variables
BillingReceipt newBill;
Membership customerDetail;

//Functions from Other Files
float calculateTotal(Orderdetail orderlist[], int numberofItemOrder);
void calculateDiscountandCharge(BillingReceipt *newBill, Membership customer, bool newMember);
Membership memberAlgorithm(bool *chargeornot);
void calculateGrandTotal(BillingReceipt *newBill);
void getAmountPaid(BillingReceipt *newBill, int numberofOrder, Membership customerDetail);
void printReceipt(Staff user, Orderdetail orderlist[], Membership customer, BillingReceipt billing, int numberOfOrder, int numberOfItemOrder);
void updateSalesReport(Orderdetail orderlist[], BillingReceipt newBill, int numberofItemOrder, SalesReport *todaySalesReport);

//Reset Billing into Null Values
void resetBilling() {
	newBill = { 0,0,0,0,0,0,0 };
}
//Invoke Billing Algorithm by increasing Order
void billingOrder(int order, int numberofOrder, Orderdetail orderlist[], int numberofItemOrder, Staff user, SalesReport *todaySalesReport) {
	switch (order)
	{
	case 0: //Before Calculation , Reset Billing Detail
		resetBilling();
		break;
	case 1: //Get Total From Orderlist get From Ordering Module
		newBill.total = calculateTotal(orderlist, numberofItemOrder);
		break;
	case 2: //Ask User for Membership and calculate Discount,Charges and SST
		bool charge;
		customerDetail = memberAlgorithm(&charge);
		calculateDiscountandCharge(&newBill, customerDetail, charge);
		break;
	case 3: //Calculate the Grand Total and Rounded Grand Total
		calculateGrandTotal(&newBill);
		break;
	case 4: //Get Customer Amount Paid
		getAmountPaid(&newBill,numberofOrder, customerDetail);
		break;
	case 5: //Print Order Receipt After Billing
		printReceipt(user, orderlist, customerDetail, newBill, numberofOrder, numberofItemOrder);
		break;
	case 6: //After Calculation Update the Sales Report for today
		updateSalesReport(orderlist, newBill, numberofItemOrder, todaySalesReport);
		break;
	default:
		break;
	}
}

//Invoke From Main Menu
void Billingalgorithm(int numberofOrder, Orderdetail orderlist[], int numberofItemOrder, Staff user, SalesReport *todaySalesReport) {
	int i = 0;
	do
	{
		billingOrder(i, numberofOrder, orderlist, numberofItemOrder, user, todaySalesReport);
		i++;
	} while (i < 7);
}