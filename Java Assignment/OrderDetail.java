/**
 * @(#)OrderDetail.java
 *
 *
 * @author 
 * @version 1.00 2019/8/6
 */
package structure;
import java.util.Date;

public class OrderDetail {

    private String orderID;
    private Membership membercard = new Membership();
    private Voucher[] voucher = new Voucher[0];
    private Product[] product = new Product[0];
    private double totalAmount = 0;
    private double subTotalAmount = 0;
    private double discountAllowed = 0;
    private double memberCardPrice = 0;
    private double cashReduced = 0;
    private static int noOfOrder;
    private double finalAmount = 0;
    private double rounding = 0;
    private final double tax = 0.1;

    public OrderDetail() {
        if (noOfOrder < 9) {
            this.orderID = "O" + getDateFormat() + "00" + +(noOfOrder + 1);
        } else if (noOfOrder >= 9 && noOfOrder < 99) {
            this.orderID = "O" + getDateFormat() + "0" + (noOfOrder + 1);
        } else if (noOfOrder >= 99 && noOfOrder < 999) {
            this.orderID = "O" + getDateFormat() + (noOfOrder + 1);
        } else {
            System.out.print("This order array is full\n");
            return;
        }
        noOfOrder++;
    }

    public String getDateFormat() {
        Date date = new Date();
        String s;
        s = "" + (date.getYear() + 1900);
        if (date.getMonth() < 9) {
            s = s.concat("0" + (date.getMonth() + 1));
        } else {
            s = s.concat("" + (date.getMonth() + 1));
        }

        if (date.getDate() < 10) {
            s = s.concat("0" + (date.getDate()));
        } else {
            s = s.concat("" + (date.getDate()));
        }
        return s;
    }

    public double getTotal() {
        return totalAmount;
    }

    public double getcashReduced() {
        return cashReduced;
    }

    public String getID() {
        return orderID;
    }

    public double getDiscount() {
        return discountAllowed;
    }

    public double getTax() {
        return tax;
    }

    public double getRounding() {
        return rounding;
    }

    public double getSubTotal() {
        return subTotalAmount;
    }

    public Product getproduct(int i) {
        return product[i];
    }

    public int getproductLength() {
        return product.length;
    }

    public double getFinal() {
        return finalAmount;
    }

    public double getCardPrice() {
        return memberCardPrice;
    }

    public void setRounding(double rounding) {
        this.rounding = rounding;
    }

    public void setFinal(double finalAmount) {
        this.finalAmount = finalAmount;
    }

    public void setID(String orderID) {
        this.orderID = orderID;
    }

    public void setCardPrice(double amount) {
        memberCardPrice = amount;
    }

    public double calAmount(Food[] food, Drink[] drink, Dessert[] dessert, int i) {
        if (product[i] instanceof Food) {
            for (int j = 0; j < food.length; j++) {
                if (product[i].getID().equals(food[j].getID())) {
                    return product[i].getQuantity() * food[j].getUnitPrice();
                }
            }
        } else if (product[i] instanceof Drink) {
            for (int j = 0; j < drink.length; j++) {
                if (product[i].getID().equals(drink[j].getID())) {
                    return product[i].getQuantity() * drink[j].getUnitPrice();
                }
            }
        } else if (product[i] instanceof Dessert) {
            for (int j = 0; j < dessert.length; j++) {
                if (product[i].getID().equals(dessert[j].getID())) {
                    return product[i].getQuantity() * dessert[j].getUnitPrice();
                }
            }
        }
        return 0;
    }

    public void calSubTotal() {
        subTotalAmount = totalAmount + (totalAmount * tax);
    }

    public void calTotal(Food[] food, Drink[] drink, Dessert[] dessert) {
        for (int i = 0; i < product.length; i++) {
            if (product[i] instanceof Food) {
                for (int j = 0; j < food.length; j++) {
                    if (product[i].getID().equals(food[j].getID())) {
                        totalAmount += product[i].getQuantity() * food[j].getUnitPrice();
                    }
                }
            } else if (product[i] instanceof Drink) {
                for (int j = 0; j < drink.length; j++) {
                    if (product[i].getID().equals(drink[j].getID())) {
                        totalAmount += product[i].getQuantity() * drink[j].getUnitPrice();
                    }
                }
            } else if (product[i] instanceof Dessert) {
                for (int j = 0; j < dessert.length; j++) {
                    if (product[i].getID().equals(dessert[j].getID())) {
                        totalAmount += product[i].getQuantity() * dessert[j].getUnitPrice();
                    }
                }
            }

        }
        if (memberCardPrice != 0) {
            totalAmount += memberCardPrice;
        }
    }

