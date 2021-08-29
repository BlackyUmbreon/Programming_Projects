D/**
 * @(#)Drink.java
 *
 *
 * @author 
 * @version 1.00 2019/7/19
 */
package structure;
public class Drink extends Product {

    private static int noOfDrink;
    private static char name = 'D';

    public Drink(String mealID, String description, int quantity) {
        super(mealID, description, quantity);
    }

    public Drink(String description, int quantity, double unitPrice) {
        super(noOfDrink, name, description, quantity, unitPrice);
        noOfDrink++;
    }

    public static void removeMeal() {
        noOfDrink--;
    }

    public String toString() {
        return "\nDrink ID : " + getID() + "\nDrink Description : " + getDescription() + "\nDrink Quantity    : " + getQuantity() + "\nDrink Unit Price  : RM" + String.format("%.2f", getUnitPrice()) + "\n\n\n";
    }

}