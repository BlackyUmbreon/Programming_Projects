/**
 * @(#)salesReport.java
 *
 *
 * @author 
 * @version 1.00 2019/8/5
 */
package structure;

public class salesReport {

    private static int[] foodQuantity;
    private static int[] drinkQuantity;
    private static int[] dessertQuantity;
    private static double taxRate = 0.1;
    private double totaldiscount = 0;
    private double totalcashReduced = 0;
    private double[] total = {
        0,
        0,
        0
    };
    private double cardTotal = 0;
    private double grandTotal = 0;
    private double finalTotal = 0;
    private double totalRounding = 0;
    private Food[] food;
    private Drink[] drink;
    private Dessert[] dessert;

    public salesReport(Food[] food, Drink[] drink, Dessert[] dessert) {
        this.food = food;
        this.drink = drink;
        this.dessert = dessert;
        createArray();
    }

    public void createArray() {
        foodQuantity = new int[food.length];
        drinkQuantity = new int[drink.length];
        dessertQuantity = new int[dessert.length];
    }

    public double getTotal(int type) {
        return total[type];
    }

    public void addTotal(double amount, int type) {
        if (type == 1) {
            total[0] += amount;
        } else if (type == 2) {
            total[1] += amount;
        } else if (type == 3) {
            total[2] += amount;
        }
    }

    public void addMemberCard(double amount) {
        cardTotal += amount;
    }

    public void calculateGrandTotal() {
        for (double value: total) {
            grandTotal += value;
        }
    }

    public void addGrandTotal() {
        grandTotal += cardTotal;
    }

    public double getGrandTotal() {
        return grandTotal;
    }

    public void addMealQuantity(int index, int type, int quantity) {
        if (type == 1) {
            foodQuantity[index] += quantity;
        } else if (type == 2) {
            drinkQuantity[index] += quantity;
        } else if (type == 3) {
            dessertQuantity[index] += quantity;
        }
    }

    public void adddiscount(double amount) {
        totaldiscount += amount;
    }

    public void addcashReduce(double amount) {
        totalcashReduced += amount;
    }

    public void addRounding(double amount) {
        totalRounding += amount;
    }

    public double calculateTotalSold(int i, int type) {
        if (type == 1) {
            return food[i].calculatePrice(foodQuantity[i]);
        } else if (type == 2) {
            return drink[i].calculatePrice(drinkQuantity[i]);
        } else if (type == 3) {
            return dessert[i].calculatePrice(dessertQuantity[i]);
        }
        return 0;
    }

    public void tableDisplay() {
        System.out.print("-Product Sales Report-\n");
        System.out.print("=============================================\n");
        System.out.print("\nFood Quantity Sold\n");
        System.out.print("\n" + String.format("%-10s %-40s %-20s %-13s %-15s", "Food ID", "Food Name", "Quantity Sold", "Unit Price", "Amount"));
        System.out.print("\n" + String.format("%-10s %-40s %-20s %-13s %-15s\n", "==========", "=======================================", "====================", "==========", "=========="));
        for (int value = 0; value < food.length; value++) {
            System.out.printf("%-10s %-40s %20d RM%8.2f    RM%8.2f\n", food[value].getID(), food[value].getDescription(), foodQuantity[value], food[value].getUnitPrice(), calculateTotalSold(value, 1));
            addTotal(calculateTotalSold(value, 1), 1);
        }
        System.out.print("=================================================================================================\n");
        System.out.printf("%86s RM%8.2f\n", "Food Total Amount :", getTotal(0));
        System.out.print("\nDrink Quantity Sold\n");
        System.out.print("\n" + String.format("%-10s %-40s %-20s %-13s %-15s", "Drink ID", "Drink Name", "Quantity Sold", "Unit Price", "Amount"));
        System.out.print("\n" + String.format("%-10s %-40s %-20s %-13s %-15s\n", "==========", "======================================", "====================", "==========", "=========="));
        for (int value = 0; value < drink.length; value++) {
            System.out.printf("%-10s %-40s %20d RM%8.2f    RM%8.2f\n", drink[value].getID(), drink[value].getDescription(), drinkQuantity[value], drink[value].getUnitPrice(), calculateTotalSold(value, 2));
            addTotal(calculateTotalSold(value, 2), 2);
        }
        System.out.print("=================================================================================================\n");
        System.out.printf("%86s RM%8.2f\n", "Drink Total Amount :", getTotal(1));
        System.out.print("\nDessert Quantity Sold\n");
        System.out.print("\n" + String.format("%-10s %-40s %-20s %-13s %-15s", "Dessert ID", "Dessert Name", "Quantity Sold", "Unit Price", "Amount"));
        System.out.print("\n" + String.format("%-10s %-40s %-20s %-13s %-15s\n", "==========", "=======================================", "====================", "==========", "=========="));
        for (int value = 0; value < dessert.length; value++) {
            System.out.printf("%-10s %-40s %20d RM%8.2f    RM%8.2f\n", dessert[value].getID(), dessert[value].getDescription(), dessertQuantity[value], dessert[value].getUnitPrice(), calculateTotalSold(value, 3));
            addTotal(calculateTotalSold(value, 3), 3);
        }
        System.out.print("=================================================================================================\n");
        System.out.printf("%86s RM%8.2f\n", "Dessert Total Amount :", getTotal(2));
        System.out.print("\n=================================================================================================\n");
        calculateGrandTotal();
        System.out.printf("%86s RM%8.2f\n", "Product Total Amount :", getGrandTotal());
        System.out.printf("%86s RM%8.2f\n", "Total memberCard Sold Amount :", cardTotal);
        addGrandTotal();
        System.out.printf("%86s RM%8.2f\n", "Total Amount :", getGrandTotal());
        System.out.printf("%86s RM%8.2f\n", "SST Amount :", getGrandTotal() * taxRate);
        System.out.printf("%86s RM%8.2f\n", "SubTotal Amount :", getGrandTotal() + (getGrandTotal() * taxRate));
        System.out.printf("%86s RM%8.2f\n", "Total Discount Allowed :", totaldiscount);
        System.out.printf("%86s RM%8.2f\n", "Total Cash reduced :", totalcashReduced);
        finalTotal = (getGrandTotal() + (getGrandTotal() * taxRate)) - totaldiscount - totalcashReduced;
        System.out.printf("%86s RM%8.2f\n", "Total GrandTotal amount :", finalTotal);
        System.out.printf("%86s RM%8.2f\n", "Total Rounding amount :", totalRounding);
        System.out.printf("%86s RM%8.2f\n", "Total Rounded GrandTotal amount :", finalTotal + totalRounding);
    }

}