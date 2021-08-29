/*
	Program Name : Lim Wei Yang.c
	Done by : Lim Wei Yang
	Student ID : 18WM03431
	Date : 5/7/2018 -- 9/8/2018
*/

#include<stdio.h>
#include<stdlib.h>
#pragma warning (disable : 4996)

//Define constants for constants price
#define COMBOA 10.00
#define COMBOB 15.00
#define COMBOC 18.00
#define COMBOD 24.00
#define TAX 10.00

//Functions to call
void logo();
void menu();
void selection();
void process();
void display();
void goodbye();
void finalresultprocess();
void finalresult();
void closing();
void member();
void restart();

//For Global Variable
char combo;
int a, b, c, d, ta = 0, tb = 0, tc = 0, td = 0, ft, ac, memberdis;
double totala, totalb, totalc, totald, subtotal, tax, total, paid, due, ftotala, ftotalb, ftotalc, ftotald, fstotal, ftax, ftotal, discount, dtotal, fdiscount = 0, fgtotal;

void main()
{
	char yesno;
	ac = 1; //Set initialization customer no into 1
	logo(); //Call logo display function

	do
	{
		//Function Call
		menu(); //Menu function
		printf("Customer No : %d \n", ac++); //Postfix value of ac before add 1 for next customer
		restart(); //Reset quantity function
		member(); //Ask if have member card for 10% discount function
		selection(); //Select combo function
		process(); //Calculate amount to pay function
		display(); //Displace amount and get if enough amount paid function
		goodbye(); //Print THANK YOU function
		rewind(stdin);
		//For next customer
		printf("Next customer (Y=yes?) : ");
		fflush(stdin);
		scanf("%c", &yesno);
	} while (yesno == 'Y' || yesno == 'y'); //If yes, loop function from menu()
	finalresultprocess(); //Calculate total quantities and total amount received function
	finalresult(); //Display total quantities and total received function
	closing(); //Print CLOSING function
	system("pause"); //End
}

void logo()
{
	//Start Screen : Fast Food Restaurant Logo (Domino's Pizza Logo)
	printf("%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c\n", 201, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 187);
	printf("%c%51c\n", 186, 186);
	printf("%c%9c%42c\n", 186, 177, 186);
	printf("%c%8c%c%c%41c\n", 186, 177, 177, 177, 186);
	printf("%c%7c%c%c%c%c%40c\n", 186, 177, 177, 177, 177, 177, 186);
	printf("%c%6c%c%c%2c%c%c%39c\n", 186, 177, 177, 177, 177, 177, 177, 186);
	printf("%c%5c%2c%c%c%c%c%4c%c%c%c%33c\n", 186, 176, 177, 177, 177, 177, 177, 177, 177, 177, 177, 186);
	printf("%c%4c%c%c%2c%c%c%5c%3c%c%13c%11c%8c\n", 186, 176, 176, 176, 177, 177, 177, 177, 177, 177, 177, 177, 186);
	printf("%c%3c%c%c%c%c%2c%6c%4c%26c%c%c%c%3c\n", 186, 176, 176, 176, 176, 176, 177, 177, 177, 177, 177, 177, 177, 186);
	printf("%c%2c%c%2c%2c%c%7c%4c%2c%c%c%c%2c%c%c%c%c%2c%2c%c%c%c%2c%c%c%c%3c%6c\n", 186, 176, 176, 176, 176, 176, 177, 177, 177, 177, 177, 177, 177, 177, 177, 177, 177, 177, 177, 177, 177, 177, 177, 177, 177, 177, 177, 186);
	printf("%c%3c%c%c%c%c%8c%4c%2c%3c%2c%2c%2c%2c%2c%3c%2c%3c%3c%c%c%c%3c\n", 186, 176, 176, 176, 176, 176, 177, 177, 177, 177, 177, 177, 177, 177, 177, 177, 177, 177, 177, 177, 177, 177, 186);
	printf("%c%4c%c%c%9c%3c%c%2c%3c%2c%2c%2c%2c%2c%3c%2c%3c%6c%3c\n", 186, 176, 176, 176, 177, 177, 177, 177, 177, 177, 177, 177, 177, 177, 177, 177, 177, 177, 186);
	printf("%c%5c%10c%c%c%c%3c%c%c%c%2c%2c%2c%2c%2c%3c%2c%c%c%c%3c%c%c%c%3c\n", 186, 176, 177, 177, 177, 177, 177, 177, 177, 177, 177, 177, 177, 177, 177, 177, 177, 177, 177, 177, 177, 177, 177, 177, 186);
	printf("%c%51c\n", 186, 186);
	printf("%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c\n", 200, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 188);

	return;
}