    public void addQuantity(Food[] food, Drink[] drink, Dessert[] dessert) {
        for (int i = 0; i < product.length; i++) {
            if (product[i] instanceof Food) {
                for (int j = 0; j < food.length; j++) {
                    if (product[i].getID().equals(food[j].getID())) {
                        //addMealquantity(j,1,product[i].getQuantity());
                    }
                }
            } else if (product[i] instanceof Drink) {
                for (int j = 0; j < drink.length; j++) {
                    if (product[i].getID().equals(drink[j].getID())) {
                        //addMealquantity(j,2,product[i].getQuantity());
                    }
                }
            } else if (product[i] instanceof Dessert) {
                for (int j = 0; j < dessert.length; j++) {
                    if (product[i].getID().equals(dessert[j].getID())) {
                        //addMealquantity(j,3,product[i].getQuantity());
                    }
                }
            }

        }
    }

    public double calDiscount() {
        return subTotalAmount * discountAllowed;
    }

    public double calGrandTotal() {
        return subTotalAmount - (subTotalAmount * discountAllowed) - cashReduced;
    }

    public void calVoucher() {
        for (int i = 0; i < voucher.length; i++) {
            cashReduced += voucher[i].getVoucherPrice();
        }
    }

    public void addAnnDiscount(Anniversary date) {
        Date currentDate = new Date();
        if ((currentDate.getMonth() + 1) == date.getMonth()) {
            if (currentDate.getDate() == date.getDay()) {
                discountAllowed += date.getAnnDiscount();
            } else {
                discountAllowed += 0;
            }
        } else {
            discountAllowed += 0;
        }
    }

    public void displayReceipt(Food[] food, Drink[] drink, Dessert[] dessert, double amountPaid, String staff) {
        System.out.print("\nStarduck Cafe\n");
        System.out.print("============================\n");
        System.out.printf("%-10s : %10s %29s : %10s\n", "Order No", getID(), "Staff ID", staff);
        System.out.printf("%-30s %-10s %-15s %-13s\n", "Product Ordered", "Quantity", "Unit Price(RM)", "Amount(RM)");
        System.out.printf("%-30s %-10s %-15s %-13s\n", "===============", "========", "==============", "==========");
        if (memberCardPrice != 0) {
            System.out.printf("%-30s %8d %16.2f %11.2f\n", "Member card Price", 1, 20.0, memberCardPrice);
        }
        for (int i = 0; i < product.length; i++) {
            if (product[i] instanceof Food) {
                for (int j = 0; j < food.length; j++) {
                    if (product[i].getID().equals(food[j].getID())) {
                        System.out.printf("%-30s %8d %16.2f %11.2f\n", product[i].getDescription(), product[i].getQuantity(), food[j].getUnitPrice(), calAmount(food, drink, dessert, i));
                    }
                }
            } else if (product[i] instanceof Drink) {
                for (int j = 0; j < drink.length; j++) {
                    if (product[i].getID().equals(drink[j].getID())) {
                        System.out.printf("%-30s %8d %16.2f %11.2f\n", product[i].getDescription(), product[i].getQuantity(), drink[j].getUnitPrice(), calAmount(food, drink, dessert, i));
                    }
                }
            } else if (product[i] instanceof Dessert) {
                for (int j = 0; j < dessert.length; j++) {
                    if (product[i].getID().equals(dessert[j].getID())) {
                        System.out.printf("%-30s %8d %16.2f %11.2f\n", product[i].getDescription(), product[i].getQuantity(), dessert[j].getUnitPrice(), calAmount(food, drink, dessert, i));
                    }
                }
            }
        }
        System.out.print("====================================================================\n");
        System.out.printf("%-20s%40s %7.2f\n", "Receipt : ", "Total : RM", getTotal());
        System.out.printf("%60s %7.2f\n", "SST (10%): RM", (getTotal() * getTax()));
        System.out.printf("%60s %7.2f\n", "SubTotal : RM", getSubTotal());
        System.out.printf("%60s %7.2f\n", "Discount Allowed : RM", calDiscount());
        System.out.printf("%60s %7.2f\n", "Cash Reduced (Voucher) : RM", getcashReduced());
        System.out.printf("%60s %7.2f\n", "Grand Total : RM", calGrandTotal());
        System.out.printf("%60s %7.2f\n", "Rounding : RM", rounding);
        System.out.printf("%60s %7.2f\n", "Rounding Grand Total : RM", finalAmount);
        System.out.printf("%60s %7.2f\n", "Amount Paid : RM", amountPaid);
        System.out.printf("%60s %7.2f\n", "Change Due : RM", (amountPaid - finalAmount));
        System.out.print("====================================================================\n");
        System.out.printf("%45s", "Thank you for coming!\n");
        System.out.printf("%50s", "Please Like our Facebook Page!\n\n");
    }

