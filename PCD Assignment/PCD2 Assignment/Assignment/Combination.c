#include <stdio.h>
#include <stdlib.h>
#pragma warning (disable : 4996)

void Logo()
{
	int i;
	for (i = 0; i < 30; i++)
	{
		printf("=");
	}
	printf("\n\tFamily Clinic\n");
	for (i = 0; i < 30; i++)
	{
		printf("=");
	}
	printf("\n\n\n");
}
void Menu(int *code)
{
	printf("Clinic Module\n");
	printf("=======================\n");
	printf("1.Patient Information\n");
	printf("2.Patient Visit\n");
	printf("3.Staff Information\n");
	printf("4.Medical Supplies\n");
	printf("5.Exit Program\n");
	printf("=======================\n");
	printf("Enter an index number to call!\n");
	printf("CODE ----> ");
	scanf("%d", &*code);
	rewind(stdin);
}
//Display All Menu of Clinic

void patientVisit();
void MedicalSupplies();

void main()
{
	int code;
	do
	{
		system("cls");
		Logo();
		Menu(&code);
		switch (code)
		{
		case 1:
			break;
		case 2:
			patientVisit(); //Call PatientVisit
			break;
		case 3:
			break;
		case 4:
			MedicalSupplies(); //Call MedicalSupplies
			break;
		case 5:
			printf("\nExiting Clinic Program.\n"); //Exiting Program
			system("pause");
			break;
		default:
			printf("\nInvalid Input Code , Please type again!!!\n"); //Invalid Input, error message
			system("pause");
			break;
		}
	} while (code != 5);
}