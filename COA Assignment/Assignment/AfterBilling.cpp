#include<stdio.h>
#include<stdlib.h>
#include<string.h>
#include<math.h>
#include"Structure.h"

#pragma warning (disable :4996)

//Useful Functions From ASM Files
extern "C" {
	int IDCompare(char TID[], char CID[], int LengthString);
	int stockIn(int Input, int Stock);
	int addAmount(int InputValue, int CurrentValue);
	int PriceCompare(int TPrice, int CPrice);
}

//Update Sales Report from orderlist (Add new Order,Modify Quantity Sold)
void updateProductOrder(Orderdetail orderlist[], int numberofItemOrder, SalesReport *todaySalesReport) {
	bool checkID, checkUnitPrice, FoundExistingProduct;
	int i;

	for (int t = 0; t < numberofItemOrder; t++) {
		checkID = true;
		FoundExistingProduct = false;
		for (int k = 0; k < (*todaySalesReport).TproductNumber; k++) {
			i = IDCompare(orderlist[t].itemID, (*todaySalesReport).ProductSold[k].itemID, sizeof(orderlist[t].itemID));
			if (i == 0) {
				checkID = false;
			}

			//Existing Product Found
			if (checkID) {
				//Check UnitPrice. If 1 will add Quantity Sold, Else will skip for the next Product Search
				if (PriceCompare((int)round(orderlist[t].priceUnit * 100), (int)round((*todaySalesReport).ProductSold[k].priceUnit * 100)) == 0) {
					continue;
				}
				else {
					(*todaySalesReport).ProductSold[k].quantityOrder = stockIn(orderlist[t].quantityOrder, (*todaySalesReport).ProductSold[k].quantityOrder);
					FoundExistingProduct = true;
					break;
				}
			}
		}

		//No Existing Product Found
		if (!FoundExistingProduct) {
			//New Product Add into Sales Report Array
			strcpy((*todaySalesReport).ProductSold[(*todaySalesReport).TproductNumber].itemID, orderlist[t].itemID);
			strcpy((*todaySalesReport).ProductSold[(*todaySalesReport).TproductNumber].productName, orderlist[t].productName);
			(*todaySalesReport).ProductSold[(*todaySalesReport).TproductNumber].priceUnit = orderlist[t].priceUnit;
			(*todaySalesReport).ProductSold[(*todaySalesReport).TproductNumber].quantityOrder = orderlist[t].quantityOrder;
			(*todaySalesReport).TproductNumber++;
		}
		
	}

	return;
}
//Update Sales Report from Billing
void updateBillingAmount(BillingReceipt newBill, SalesReport *todaySalesReport) {
	//Add Total
	(*todaySalesReport).Ttotal = (float)(addAmount((int)round(newBill.total * 100), (int)round((*todaySalesReport).Ttotal * 100))) / 100;

	//Add SST
	(*todaySalesReport).TSSTCharge = (float)(addAmount((int)round(newBill.SSTCharge * 100), (int)round((*todaySalesReport).TSSTCharge * 100))) / 100;

	//Add Discount Allowed
	(*todaySalesReport).TDiscountAllowed = (float)(addAmount((int)round(newBill.DiscountAllowed * 100), (int)round((*todaySalesReport).TDiscountAllowed * 100))) / 100;
	
	//Add Additional Charge
	(*todaySalesReport).TMemberCardCharge = (float)(addAmount((int)round(newBill.MemberCardCharge * 100), (int)round((*todaySalesReport).TMemberCardCharge * 100))) / 100;
	
	//Add Grand Total
	(*todaySalesReport).TGrandTotal = (float)(addAmount((int)round(newBill.GrandTotal * 100), (int)round((*todaySalesReport).TGrandTotal * 100))) / 100;
	
	//Add Rounded Value
	(*todaySalesReport).TroundoffValue = (float)(addAmount((int)round(newBill.roundoffValue * 100), (int)round((*todaySalesReport).TroundoffValue * 100))) / 100;
	
	//Add Final Total
	(*todaySalesReport).TFinalTotal = (float)(addAmount((int)round(newBill.FinalTotal * 100), (int)round((*todaySalesReport).TFinalTotal * 100))) / 100;
	
	//Add Amount Paid
	(*todaySalesReport).TAmountPaid = (float)(addAmount((int)round(newBill.AmountPaid * 100), (int)round((*todaySalesReport).TAmountPaid * 100))) / 100;
	
	//Add Change Due
	(*todaySalesReport).TChangeDue = (float)(addAmount((int)round(newBill.ChangeDue * 100), (int)round((*todaySalesReport).TChangeDue * 100))) / 100;

	return;
}

//Invoked From Billing Algorithm
void updateSalesReport(Orderdetail orderlist[], BillingReceipt newBill, int numberofItemOrder, SalesReport *todaySalesReport) {
	updateProductOrder(orderlist, numberofItemOrder, todaySalesReport);
	updateBillingAmount(newBill, todaySalesReport);
	return;
}