void menu()
{
	//Memu Screen (4 combo)
	printf("\n");
	printf("%2c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c\n", 201, 205, 205, 205, 205, 205, 205, 205, 205, 205, 203, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 203, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 187);
	printf("%2c%7s%3c%16s%6c%12s%3c\n", 186, "Combo", 186, "Description", 186, "Price (RM)", 186);
	printf("%2c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c\n", 204, 205, 205, 205, 205, 205, 205, 205, 205, 205, 206, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 206, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 185);
	printf("%2c%5c%5c%18s%4c%10.2f%5c\n", 186, 65, 186, "2 Regular Pizza", 186, COMBOA, 186);
	printf("%2c%10c%17s%5c%15c\n", 186, 186, "1 Soda Bottle", 186, 186);
	printf("%2c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c\n", 204, 205, 205, 205, 205, 205, 205, 205, 205, 205, 206, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 206, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 185);
	printf("%2c%10c%18s%4c%15c\n", 186, 186, "1 Regular Pizza", 186, 186);
	printf("%2c%5c%5c%17s%5c%10.2f%5c\n", 186, 66, 186, "1 Large Pizza", 186, COMBOB, 186);
	printf("%2c%10c%17s%5c%15c\n", 186, 186, "1 Soda Bottle", 186, 186);
	printf("%2c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c\n", 204, 205, 205, 205, 205, 205, 205, 205, 205, 205, 206, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 206, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 185);
	printf("%2c%10c%17s%5c%15c\n", 186, 186, "2 Large Pizza", 186, 186);
	printf("%2c%5c%5c%14s%8c%10.2f%5c\n", 186, 67, 186, "1 Bread", 186, COMBOC, 186);
	printf("%2c%10c%17s%5c%15c\n", 186, 186, "1 Soda Bottle", 186, 186);
	printf("%2c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c\n", 204, 205, 205, 205, 205, 205, 205, 205, 205, 205, 206, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 206, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 185);
	printf("%2c%10c%17s%5c%15c\n", 186, 186, "2 Large Pizza", 186, 186);
	printf("%2c%5c%5c%18s%4c%10.2f%5c\n", 186, 68, 186, "1 Regular Pizza", 186, COMBOD, 186);
	printf("%2c%10c%14s%8c%15c\n", 186, 186, "2 Breads", 186, 186);
	printf("%2c%10c%17s%5c%15c\n", 186, 186, "2 Soda Bottles", 186, 186);
	printf("%2c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c\n", 200, 205, 205, 205, 205, 205, 205, 205, 205, 205, 202, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 202, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 188);
	printf("\n");

	return;
}

void restart()
{
	//To reset the quantity to prevent adding quantity in process function.
	a = 0;
	b = 0;
	c = 0;
	d = 0;

	return;
}

void member()
{
	char member;
	rewind(stdin);
	printf("Member Card? ( Y = yes ) ( N = no ) : "); //ask if have member card
	scanf("%c", &member);

	rewind(stdin);

	if (member == 'Y' || member == 'y') //If have, 10% discount allowed
	{
		memberdis = 10;
		printf("Discount (%d%%) allowed.\n", memberdis);
	}
	else //If don't have, no discount allowed
	{
		memberdis = 0;
	}
	return;
}

void selection()
{
	//Reset amount of combo
	combo = 'A';
	totala = 0;
	totalb = 0;
	totalc = 0;
	totald = 0;
	while (combo>=65 && combo<69)
	{
		rewind(stdin);
		printf("COMBO A,B,C,D (other = exit) : "); //Read Combo
		scanf("%c", &combo);
		rewind(stdin);
		switch (combo)
		{
		case 'A': //choose Combo A
			printf("Quantity     : "); //ask quantity of combo A
			scanf("%d", &a);
			totala = totala + (a * COMBOA);
			printf("%14s: %d @@ RM%2.0f   = RM%8.2f\n", "COMBO A", a, COMBOA, a*COMBOA);
			break;
		case 'B': //choose Combo B
			printf("Quantity     : "); //ask quantity of combo B
			scanf("%d", &b);
			totalb = totalb + (b * COMBOB);
			printf("%14s: %d @@ RM%2.0f   = RM%8.2f\n", "COMBO B", b, COMBOB, b*COMBOB);
			break;
		case 'C': //choose Combo C
			printf("Quantity     : "); //ask quantity of combo C
			scanf("%d", &c);
			totalc = totalc + (c * COMBOC);
			printf("%14s: %d @@ RM%2.0f   = RM%8.2f\n", "COMBO C", c, COMBOC, c*COMBOC);
			break;
		case 'D': //choose Combo D
			printf("Quantity     : "); //ask quantity of combo D
			scanf("%d", &d);
			totald = totald + (d * COMBOD);
			printf("%14s: %d @@ RM%2.0f   = RM%8.2f\n", "COMBO D", d, COMBOD, d*COMBOD);
			break;
		default: //Other will exit combo selection
			break;
		}
	}
	return;
}

