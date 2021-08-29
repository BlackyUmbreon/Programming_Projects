/**
 * @(#)Dessert.java
 *
 *
 * @author 
 * @version 1.00 2019/7/30
 */

package structure;
public class Dessert extends Product {

    private static int noOfDessert;
    private static char name = 'I';

    public Dessert(String mealID, String description, int quantity) {
        super(mealID, description, quantity);
    }

    public Dessert(String description, int quantity, double unitPrice) {
        super(noOfDessert, name, description, quantity, unitPrice);
        noOfDessert++;
    }

    public static void removeMeal() {
        noOfDessert--;
    }

    public String toString() {
        return "\nDessert ID : " + getID() + "\nDessert Description : " + getDescription() + "\nDessert Quantity    : " + getQuantity() + "\nDessert Unit Price  : RM" + String.format("%.2f", getUnitPrice()) + "\n\n\n";
    }


}