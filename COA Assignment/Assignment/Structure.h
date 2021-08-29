#pragma once

//Include Text File Path for reading

#define DATABASE "Database\\"
#define DATABASESales "Database\\Sales Report\\"
#define RECEIPT "Receipt\\"
#define SALESREPORT "SalesreportPrint\\"

//Declare All Useful Structure for POS System

struct Food
{
	char itemID[5];
	char foodName[50];
	float price;
	int quantity;
};

struct Beverage
{
	char itemID[5];
	char beverageName[50];
	float price;
	int quantity;
};

struct Staff
{
	char staffID[5];
	char staffName[21];
	char staffPassword[21];
	char phonenumber[12];
	char email[31];
};

struct Membership
{
	char memberID[5];
	char memberName[21];
	char phonenumber[12];
	float discountAllowed;
};

struct Orderdetail
{
	char itemID[5];
	char productName[50];
	int currentQuantity;
	int quantityOrder;
	float priceUnit;
};

struct BillingReceipt {
	float total;
	float SSTCharge; //+
	float DiscountAllowed; //-
	float MemberCardCharge; //+
	float GrandTotal; //=
	float roundoffValue;
	float FinalTotal;
	float AmountPaid;
	float ChangeDue;
};

struct SalesReport
{
	char Date[21];
	Orderdetail ProductSold[999];
	int TproductNumber;
	float Ttotal;
	float TSSTCharge;
	float TDiscountAllowed;
	float TMemberCardCharge;
	float TGrandTotal;
	float TroundoffValue;
	float TFinalTotal;
	float TAmountPaid;
	float TChangeDue;
};

struct NumberOfCustomerToday {
	char Date[21];
	int number;
};