void process()
{
	//Calculate Total amount to pay
	ta = ta + a; //ta, tb, tc, td adding for finalresult function
	tb = tb + b;
	tc = tc + c;
	td = td + d;
	subtotal = totala + totalb + totalc + totald; //calculate sub total amount
	tax = subtotal * TAX / 100; //Charge TAX SST 10% on sb total amount
	total = subtotal + tax;
	discount = total * memberdis / 100; //Discount allowed 10% on total if customer have member card
	fdiscount += discount; //add discount allowed for finalresult function
	dtotal = total - discount; //Final amount to pay after calculate

	return;
}

void display()
{
	//Display Payment
	printf("%29s %s RM%8.2f\n", "Combo Charges", "=", subtotal);
	printf("%19s %2.0f%% SST %3s RM%8.2f\n", "Add", TAX, "=", tax);
	printf("%28s %2s RM%8.2f\n", "TOTAL AMOUNT", "=", total);
	printf("%24s %2d%% %2s RM%8.2f\n", "DISCOUNT", memberdis, "=", discount);
	printf("%28s %2s RM%8.2f\n", "TOTAL TO PAY", "=", dtotal);
	do
	{
		printf("%27s %3s RM  ", "Amount Paid", "="); //read amount paid
		scanf("%lf", &paid);
		if (paid<dtotal) //If amount paid is less than amount to pay
		{
			printf("%36s\n", "======================");
			printf("%34s\n", "No Enough Money!!!");
			printf("%35s\n", "Please pay again!!!");
			printf("%36s\n", "======================");
		}
	} while (paid<dtotal); //If amount paid is less than amount to pay, will repeat this function until amount paid is greater than amount to pay
	due = paid - dtotal; //If amount paid is greater than amount to pay , will calculate change due for give
	printf("%26s %4s RM%8.2f\n", "Change Due", "=", due);
	return;
}

void goodbye()
{
	//Display Thank You
	printf("\n");
	printf("%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c\n", 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205);
	printf("%4c%c%c%c%c%2c%4c%4c%4c%c%6c%2c%3c%c%5c%4c%2c%c%c%c%c%2c%4c\n", 178, 178, 178, 178, 178, 178, 178, 178, 178, 178, 178, 178, 178, 178, 178, 178, 178, 178, 178, 178, 178, 178, 178, 178);
	printf("%6c%4c%4c%3c%c%c%3c%c%c%5c%2c%2c%c%6c%4c%2c%4c%2c%4c\n", 178, 178, 178, 178, 178, 178, 178, 178, 178, 178, 178, 178, 178, 178, 178, 178, 178, 178, 178);
	printf("%6c%4c%4c%2c%c%2c%c%2c%2c%c%4c%2c%c%c%7c%c%2c%c%2c%4c%2c%4c\n", 178, 178, 178, 178, 178, 178, 178, 178, 178, 178, 178, 178, 178, 178, 178, 178, 178, 178, 178, 178, 178, 178, 178, 178);
	printf("%6c%4c%c%c%c%c%2c%4c%2c%3c%c%3c%2c%c%9c%c%c%3c%4c%2c%4c\n", 178, 178, 178, 178, 178, 178, 178, 178, 178, 178, 178, 178, 178, 178, 178, 178, 178, 178, 178, 178, 178);
	printf("%6c%4c%4c%2c%c%c%c%c%2c%4c%c%2c%2c%c%c%9c%4c%4c%2c%4c\n", 178, 178, 178, 178, 178, 178, 178, 178, 178, 178, 178, 178, 178, 178, 178, 178, 178, 178, 178, 178);
	printf("%6c%4c%4c%2c%4c%2c%5c%c%c%2c%2c%c%8c%4c%4c%2c%4c\n", 178, 178, 178, 178, 178, 178, 178, 178, 178, 178, 178, 178, 178, 178, 178, 178, 178);
	printf("%6c%4c%4c%2c%4c%2c%6c%c%2c%3c%c%7c%4c%c%c%c%c%2c%c%c%c%c\n", 178, 178, 178, 178, 178, 178, 178, 178, 178, 178, 178, 178, 178, 178, 178, 178, 178, 178, 178, 178, 178, 178);
	printf("%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c\n", 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205, 205);
	printf("\n");
	return;
}

void finalresultprocess()
{
	//Final calculation for closing store
	ftotala = ta * COMBOA; //to calculate final amount of all combo with final quantity of all combo
	ftotalb = tb * COMBOB;
	ftotalc = tc * COMBOC;
	ftotald = td * COMBOD;
	ft = ta + tb + tc + td; //calculate total quantity of all combo and total amount of all combo
	fstotal = ftotala + ftotalb + ftotalc + ftotald;
	ftax = fstotal * TAX / 100; //calculate TAX SST charge
	fgtotal = fstotal + ftax; //calcalate total amount
	ftotal = fgtotal - fdiscount; //calculate final total amount after minus total discount allowed

	return;
}

