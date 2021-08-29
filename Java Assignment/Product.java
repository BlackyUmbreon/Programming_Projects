/**
 * @(#)Product.java
 *
 *
 * @author 
 * @version 1.00 2019/7/30
 */

package structure;

public class Product {

    private String mealID;
    private String description;
    private int quantity;
    private double unitPrice;
    private static int noOfProduct;

    public Product() {

    }

    public Product(String mealID, String description, int quantity) {
        this.mealID = mealID;
        this.description = description;
        this.quantity = quantity;
    }

    public Product(int noOfMeal, char name, String description, int quantity, double unitPrice) {
        if (noOfMeal < 9) {
            this.mealID = name + "00" + (noOfMeal + 1);
        } else if (noOfMeal >= 9 && noOfMeal < 99) {
            this.mealID = name + "0" + (noOfMeal + 1);
        } else if (noOfMeal >= 99 && noOfMeal < 999) {
            this.mealID = name + "" + (noOfMeal + 1);
        } else {
            System.out.print("This food array is full\n");
            return;
        }
        this.description = description;
        this.quantity = quantity;
        this.unitPrice = unitPrice;
        noOfProduct++;
    }

    public String getID() {
        return mealID;
    }

    public String getDescription() {
        return description;
    }

    public int getQuantity() {
        return quantity;
    }

    public double getUnitPrice() {
        return unitPrice;
    }

    public void setDescription(String description) {
        this.description = description;
    }

    public void setUnitPrice(double unitPrice) {
        this.unitPrice = unitPrice;
    }

    public void setID(String mealID) {
        this.mealID = mealID;
    }

    public void restock(int quantity) {
        this.quantity += quantity;
    }

    public static void removeProduct() {
        noOfProduct--;

    }

    public static int getnoOfProduct() {
        return noOfProduct;
    }

    public String tableDisplay() {
        String s1 = String.format("%-10s %-40s %-11d RM%9.2f", mealID, description, quantity, unitPrice);
        return s1;
    }

    public double calculatePrice(int quantitySold) {
        return unitPrice * quantitySold;
    }
}