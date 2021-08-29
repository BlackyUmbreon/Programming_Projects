/**
 * @(#)Food.java
 *
 *
 * @author 
 * @version 1.00 2019/7/18
 */
package structure;
public class Food extends Product {

    private static int noOfFood;
    private static char name = 'F';

    public Food(String mealID, String description, int quantity) {
        super(mealID, description, quantity);
    }

    public Food(String description, int quantity, double unitPrice) {
        super(noOfFood, name, description, quantity, unitPrice);
        noOfFood++;
    }

    public static void removeMeal() {
        noOfFood--;
    }

    public String toString() {
        return "\nFood ID : " + getID() + "\nFood Description : " + getDescription() + "\nFood Quantity    : " + getQuantity() + "\nFood Unit Price  : RM" + String.format("%.2f", getUnitPrice()) + "\n\n\n";
    }
}