void finalresult()
{
	memberdis = 10; //Set back member discount = 10
	//Display Daily Sales Report
	printf("\n\n");
	printf("=======================================================\n");
	printf("DAILY SALES REPORT\n\n");
	printf("Total Number of Customers = %d \n\n", --ac); //To prevent add one more extra null customer
	printf("Combo Sales For Today\n\n");
	printf("%5s%16s%15s\n", "Combo", "Quantity Sold", "Sales Amount");
	printf("%5s%16s%15s\n", "=====", "=============", "============");
	printf("%3s%12d%20.2f\n", "A", ta, ftotala);
	printf("%3s%12d%20.2f\n", "B", tb, ftotalb);
	printf("%3s%12d%20.2f\n", "C", tc, ftotalc);
	printf("%3s%12d%20.2f\n", "D", td, ftotald);
	printf("%5s%16s%15s\n", "=====", "=============", "============");
	printf("%6s%9d%20.2f\n\n", "TOTALS", ft, fstotal);
	printf("%22s%2s%11.2f\n", "TOTAL SST charges", "=", ftax);
	printf("%22s%2s%11.2f\n", "ORIGINAL TOTAL", "=", fgtotal);
	printf("%18s%3d%%%2s%11.2f\n", "DISCOUNT ALLOWED", memberdis, "=", fdiscount);
	printf("%22s%2s%11.2f\n\n\n", "TOTAL RM COLLECTED", "=", ftotal);

	return;
}

void closing()
{
	//Display Closing message
	printf("%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c\n", 240, 240, 240, 240, 240, 240, 240, 240, 240, 240, 240, 240, 240, 240, 240, 240, 240, 240, 240, 240, 240, 240, 240, 240, 240, 240, 240, 240, 240, 240, 240, 240, 240, 240, 240, 240, 240, 240, 240, 240, 240, 240, 240, 240, 240, 240, 240);
	printf("%3c%c%c%c%c%2c%6c%c%c%c%c%2c%c%c%c%c%2c%c%c%c%c%2c%c%5c%2c%c%c%c%c\n", 178, 178, 178, 178, 178, 178, 178, 178, 178, 178, 178, 178, 178, 178, 178, 178, 178, 178, 178, 178, 178, 178, 178, 178, 178, 178, 178, 178, 178);
	printf("%3c%6c%6c%4c%2c%8c%4c%c%c%4c%2c\n", 178, 178, 178, 178, 178, 178, 178, 178, 178, 178, 178);
	printf("%3c%6c%6c%4c%2c%8c%4c%2c%4c%2c\n", 178, 178, 178, 178, 178, 178, 178, 178, 178, 178);
	printf("%3c%6c%6c%4c%2c%8c%4c%2c%c%3c%2c\n", 178, 178, 178, 178, 178, 178, 178, 178, 178, 178, 178);
	printf("%3c%6c%6c%4c%2c%c%c%c%c%4c%4c%3c%3c%2c\n", 178, 178, 178, 178, 178, 178, 178, 178, 178, 178, 178, 178, 178, 178);
	printf("%3c%6c%6c%4c%6c%4c%4c%3c%c%2c%2c%2c%c%c\n", 178, 178, 178, 178, 178, 178, 178, 178, 178, 178, 178, 178, 178, 178);
	printf("%3c%6c%6c%4c%6c%4c%4c%4c%2c%2c%4c\n", 178, 178, 178, 178, 178, 178, 178, 178, 178, 178, 178);
	printf("%3c%6c%6c%4c%6c%4c%4c%4c%c%c%2c%4c\n", 178, 178, 178, 178, 178, 178, 178, 178, 178, 178, 178, 178, 178);
	printf("%3c%c%c%c%c%2c%c%c%c%c%2c%c%c%c%c%2c%c%c%c%c%2c%c%c%c%c%2c%5c%c%2c%c%c%c%c\n", 178, 178, 178, 178, 178, 178, 178, 178, 178, 178, 178, 178, 178, 178, 178, 178, 178, 178, 178, 178, 178, 178, 178, 178, 178, 178, 178, 178, 178, 178, 178, 178, 178);
	printf("%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c%c\n\n", 240, 240, 240, 240, 240, 240, 240, 240, 240, 240, 240, 240, 240, 240, 240, 240, 240, 240, 240, 240, 240, 240, 240, 240, 240, 240, 240, 240, 240, 240, 240, 240, 240, 240, 240, 240, 240, 240, 240, 240, 240, 240, 240, 240, 240, 240, 240);
	return;
}