    public void tableDisplay(Food[] food, Drink[] drink, Dessert[] dessert,String staff) {
        System.out.printf("%-10s : %10s %29s : %10s\n", "Order No", getID(), "Staff ID", staff);
        System.out.printf("%-30s %-10s %-15s %-13s\n", "Product Ordered", "Quantity", "Unit Price(RM)", "Amount(RM)");
        System.out.printf("%-30s %-10s %-15s %-13s\n", "===============", "========", "==============", "==========");
        if (memberCardPrice != 0) {
            System.out.printf("%-30s %8d %16.2f %11.2f\n", "Member card Price", 1, 20.0, memberCardPrice);
        }
        for (int i = 0; i < product.length; i++) {
            if (product[i] instanceof Food) {
                for (int j = 0; j < food.length; j++) {
                    if (product[i].getID().equals(food[j].getID())) {
                        System.out.printf("%-30s %8d %16.2f %11.2f\n", product[i].getDescription(), product[i].getQuantity(), food[j].getUnitPrice(), calAmount(food, drink, dessert, i));
                    }
                }
            } else if (product[i] instanceof Drink) {
                for (int j = 0; j < drink.length; j++) {
                    if (product[i].getID().equals(drink[j].getID())) {
                        System.out.printf("%-30s %8d %16.2f %11.2f\n", product[i].getDescription(), product[i].getQuantity(), drink[j].getUnitPrice(), calAmount(food, drink, dessert, i));
                    }
                }
            } else if (product[i] instanceof Dessert) {
                for (int j = 0; j < dessert.length; j++) {
                    if (product[i].getID().equals(dessert[j].getID())) {
                        System.out.printf("%-30s %8d %16.2f %11.2f\n", product[i].getDescription(), product[i].getQuantity(), dessert[j].getUnitPrice(), calAmount(food, drink, dessert, i));
                    }
                }
            }
        }
        System.out.print("====================================================================\n");
        System.out.printf("%60s %7.2f\n", "Total : RM", getTotal());
        System.out.printf("%60s %7.2f\n", "SubTotal : RM", getSubTotal());
        System.out.printf("%60s %7.2f\n", "Discount Allowed : RM", calDiscount());
        System.out.printf("%60s %7.2f\n", "Cash Reduced : RM", getcashReduced());
        System.out.printf("%60s %7.2f\n", "Grand Total : RM", calGrandTotal());
        System.out.printf("%60s %7.2f\n", "Rounding Grand Total : RM", finalAmount);
        System.out.print("====================================================================\n\n\n");
    }

    public void membershipValid(String memberID, String name, String cardNum) {
        membercard.membershipValid(memberID, name, cardNum);
        discountAllowed += membercard.getDiscount();
    }

    public void productOrder(String mealID, String description, int quantity) {
        Product[] newProduct = new Product[product.length + 1];
        System.arraycopy(product, 0, newProduct, 0, product.length);
        product = newProduct;
        switch (mealID.charAt(0)) {
            case 'F':
                product[product.length - 1] = new Food(mealID, description, quantity);
                break;
            case 'D':
                product[product.length - 1] = new Drink(mealID, description, quantity);
                break;
            case 'I':
                product[product.length - 1] = new Dessert(mealID, description, quantity);
                break;
            default:
                break;
        }
    }

    public void voucherAccept(String code, double cash) {
        Voucher[] newvoucher = new Voucher[voucher.length + 1];
        System.arraycopy(voucher, 0, newvoucher, 0, voucher.length);
        voucher = newvoucher;
        voucher[voucher.length - 1] = new Voucher(code, cash);
    }

    public void removeOrder() {
        noOfOrder--;
    }
}