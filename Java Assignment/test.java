/**
 * @(#)test.java
 *
 *
 * @author 
 * @version 1.00 2019/7/18
 */
package structure;
import java.util.Scanner;
import java.util.Date;

public class test {
    //For Initialize Object Declared
    public static Food[] food = {
        new Food("Creamy Cheese Spaghetti", 10, 23.00),
        new Food("Paella", 20, 44.90),
        new Food("Mushroom Chicken Rice", 25, 18.90),
        new Food("Risotto", 10, 15.90),
        new Food("Double-SmokedBacon", 25, 28.50),
        new Food("Marcato", 20, 32.90)
    };
    public static Drink[] drink = {
        new Drink("Expresso", 50, 15.60),
        new Drink("Dark Mocha Frappuccino", 40, 17.80),
        new Drink("Passion fruit Tea", 50, 15.60),
        new Drink("Cappucino", 50, 16.30),
        new Drink("Green Tea Frappuccino", 40, 17.80),
        new Drink("Americano Brewed Coffee", 30, 16.30),
        new Drink("White Latte", 40, 15.60),
        new Drink("Chocolate Chip Cream", 30, 17.80),
        new Drink("Caramel Frappuccino", 20, 17.80),
        new Drink("Cold brew with Cascara", 30, 16.30),
        new Drink("Strawberry Frappuccino", 10, 17.80)
    };
    public static Dessert[] dessert = {
        new Dessert("Tiramishu Cake with Chocolate Chip", 50, 13.50),
        new Dessert("Black Forest with Dark Coffee", 50, 16.80),
        new Dessert("Fruit and Mango Yogurt Cake", 40, 17.50),
        new Dessert("Blueberry Cheese Cake", 30, 12.60),
        new Dessert("Red Velvet Cake", 20, 13.10),
        new Dessert("New York Cheese Cake", 40, 14.10),
        new Dessert("Expresso Chocolate Chip Brownies", 20, 18.50),
        new Dessert("Skinny Banana Muffin", 30, 9.80),
        new Dessert("Butterfly Biscuit", 50, 6.90),
        new Dessert("Creamy Milk Chesse Cake with OREO", 20, 15.40)
    };
    public static Membership[] member = {
        new Membership("Lim Wei Yang", "MMM000331"),
        new Membership("Quek Wei Xuan", "MMM000362"),
        new Membership("Lim Lian Hong", "MMM000716"),
        new Membership("Lo Yee Chang", "MMM000012"),
        new Membership("Liew Zhen He", "MMM000992"),
        new Membership("Julia Adriana", "MMM000512"),
        new Membership("Ting Tze Jian", "MMM000990"),
        new Membership("Siah Wei Kang", "MMM000101"),
        new Membership("Len Chun Yi", "MMM000450"),
        new Membership("Chin Kai Lun", "MMM000528")
    };
    public static NormalStaff[] nStaff = {
        new NormalStaff("Gabriel Liew", "jiejie1124", "Waiter"),
        new NormalStaff("Andy Yap", "quek1122", "Waiter"),
        new NormalStaff("Dickson Ooi", "Ooided12", "Waiter"),
        new NormalStaff("Brenden Loh", "LohM123", "Waiter")
    };
    public static HighLevelManagement[] hStaff = {
        new HighLevelManagement("Daniel Soh", "qswaqswa123", "Supervisor"),
        new HighLevelManagement("Jassie Lim", "Lim1155", "Supervisor"),
        new HighLevelManagement("Reuben Moo", "Moo1114", "Manager"),
        new HighLevelManagement("Paul Lee", "Lee1144", "Manager")
    };
    public static Anniversary date = new Anniversary();
    public static OrderDetail[] order = new OrderDetail[0];
    public static salesReport report;
    public static String trueID;

    public test() {}

    //For Login Validation
    public static String login() {
        Scanner input = new Scanner(System.in);
        String userID, password;
        boolean valid = false;
        int typeofValid = -1;
        do {
            System.out.printf("%25s\n", "Starduck Cafe");
            System.out.print("==========================================\n");
            System.out.print("Enter User ID (With \'-1\' at first 2 characters is exit): ");
            userID = input.nextLine();
            if (userID.substring(0, 2).equals("-1")) {
                System.exit(0);
            } else {
                System.out.print("Password : ");
                password = input.nextLine();
                typeofValid = loginValidation(userID, password);
                if (typeofValid == 1) {
                    valid = true;
                } else if (typeofValid == 2) {
                    System.out.print("\nYour password is Incorrect!\n");
                    valid = false;
                } else if (typeofValid == 3 || typeofValid == 4) {
                    System.out.print("\nYour user Id doesn\'t exist!\n");
                    valid = false;
                } else {
                    valid = false;
                }
            }
        } while (!valid);
        return userID;
    }
    public static int loginValidation(String staffID, String password) {
        if (staffID.charAt(0) == 'N') {
            for (int i = 0; i < nStaff.length; i++) {
                if (staffID.equals(nStaff[i].getStaffID())) {
                    if (password.equals(nStaff[i].getPassword())) {
                        return 1;
                    } else {
                        return 2;
                    }
                }
            }
        } else if (staffID.charAt(0) == 'H') {
            for (int i = 0; i < hStaff.length; i++) {
                if (staffID.equals(hStaff[i].getStaffID())) {
                    if (password.equals(hStaff[i].getPassword())) {
                        return 1;
                    } else {
                        return 2;
                    }
                }
            }
        } else {
            return 4;
        }
        return 3;

    }
    public static int positionClass(String staffID) {
        if (staffID.charAt(0) == 'N') {
            return 1;
        } else if (staffID.charAt(0) == 'H') {
            return 2;
        } else {
            return -1;
        }
    }
    public static int selection() {
        String name = "";
        boolean datatype = true;
        int choice = -1;
        Scanner input = new Scanner(System.in);
        String id = login();
        trueID = id;
        int position = positionClass(id);
        if (position == 1) {
            for (int i = 0; i < nStaff.length; i++) {
                if (id.equals(nStaff[i].getStaffID())) {
                    name = nStaff[i].getname();
                }
            }
            do {
                datatype = true;
                System.out.printf("\nWelcome, %s\n\n", name);
                System.out.print("Starduck Menu\n");
                System.out.print("===============================================\n");
                System.out.print("1.View Meal Menu\n");
                System.out.print("2.View Membership List and Discount Details\n");
                System.out.print("3.Start accept customer Order\n");
                System.out.print("4.Log Out\n");
                System.out.print("===============================================\n");
                do {
                    try {
                        System.out.print("Choice : ");
                        choice = input.nextInt();
                        input.nextLine();
                        datatype = false;
                    } catch (Exception e) {
                        System.out.print("Invalid input, an Integer is required!\n");
                        input.nextLine();
                    }
                } while (datatype);
                switch (choice) {
                    case 1:
                        displayMenu();
                        break;
                    case 2:
                        displayMembership();
                        break;
                    case 3:
                    	return 1;
                    case 4:
                    	return 2;
                    default:
                        System.out.print("Invalid input, the choice (1-3) is required!\n");
                        break;
                }
            } while (choice != 3 || choice != 4);
        } else {
            for (int i = 0; i < hStaff.length; i++) {
                if (id.equals(hStaff[i].getStaffID())) {
                    name = hStaff[i].getname();
                }
            }
            do {
                datatype = true;
                System.out.printf("\nWelcome, %s\n\n", name);
                System.out.print("Starduck Menu\n");
                System.out.print("=================================================\n");
                System.out.print("1.Edit Meal Menu\n");
                System.out.print("2.Edit Membership List and Discount Details\n");
                System.out.print("3.Edit Staff Detail\n");
                System.out.print("4.Start accept customer Order\n");
                System.out.print("5.Log Out\n");
                System.out.print("=================================================\n");
                do {
                    try {
                        System.out.print("Choice : ");
                        choice = input.nextInt();
                        input.nextLine();
                        datatype = false;
                    } catch (Exception e) {
                        System.out.print("Invalid input, an Integer is required!\n");
                        input.nextLine();
                    }
                } while (datatype);
                switch (choice) {
                    case 1:
                        Menuselection();
                        break;
                    case 2:
                        discountMenu();
                        break;
                    case 3:
                        staffMenu();
                        break;
                    case 4:
                    	return 1;
                    case 5:
                    	return 2;
                    default:
                        System.out.print("Invalid input, the choice (1-3) is required!\n");
                        break;
                }
            } while (choice != 4);
        }
        return 1;
    }

    //For ordering Product
    public static int addNewOrder() {
        OrderDetail[] newOrder = new OrderDetail[order.length + 1];
        if (order.length != 0) {
            System.arraycopy(order, 0, newOrder, 0, order.length);
            order = newOrder;
            order[order.length - 1] = new OrderDetail();
        } else {
            order = newOrder;
            order[order.length - 1] = new OrderDetail();
        }
        return order.length - 1;
    }
    public static void order() {
        boolean datatypeValid;
        int Orderno;
        String yesorno = "";
        Scanner input = new Scanner(System.in);
        do {
            Orderno = addNewOrder();
            getOrder(Orderno);
            System.out.print("\nAny other customer? (Yes or No) : ");
            yesorno = input.nextLine();
        } while (yesorno.toUpperCase().equals("YES"));
    }
    public static void getOrder(int index) {
        Scanner input = new Scanner(System.in);
        String isMember, isVoucher;
        System.out.print("\nOrder ID : " + order[index].getID() + "\n\n");
        do {
            System.out.print("Do you have Membership Card? (Yes or No) : ");
            isMember = input.nextLine();
            if (isMember.toUpperCase().equals("YES")) {
                isMembership(index);
            } else if (isMember.toUpperCase().equals("NO")) {
                newMembership(index);
                break;
            } else {
                System.out.print("Invalid input entered, Yes or No is defined!\n");
            }
        } while (!(isMember.toUpperCase().equals("YES") || isMember.toUpperCase().equals("NO")));
        productOrder(index);
        System.out.print("\nCash Voucher\n");
        System.out.print("===============================\n\n");
        do {
            System.out.print("Do you have Cash Voucher? (Yes or No) : ");
            isVoucher = input.nextLine();
            if (isVoucher.toUpperCase().equals("YES")) {
                voucherAccept(index);
            } else if (isVoucher.toUpperCase().equals("NO")) {
                break;
            } else {
                System.out.print("Invalid input entered, Yes or No is defined!\n");
            }
        } while (!(isVoucher.toUpperCase().equals("YES") || isVoucher.toUpperCase().equals("NO")));
        payment(index);
        if (order[index].getTotal() <= 0) {
            removeOrder(index);
        }
    }
    public static void newMembership(int index) {
        Scanner input = new Scanner(System.in);
        String yesorno;
        System.out.print("Do you want to buy member Card? (Yes/No): ");
        yesorno = input.nextLine();
        if (yesorno.toUpperCase().equals("YES")) {
            addMembership();
            order[index].setCardPrice(20);
        } else {
            order[index].setCardPrice(0);
        }
    }
    public static void isMembership(int index) {
        Scanner input = new Scanner(System.in);
        boolean repeat = true, validCard = false, dataTypeloop;
        String cardNo;
        String NoCard = "YES";
        System.out.print("\nMember Card\n");
        System.out.print("===============================\n\n");
        do {
            System.out.print("Enter Card Number : ");
            cardNo = input.nextLine();
            for (int i = 0; i < member.length; i++) {
                if (cardNo.equals(member[i].getCardNum())) {
                    order[index].membershipValid(member[i].getID(), member[i].getName(), member[i].getCardNum());
                    System.out.printf("Membership valid, %.0f%% discount allowed!\n",member[i].getDiscount());
                    validCard = true;
                    repeat = false;
                    NoCard = "NO";
                }
            }
            if (!(validCard)) {
                System.out.print("Invalid card number entered, maybe your card number is unknown.\n");
                do {
                    dataTypeloop = true;
                    try {
                        System.out.print("Do you want to repeat enter? (true/false) : ");
                        repeat = input.nextBoolean();
                        dataTypeloop = false;
                        input.nextLine();
                    } catch (Exception e) {
                        System.out.print("Incorrect input, a boolean is required!\n");
                        input.nextLine();
                    }
                } while (dataTypeloop);
            }
        } while (repeat);
        if (!(repeat) && NoCard.equals("YES")) {
            newMembership(index);
        }
    }
    public static void productOrder(int index) {
        Scanner input = new Scanner(System.in);
        String id, repeat;
        int quantity = 0, count = 0;
        int correctIndex = -1;
        boolean datatypeLoop = true;
        displayMenu();
        do {
            System.out.print("\nProduct Order No : " + (count + 1) + "\n========================================\n\n");
            System.out.print("Enter Meal ID (F = Food,D = Drink, I = Dessert) : ");
            id = input.nextLine();
            switch (id.charAt(0)) {
                case 'F':
                    correctIndex = -1;
                    for (int i = 0; i < food.length; i++) {
                        datatypeLoop = true;
                        if (id.equals(food[i].getID())) {
                            do {
                                try {
                                    System.out.print("Quantity : ");
                                    quantity = input.nextInt();
                                    datatypeLoop = false;
                                    input.nextLine();
                                } catch (Exception e) {
                                    System.out.print("Invalid datatype input , an integer is required!\n");
                                    input.nextLine();
                                }
                            } while (datatypeLoop);
                            if (quantity > 0) {
                                if (quantity <= food[i].getQuantity()) {
                                    order[index].productOrder(food[i].getID(), food[i].getDescription(), quantity);
                                    food[i].restock(-quantity);
                                } else {
                                    System.out.print("Sorry , the product you want to order is out of stock!\n");
                                    count--;
                                }
                            } else {
                                count--;
                            }
                            count++;
                            correctIndex = i;
                        }

                    }
                    if (correctIndex == -1) {
                        System.out.print("Sorry, Your ID entered is Unknown!\n");
                    }
                    break;
                case 'D':
                    correctIndex = -1;
                    for (int i = 0; i < drink.length; i++) {
                        datatypeLoop = true;
                        if (id.equals(drink[i].getID())) {
                            do {
                                try {
                                    System.out.print("Quantity : ");
                                    quantity = input.nextInt();
                                    datatypeLoop = false;
                                    input.nextLine();
                                } catch (Exception e) {
                                    System.out.print("Invalid datatype input , an integer is required!\n");
                                    input.nextLine();
                                }
                            } while (datatypeLoop);
                            if (quantity > 0) {
                                if (quantity <= drink[i].getQuantity()) {
                                    order[index].productOrder(drink[i].getID(), drink[i].getDescription(), quantity);
                                    drink[i].restock(-quantity);
                                } else {
                                    System.out.print("Sorry , the product you want to order is out of stock!\n");
                                    count--;
                                }

                            } else {
                                count--;
                            }
                            count++;
                            correctIndex = i;
                        }

                    }
                    if (correctIndex == -1) {
                        System.out.print("Sorry, Your ID entered is Unknown!\n");
                    }
                    break;
                case 'I':
                    correctIndex = -1;
                    for (int i = 0; i < dessert.length; i++) {
                        datatypeLoop = true;
                        if (id.equals(dessert[i].getID())) {
                            do {
                                try {
                                    System.out.print("Quantity : ");
                                    quantity = input.nextInt();
                                    datatypeLoop = false;
                                    input.nextLine();
                                } catch (Exception e) {
                                    System.out.print("Invalid datatype input , an integer is required!\n");
                                    input.nextLine();
                                }
                            } while (datatypeLoop);
                            if (quantity > 0) {
                                if (quantity <= dessert[i].getQuantity()) {
                                    order[index].productOrder(dessert[i].getID(), dessert[i].getDescription(), quantity);
                                    dessert[i].restock(-quantity);
                                }


                            } else {
                                count--;
                            }
                            count++;
                            correctIndex = i;
                        }
                    }
                    if (correctIndex == -1) {
                        System.out.print("Sorry, Your ID entered is Unknown!\n");
                    }
                    break;
                default:
                    System.out.print("Invalid meal ID entered, (F,D,I) is defined!\n");
                    break;
            }
            System.out.print("Any Other order? (Yes/No) : ");
            repeat = input.nextLine();
        } while (repeat.toUpperCase().equals("YES"));
    }
    public static void voucherAccept(int index) {
        Scanner input = new Scanner(System.in);
        String code, repeat;
        double cash = 0.0;
        boolean datatypeLoop = true;
        int count = 0;
        System.out.print("\nVoucher Accept\n");
        System.out.print("===================");
        do {
            System.out.print("\nEnter voucher Code : ");
            code = input.nextLine();
            do {
                datatypeLoop = true;
                try {
                    System.out.print("Enter voucher price : ");
                    cash = input.nextDouble();
                    datatypeLoop = false;
                    input.nextLine();
                } catch (Exception e) {
                    System.out.print("Invalid data type entered, a double is required!\n");
                    input.nextLine();
                }
            } while (datatypeLoop);
            if (cash > 0) {
                order[index].voucherAccept(code, cash);
                System.out.print("\nCash Voucher \"" + code + "\" accepted!\n");
                count++;
            }
            if (count < 2) {
                System.out.print("Any Other voucher? (Yes/No) : ");
                repeat = input.nextLine();
            } else {
                repeat = "NO";
            }

        } while (repeat.toUpperCase().equals("YES"));
    }
    public static void payment(int index) {
        Scanner input = new Scanner(System.in);
        double amountPaid = 0.0;
        double changeDue;
        boolean datatypeLoop = true, amountValid = false;
        order[index].calTotal(food, drink, dessert);
        System.out.print("\nPayment\n");
        System.out.print("========================================\n");
        System.out.print("\nTotal Amount                : RM " + String.format("%2.2f", order[index].getTotal()));
        System.out.print("\nSST Amount                  : RM " + String.format("%2.2f", order[index].getTotal() * order[index].getTax()));
        order[index].calSubTotal();
        System.out.print("\nSub Total Amount            : RM " + String.format("%2.2f", order[index].getSubTotal()));
        order[index].addAnnDiscount(date);
        System.out.print(String.format("\n%s(%2.0f%%)       : RM %2.2f", "Discount Allowed", order[index].getDiscount() * 100, order[index].calDiscount()));
        order[index].calVoucher();
        System.out.print("\nCash Voucher allowed        : RM " + String.format("%2.2f", order[index].getcashReduced()));
        System.out.print("\nGrand Total Amount          : RM " + String.format("%2.2f", order[index].calGrandTotal()));
        if (order[index].calGrandTotal() - Math.floor(order[index].calGrandTotal()) >= 0.5) {
            System.out.print("\nRounding Amount             : RM " + String.format("%2.2f", Math.ceil(order[index].calGrandTotal()) - order[index].calGrandTotal()) + "\n");
            System.out.print("Rounding Grand Total Amount : RM " + String.format("%2.2f", Math.ceil(order[index].calGrandTotal())) + "\n");
            order[index].setRounding(Math.ceil(order[index].calGrandTotal()) - order[index].calGrandTotal());
            order[index].setFinal(Math.ceil(order[index].calGrandTotal()));
        } else {
            System.out.print("\nRounding Amount             : RM -" + String.format("%2.2f", order[index].calGrandTotal() - Math.floor(order[index].calGrandTotal())) + "\n");
            System.out.print("Rounding Grand Total Amount : RM " + String.format("%2.2f", Math.floor(order[index].calGrandTotal())) + "\n");
            order[index].setRounding((order[index].calGrandTotal() - Math.floor(order[index].calGrandTotal())) * -1);
            order[index].setFinal(Math.floor(order[index].calGrandTotal()));
        }
        do {
            do {
                datatypeLoop = true;
                try {
                    System.out.print("Enter Amount Paid           : RM ");
                    amountPaid = input.nextDouble();
                    datatypeLoop = false;
                    input.nextLine();
                } catch (Exception e) {
                    System.out.print("Invalid data type entered, A double is required\n");
                    input.nextLine();
                }
            } while (datatypeLoop);
            if (amountPaid < order[index].getFinal()) {
                System.out.print("Sorry, your amount paid is lower than Amount to pay!\n");
            }
        } while (amountPaid < order[index].getFinal());
        order[index].displayReceipt(food, drink, dessert, amountPaid,trueID);
    }
    public static void removeOrder(int index) {
        int j = index, k = index;
        order[0].removeOrder();
        String[] id = new String[order.length - j - 1];
        for (int i = 0; i < id.length; i++) {
            id[i] = order[j].getID();
            j++;
        }
        OrderDetail[] deleteOrder = new OrderDetail[order.length - k - 1];

        System.arraycopy(order, k + 1, deleteOrder, 0, order.length - k - 1);
        System.arraycopy(deleteOrder, 0, order, k, deleteOrder.length);
        for (int i = 0; i < id.length; i++) {
            order[k].setID(id[i]);
            k++;
        }
        OrderDetail[] neworder = new OrderDetail[order.length - 1];
        System.arraycopy(order, 0, neworder, 0, order.length - 1);
        order = neworder;
    }

    //For Sales Report
    public static void displayReport() {
        Date Cdate = new Date();
        System.out.print("\n\n-Starduck Cafe-\n");
        System.out.print("Sales Report\n");
        System.out.print("==============================================\n");
        System.out.print("Date : " + Cdate.toGMTString() + "\n");
        calculateQuantity();
        displayCustomer();
        calculateOther();
        report.tableDisplay();
        displayGoodBye();
    }
    public static void calculateQuantity() {
        for (int i = 0; i < order.length; i++) {
            for (int j = 0; j < order[i].getproductLength(); j++) {
                if (order[i].getproduct(j) instanceof Food) {
                    for (int k = 0; k < food.length; k++) {
                        if (order[i].getproduct(j).getID().equals(food[k].getID())) {
                            report.addMealQuantity(k, 1, order[i].getproduct(j).getQuantity());
                        }
                    }
                } else if (order[i].getproduct(j) instanceof Drink) {
                    for (int k = 0; k < drink.length; k++) {
                        if (order[i].getproduct(j).getID().equals(drink[k].getID())) {
                            report.addMealQuantity(k, 2, order[i].getproduct(j).getQuantity());
                        }
                    }
                } else if (order[i].getproduct(j) instanceof Dessert) {
                    for (int k = 0; k < dessert.length; k++) {
                        if (order[i].getproduct(j).getID().equals(dessert[k].getID())) {
                            report.addMealQuantity(k, 3, order[i].getproduct(j).getQuantity());
                        }
                    }
                }
            }
        }
    }
    public static void calculateOther() {
        for (OrderDetail value: order) {
            report.adddiscount(value.calDiscount());
            report.addcashReduce(value.getcashReduced());
            report.addRounding(value.getRounding());
            if (value.getCardPrice() != 0) {
                report.addMemberCard(value.getCardPrice());
            }
        }
    }
    public static void displayCustomer() {
        System.out.print("Customer Sales Report\n");
        System.out.print("====================================================================\n");
        for (int i = 0; i < order.length; i++) {
            order[i].tableDisplay(food, drink, dessert,trueID);
        }
    }
    public static void displayGoodBye() {
        System.out.print("=================================================================================================\n");
        System.out.print("=================================================================================================\n");
        System.out.printf("%55s\n", "Please Come Again!!!\n");
    }

    //For Product Module
    public static void addFood(String description, int quantity, double unitPrice) {
        Food[] newfood = new Food[food.length + 1];
        System.arraycopy(food, 0, newfood, 0, food.length);
        food = newfood;
        food[food.length - 1] = new Food(description, quantity, unitPrice);
        System.out.print("\nNew Food \"" + food[food.length - 1].getID() + "\" added!\n");
        System.out.print(food[food.length - 1].toString());
    }
    public static void addDrink(String description, int quantity, double unitPrice) {
        Drink[] newdrink = new Drink[drink.length + 1];
        System.arraycopy(drink, 0, newdrink, 0, drink.length);
        drink = newdrink;
        drink[drink.length - 1] = new Drink(description, quantity, unitPrice);
        System.out.print("\nNew Drink \"" + drink[drink.length - 1].getID() + "\" added!\n");
        System.out.print(drink[drink.length - 1].toString());
    }
    public static void addDessert(String description, int quantity, double unitPrice) {
        Dessert[] newdessert = new Dessert[dessert.length + 1];
        System.arraycopy(dessert, 0, newdessert, 0, dessert.length);
        dessert = newdessert;
        dessert[dessert.length - 1] = new Dessert(description, quantity, unitPrice);
        System.out.print("\nNew Dessert \"" + dessert[dessert.length - 1].getID() + "\" added!\n");
        System.out.print(dessert[dessert.length - 1].toString());
    }
    public static void displayMeal(String mealIDSearch) {
        int searchID = -1, itemType = -1;
        if (mealIDSearch.charAt(0) == 'F') {
            for (int i = 0; i < food.length; i++) {
                if (mealIDSearch.equals(food[i].getID())) {
                    itemType = 1;
                    searchID = i;
                } else {
                    itemType = 1;
                }
            }
        } else if (mealIDSearch.charAt(0) == 'D') {
            for (int i = 0; i < drink.length; i++) {
                if (mealIDSearch.equals(drink[i].getID())) {
                    itemType = 2;
                    searchID = i;
                } else {
                    itemType = 2;
                }
            }
        } else if (mealIDSearch.charAt(0) == 'I') {
            for (int i = 0; i < dessert.length; i++) {
                if (mealIDSearch.equals(dessert[i].getID())) {
                    itemType = 3;
                    searchID = i;
                } else {
                    itemType = 3;
                }
            }
        }

        if (itemType != -1) {
            if (itemType == 1) {
                if (searchID != -1) {
                    System.out.print(food[searchID].toString());
                } else {
                    System.out.print("\nSorry, the meal entered is unknown\n\n");
                }
            } else if (itemType == 2) {
                if (searchID != -1) {
                    System.out.print(drink[searchID].toString());
                } else {
                    System.out.print("\nSorry, the meal entered is unknown\n\n");
                }
            } else if (itemType == 3) {
                if (searchID != -1) {
                    System.out.print(dessert[searchID].toString());
                } else {
                    System.out.print("\nSorry, the meal entered is unknown\n\n");
                }
            }
        } else {
            System.out.print("\nSorry, your mealID typing is incorrect,it only have F0XX,D0XX,I0XX\n");
        }
    }
    public static void modifyMeal() {
        Scanner input = new Scanner(System.in);
        int mealType = -1;
        boolean dataTypeLoop = true, repeat = false;
        System.out.print("\n");
        do {
            repeat = false;
            do {
                try {
                    System.out.print("What type you want to modify? (Follow the numeric in front of select.)" + "\n 1. Food" + "\n 2. Drink" + "\n 3. Dessert\n");
                    System.out.print("Enter Type : ");
                    mealType = input.nextInt();
                    dataTypeLoop = false;
                } catch (Exception e) {
                    System.out.print("Incorrect input, an integer is required!\n");
                    input.nextLine();
                }
            } while (dataTypeLoop);

            switch (mealType) {
                case 1:
                    repeat = modifyFood();
                    break;
                case 2:
                    repeat = modifyDrink();
                    break;
                case 3:
                    repeat = modifyDessert();
                    break;
                default:
                    System.out.print("\nSorry, your mealID typing is incorrect,it only 1 and 2 required\n");
                    repeat = true;
            }
        } while (repeat);

    }
    public static boolean modifyFood() {
        Scanner input = new Scanner(System.in);
        boolean foodRepeat = false, repeat = false, modifyloop = true, dataTypeloop = true;
        String mealIDSearch, description;
        double unitPrice = 0;
        int correctID = -1, modify = 0;
        do {
            correctID = -1;
            System.out.print("Enter meal ID : ");
            mealIDSearch = input.nextLine();
            for (int i = 0; i < food.length; i++)
                if (mealIDSearch.equals(food[i].getID())) {
                    correctID = i;
                }
            if (correctID != -1) {
                do {
                    do {
                        try {
                            System.out.print(food[correctID].toString());
                            System.out.print("Which one you want modify?\n");
                            System.out.print("1. Description\n");
                            System.out.print("2. UnitPrice\n");
                            System.out.print("3. Exit Modify\n");
                            System.out.print("Enter here : ");
                            modify = input.nextInt();
                            dataTypeloop = false;
                        } catch (Exception e) {
                            System.out.print("Incorrect input, an integer is required!\n");
                            input.nextLine();
                        }
                    } while (dataTypeloop);
                    switch (modify) {
                        case 1:
                            input.nextLine();
                            System.out.print("\nType the new description: ");
                            description = input.nextLine();
                            System.out.printf("\nOld : %s\n", food[correctID].getDescription());
                            System.out.printf("New : %s\n", description);
                            food[correctID].setDescription(description);
                            break;
                        case 2:
                            do {
                                try {
                                    System.out.print("\nType new unit Price : ");
                                    unitPrice = input.nextDouble();
                                    modifyloop = false;
                                } catch (Exception e) {
                                    System.out.print("Incorrect input, a double is required!\n");
                                    input.nextLine();
                                }
                            } while (modifyloop);
                            System.out.printf("\nOld : RM%.2f\n", food[correctID].getUnitPrice());
                            System.out.printf("New : RM%.2f\n", unitPrice);
                            food[correctID].setUnitPrice(unitPrice);
                            break;
                        case 3:
                            break;
                        default:
                            System.out.print("Error Input, the choice (1-3) are required!\n");
                            break;
                    }
                } while (modify != 3);
            } else {
                System.out.print("\nSorry, the meal you want to search is unknown\n");
            }
            do {
                dataTypeloop = true;
                try {
                    System.out.print("Any other meal need to modify? (true/false) : ");
                    foodRepeat = input.nextBoolean();
                    dataTypeloop = false;
                } catch (Exception e) {
                    System.out.print("Incorrect input, a boolean is required!\n");
                    input.nextLine();
                }
            } while (dataTypeloop);
            input.nextLine();
        } while (foodRepeat);
        do {
            dataTypeloop = true;
            try {
                System.out.print("Any other meal type need to modify? (true/false) : ");
                repeat = input.nextBoolean();
                dataTypeloop = false;
            } catch (Exception e) {
                System.out.print("Incorrect input, a boolean is required!\n");
                input.nextLine();
            }
        } while (dataTypeloop);
        System.out.print("\n\n");
        return repeat;
    }
    public static boolean modifyDrink() {
        Scanner input = new Scanner(System.in);
        boolean drinkRepeat = false, repeat = false, modifyloop = true, dataTypeloop = true;
        String mealIDSearch, description;
        double unitPrice = 0;
        int correctID = -1, modify = 0;
        do {
            correctID = -1;
            System.out.print("Enter meal ID : ");
            mealIDSearch = input.nextLine();
            for (int i = 0; i < drink.length; i++)
                if (mealIDSearch.equals(drink[i].getID())) {
                    correctID = i;
                }
            if (correctID != -1) {
                do {
                    do {
                        try {
                            System.out.print(drink[correctID].toString());
                            System.out.print("Which one you want modify?\n");
                            System.out.print("1. Description\n");
                            System.out.print("2. UnitPrice\n");
                            System.out.print("3. Exit Modify\n");
                            System.out.print("Enter here : ");
                            modify = input.nextInt();
                            dataTypeloop = false;
                        } catch (Exception e) {
                            System.out.print("Incorrect input, an integer is required!\n");
                            input.nextLine();
                        }
                    } while (dataTypeloop);
                    switch (modify) {
                        case 1:
                            input.nextLine();
                            System.out.print("\nType the new description: ");
                            description = input.nextLine();
                            System.out.printf("\nOld : %s\n", drink[correctID].getDescription());
                            System.out.printf("New : %s\n", description);
                            drink[correctID].setDescription(description);
                            break;
                        case 2:
                            do {
                                try {
                                    System.out.print("\nType new unit Price : ");
                                    unitPrice = input.nextDouble();
                                    modifyloop = false;
                                } catch (Exception e) {
                                    System.out.print("Incorrect input, a double is required!\n");
                                    input.nextLine();
                                }
                            } while (modifyloop);
                            System.out.printf("\nOld : RM%.2f\n", drink[correctID].getUnitPrice());
                            System.out.printf("New : RM%.2f\n", unitPrice);
                            drink[correctID].setUnitPrice(unitPrice);
                            break;
                        case 3:
                            break;
                        default:
                            System.out.print("Error Input, the choice (1-3) are required!\n");
                            break;
                    }
                } while (modify != 3);
            } else {
                System.out.print("\nSorry, the meal you want to search is unknown\n");
            }
            do {
                dataTypeloop = true;
                try {
                    System.out.print("Any other meal need to modify? (true/false) : ");
                    drinkRepeat = input.nextBoolean();
                    dataTypeloop = false;
                } catch (Exception e) {
                    System.out.print("Incorrect input, a boolean is required!\n");
                    input.nextLine();
                }
            } while (dataTypeloop);
            input.nextLine();
        } while (drinkRepeat);
        do {
            dataTypeloop = true;
            try {
                System.out.print("Any other meal type need to modify? (true/false) : ");
                repeat = input.nextBoolean();
                dataTypeloop = false;
            } catch (Exception e) {
                System.out.print("Incorrect input, a boolean is required!\n");
                input.nextLine();
            }
        } while (dataTypeloop);
        System.out.print("\n\n");
        return repeat;
    }
    public static boolean modifyDessert() {
        Scanner input = new Scanner(System.in);
        boolean drinkRepeat = false, repeat = false, modifyloop = true, dataTypeloop = true;
        String mealIDSearch, description;
        double unitPrice = 0;
        int correctID = -1, modify = 0;
        do {
            correctID = -1;
            System.out.print("Enter meal ID : ");
            mealIDSearch = input.nextLine();
            for (int i = 0; i < dessert.length; i++)
                if (mealIDSearch.equals(dessert[i].getID())) {
                    correctID = i;
                }
            if (correctID != -1) {
                do {
                    do {
                        try {
                            System.out.print(dessert[correctID].toString());
                            System.out.print("Which one you want modify?\n");
                            System.out.print("1. Description\n");
                            System.out.print("2. UnitPrice\n");
                            System.out.print("3. Exit Modify\n");
                            System.out.print("Enter here : ");
                            modify = input.nextInt();
                            dataTypeloop = false;
                        } catch (Exception e) {
                            System.out.print("Incorrect input, an integer is required!\n");
                            input.nextLine();
                        }
                    } while (dataTypeloop);
                    switch (modify) {
                        case 1:
                            input.nextLine();
                            System.out.print("\nType the new description: ");
                            description = input.nextLine();
                            System.out.printf("\nOld : %s\n", dessert[correctID].getDescription());
                            System.out.printf("New : %s\n", description);
                            dessert[correctID].setDescription(description);
                            break;
                        case 2:
                            do {
                                try {
                                    System.out.print("\nType new unit Price : ");
                                    unitPrice = input.nextDouble();
                                    modifyloop = false;
                                } catch (Exception e) {
                                    System.out.print("Incorrect input, a double is required!\n");
                                    input.nextLine();
                                }
                            } while (modifyloop);
                            System.out.printf("\nOld : RM%.2f\n", dessert[correctID].getUnitPrice());
                            System.out.printf("New : RM%.2f\n", unitPrice);
                            dessert[correctID].setUnitPrice(unitPrice);
                            break;
                        case 3:
                            break;
                        default:
                            System.out.print("Error Input, the choice (1-3) are required!\n");
                            break;
                    }
                } while (modify != 3);
            } else {
                System.out.print("\nSorry, the meal you want to search is unknown\n");
            }
            do {
                dataTypeloop = true;
                try {
                    System.out.print("Any other meal need to modify? (true/false) : ");
                    drinkRepeat = input.nextBoolean();
                    dataTypeloop = false;
                } catch (Exception e) {
                    System.out.print("Incorrect input, a boolean is required!\n");
                    input.nextLine();
                }
            } while (dataTypeloop);
            input.nextLine();
        } while (drinkRepeat);
        do {
            dataTypeloop = true;
            try {
                System.out.print("Any other meal type need to modify? (true/false) : ");
                repeat = input.nextBoolean();
                dataTypeloop = false;
            } catch (Exception e) {
                System.out.print("Incorrect input, a boolean is required!\n");
                input.nextLine();
            }
        } while (dataTypeloop);
        System.out.print("\n\n");
        return repeat;
    }
    public static void restock(String mealIDSearch) {
        Scanner input = new Scanner(System.in);
        int searchID = -1, itemType = -1, quantity = 0;
        boolean dataTypeloop = true;
        if (mealIDSearch.charAt(0) == 'F') {
            for (int i = 0; i < food.length; i++) {
                if (mealIDSearch.equals(food[i].getID())) {
                    itemType = 1;
                    searchID = i;
                } else {
                    itemType = 1;
                }
            }
        } else if (mealIDSearch.charAt(0) == 'D') {
            for (int i = 0; i < drink.length; i++) {
                if (mealIDSearch.equals(drink[i].getID())) {
                    itemType = 2;
                    searchID = i;
                } else {
                    itemType = 2;
                }
            }
        } else if (mealIDSearch.charAt(0) == 'I') {
            for (int i = 0; i < dessert.length; i++) {
                if (mealIDSearch.equals(dessert[i].getID())) {
                    itemType = 3;
                    searchID = i;
                } else {
                    itemType = 3;
                }
            }
        }

        if (itemType != -1) {
            if (itemType == 1) {
                if (searchID != -1) {
                    do {
                        try {
                            System.out.print(food[searchID].toString());
                            System.out.print("Enter quantity here you want to restock (+ve) or return (-ve): ");
                            quantity = input.nextInt();
                            dataTypeloop = false;
                        } catch (Exception e) {
                            System.out.print("Incorrect input, an integer is required!\n");
                            input.nextLine();
                        }
                    } while (dataTypeloop);
                    System.out.print("\nFood ID :" + food[searchID].getID() + "\n\n");
                    System.out.print("Food Description :" + food[searchID].getDescription() + "\n");
                    System.out.print("Food Quantity    :" + food[searchID].getQuantity() + "-->" + (food[searchID].getQuantity() + quantity) + "\n");
                    System.out.printf("Food Unit Price  :RM%.2f\n\n", food[searchID].getUnitPrice());
                    food[searchID].restock(quantity);
                } else {
                    System.out.print("\nSorry, the meal you want to search is unknown\n");
                }
            } else if (itemType == 2) {
                do {
                    try {
                        System.out.print(drink[searchID].toString());
                        System.out.print("Enter quantity here you want to restock (+ve) or return (-ve): ");
                        quantity = input.nextInt();
                        dataTypeloop = false;
                    } catch (Exception e) {
                        System.out.print("Incorrect input, an integer is required!\n");
                        input.nextLine();
                    }
                } while (dataTypeloop);
                System.out.print("\nDrink ID :" + drink[searchID].getID() + "\n\n");
                System.out.print("Drink Description :" + drink[searchID].getDescription() + "\n");
                System.out.print("Drink Quantity    :" + drink[searchID].getQuantity() + "-->" + (drink[searchID].getQuantity() + quantity) + "\n");
                System.out.printf("Drink Unit Price  :RM%.2f\n\n", drink[searchID].getUnitPrice());
                drink[searchID].restock(quantity);
            } else if (itemType == 3) {
                do {
                    try {
                        System.out.print(dessert[searchID].toString());
                        System.out.print("Enter quantity here you want to restock (+ve) or return (-ve): ");
                        quantity = input.nextInt();
                        dataTypeloop = false;
                    } catch (Exception e) {
                        System.out.print("Incorrect input, an integer is required!\n");
                        input.nextLine();
                    }
                } while (dataTypeloop);
                System.out.print("\nDessert ID :" + dessert[searchID].getID() + "\n\n");
                System.out.print("Dessert Description :" + dessert[searchID].getDescription() + "\n");
                System.out.print("Dessert Quantity    :" + dessert[searchID].getQuantity() + "-->" + (dessert[searchID].getQuantity() + quantity) + "\n");
                System.out.printf("Dessert Unit Price  :RM%.2f\n\n", dessert[searchID].getUnitPrice());
                dessert[searchID].restock(quantity);
            } else {
                System.out.print("\nSorry, the meal you want to search is unknown\n");
            }

        } else {
            System.out.print("\nSorry, your mealID typing is incorrect,it only have F0XX or D0XX\n");
        }
    }
    public static void delete(String mealIDSearch) {
        int j = 0, k = 0;
        int itemType = -1, searchID = -1;
        if (mealIDSearch.charAt(0) == 'F') {
            for (int i = 0; i < food.length; i++) {
                if (mealIDSearch.equals(food[i].getID())) {
                    itemType = 1;
                    searchID = i;
                    j = i;
                    k = i;
                } else {
                    itemType = 1;
                }
            }
        } else if (mealIDSearch.charAt(0) == 'D') {
            for (int i = 0; i < drink.length; i++) {
                if (mealIDSearch.equals(drink[i].getID())) {
                    itemType = 2;
                    searchID = i;
                    j = i;
                    k = i;
                } else {
                    itemType = 2;
                }
            }
        } else if (mealIDSearch.charAt(0) == 'I') {
            for (int i = 0; i < dessert.length; i++) {
                if (mealIDSearch.equals(dessert[i].getID())) {
                    itemType = 3;
                    searchID = i;
                    j = i;
                    k = i;
                } else {
                    itemType = 3;
                }
            }
        }
        if (itemType != -1) {
            if (itemType == 1) {
                if (searchID != -1) {
                    System.out.print("The food " + food[searchID].getDescription() + " is removed!\n");
                    String[] id = new String[food.length - j - 1];
                    for (int i = 0; i < id.length; i++) {
                        id[i] = food[j].getID();
                        j++;
                    }
                    Food[] deleteFood = new Food[food.length - k - 1];

                    System.arraycopy(food, k + 1, deleteFood, 0, food.length - k - 1);
                    System.arraycopy(deleteFood, 0, food, k, deleteFood.length);
                    for (int i = 0; i < id.length; i++) {
                        food[k].setID(id[i]);
                        k++;
                    }
                    Food[] newfood = new Food[food.length - 1];
                    System.arraycopy(food, 0, newfood, 0, food.length - 1);
                    food = newfood;
                    Food.removeMeal();
                    Food.removeProduct();
                } else {
                    System.out.print("\nSorry, the meal you want to search is unknown\n");
                }
            } else if (itemType == 2) {
                if (searchID != -1) {
                    System.out.print("The drink " + drink[searchID].getDescription() + " is removed!\n");
                    String[] id = new String[drink.length - j - 1];
                    for (int i = 0; i < id.length; i++) {
                        id[i] = drink[j].getID();
                        j++;
                    }
                    Drink[] deleteDrink = new Drink[drink.length - k - 1];
                    System.arraycopy(drink, k + 1, deleteDrink, 0, drink.length - k - 1);
                    System.arraycopy(deleteDrink, 0, drink, k, deleteDrink.length);
                    for (int i = 0; i < id.length; i++) {
                        drink[k].setID(id[i]);
                        k++;
                    }
                    Drink[] newdrink = new Drink[drink.length - 1];
                    System.arraycopy(drink, 0, newdrink, 0, drink.length - 1);
                    drink = newdrink;
                    Drink.removeMeal();
                    Drink.removeProduct();
                } else {
                    System.out.print("\nSorry, the meal you want to search is unknown\n");
                }
            }
        } else if (itemType == 3) {
            if (searchID != -1) {
                System.out.print("The dessert " + dessert[searchID].getDescription() + " is removed!\n");
                String[] id = new String[dessert.length - j - 1];
                for (int i = 0; i < id.length; i++) {
                    id[i] = dessert[j].getID();
                    j++;
                }
                Dessert[] deleteDessert = new Dessert[dessert.length - k - 1];
                System.arraycopy(dessert, k + 1, deleteDessert, 0, dessert.length - k - 1);
                System.arraycopy(deleteDessert, 0, dessert, k, deleteDessert.length);
                for (int i = 0; i < id.length; i++) {
                    dessert[k].setID(id[i]);
                    k++;
                }
                Dessert[] newdessert = new Dessert[dessert.length - 1];
                System.arraycopy(dessert, 0, newdessert, 0, dessert.length - 1);
                dessert = newdessert;
                Dessert.removeMeal();
                Dessert.removeProduct();
            } else {
                System.out.print("\nSorry, the meal you want to search is unknown\n");
            }
        } else {
            System.out.print("\nSorry, your mealID typing is incorrect,it only have F0XX,D0XX,I0XX\n");
        }
    }
    public static void displayMenu() {
        for (int i = 0; i < 3; i++) {
            if ((i + 1) == 1) {
                System.out.printf("\n %30s %s\n", "", "Food Menu");
                System.out.print(String.format("%-10s %-40s %-11s %-13s", "FoodID", "Description", "Quantity", "UnitPrice") + "\n");
                System.out.print(String.format("%-10s %-40s %-11s %-13s", "==========", "========================================", "==========", "===========") + "\n");
                for (int j = 0; j < getFoodlength(); j++) {
                    System.out.print(food[j].tableDisplay() + "\n");
                }
                System.out.print("\n" + "No. of Food Displayed : " + getFoodlength() + "\n");
            } else if ((i + 1) == 2) {
                System.out.printf("\n %30s %s\n", "", "Drink Menu");
                System.out.print(String.format("%-10s %-40s %-11s %-13s", "DrinkID", "Description", "Quantity", "UnitPrice") + "\n");
                System.out.print(String.format("%-10s %-40s %-11s %-13s", "==========", "========================================", "==========", "===========") + "\n");
                for (int j = 0; j < getDrinklength(); j++) {
                    System.out.print(drink[j].tableDisplay() + "\n");
                }
                System.out.print("\n" + "No. of Drink Displayed : " + getDrinklength() + "\n");
            } else if ((i + 1) == 3) {
                System.out.printf("\n %30s %s\n", "", "Dessert Menu");
                System.out.print(String.format("%-10s %-40s %-11s %-13s", "DessertID", "Description", "Quantity", "UnitPrice") + "\n");
                System.out.print(String.format("%-10s %-40s %-11s %-13s", "==========", "========================================", "==========", "===========") + "\n");
                for (int j = 0; j < getDessertlength(); j++) {
                    System.out.print(dessert[j].tableDisplay() + "\n");
                }
                System.out.print("\n" + "No. of Drink Displayed : " + getDessertlength() + "\n");
                System.out.print("\n");
                System.out.print("No. of Meal Displayed : " + Product.getnoOfProduct() + "\n\n");
            }
        }
    }
    public static int getFoodlength() {
        return food.length;
    }
    public static int getDrinklength() {
        return drink.length;
    }
    public static int getDessertlength() {
        return dessert.length;
    }
    public static void Menuselection() {
        Scanner input = new Scanner(System.in);
        int choice = -1;
        boolean valid = false;
        do {
            valid = true;
            System.out.print("\nMeal Menu\n");
            System.out.print("=======================\n");
            System.out.print("1. Display Menu\n");
            System.out.print("2. Search Meal\n");
            System.out.print("3. Modify Meal\n");
            System.out.print("4. Add New Meal\n");
            System.out.print("5. Remove Meal\n");
            System.out.print("6. Restock Meal\n");
            System.out.print("7. Save and Exit Menu\n");
            do {
                try {
                    System.out.print("\nYour Choice : ");
                    choice = input.nextInt();
                    input.nextLine();
                    valid = false;
                } catch (Exception e) {
                    System.out.print("Invalid input, an integer is required!\n");
                    input.nextLine();
                }
            } while (valid);
            switch (choice) {
                case 1:
                    displayMenu();
                    break;
                case 2:
                    searchMeal();
                    break;
                case 3:
                    modifyMeal();
                    break;
                case 4:
                    addMenu();
                    break;
                case 5:
                    removeMeal();
                    break;
                case 6:
                    restockMeal();
                    break;
                case 7:
                    break;
                default:
                    System.out.print("Invalid input , the choice (1-7) are required!\n");
                    break;
            }
        } while (choice != 7);
        return;
    }
    public static void searchMeal() {
        Scanner input = new Scanner(System.in);
        String id;
        System.out.print("\nEnter meal ID (F0XX, D0XX, I0XX) : ");
        id = input.nextLine();
        displayMeal(id);
    }
    public static void addMenu() {
        Scanner input = new Scanner(System.in);
        boolean valid = true;
        char type;
        String description = " ";
        int quantity = 0;
        double unitPrice = 0.0;
        do {
            description = " ";
            quantity = 0;
            unitPrice = 0.0;
            System.out.print("Enter meal Type (F for Food, D for Drink, I for Dessert , X for Exit) : ");
            type = input.nextLine().charAt(0);
            if (type == 'F') {
                System.out.print("\n\nAdd Food\n");
                System.out.print("============");
                System.out.print("\nDescription : ");
                description = input.nextLine();
                do {
                    valid = true;
                    try {
                        System.out.print("Quantity : ");
                        quantity = input.nextInt();
                        valid = false;
                    } catch (Exception ex) {
                        System.out.print("Invalid Input, An Integer is required!\n");
                        input.nextLine();
                    }
                } while (valid);
                do {
                    valid = true;
                    try {
                        System.out.print("Unit Price : RM ");
                        unitPrice = input.nextDouble();
                        valid = false;
                    } catch (Exception ex) {
                        System.out.print("Invalid Input, A double is required!\n");
                        input.nextLine();
                    }
                } while (valid);
                addFood(description, quantity, unitPrice);
                input.nextLine();
            } else if (type == 'D') {
                System.out.print("\n\nAdd Drink\n");
                System.out.print("============");
                System.out.print("\nDescription : ");
                description = input.nextLine();
                do {
                    valid = true;
                    try {
                        System.out.print("Quantity : ");
                        quantity = input.nextInt();
                        valid = false;
                    } catch (Exception ex) {
                        System.out.print("Invalid Input, An Integer is required!\n");
                        input.nextLine();
                    }
                } while (valid);
                do {
                    valid = true;
                    try {
                        System.out.print("Unit Price : RM ");
                        unitPrice = input.nextDouble();
                        valid = false;
                    } catch (Exception ex) {
                        System.out.print("Invalid Input, A double is required!\n");
                        input.nextLine();
                    }
                } while (valid);
                addDrink(description, quantity, unitPrice);
                input.nextLine();
            } else if (type == 'I') {
                System.out.print("\n\nAdd Dessert\n");
                System.out.print("===================");
                System.out.print("\nDescription : ");
                description = input.nextLine();
                do {
                    valid = true;
                    try {
                        System.out.print("Quantity : ");
                        quantity = input.nextInt();
                        valid = false;
                    } catch (Exception ex) {
                        System.out.print("Invalid Input, An Integer is required!\n");
                        input.nextLine();
                    }
                } while (valid);
                do {
                    valid = true;
                    try {
                        System.out.print("Unit Price : RM ");
                        unitPrice = input.nextDouble();
                        valid = false;
                    } catch (Exception ex) {
                        System.out.print("Invalid Input, A double is required!\n");
                        input.nextLine();
                    }
                } while (valid);
                addDessert(description, quantity, unitPrice);
                input.nextLine();
            } else if (type == 'X') {
                return;
            } else {
                System.out.print("Invalid Input, only F,D,X are required!\n");
            }

        } while (type != 'X');
    }
    public static void removeMeal() {
        Scanner input = new Scanner(System.in);
        String id;
        System.out.print("Enter meal ID (F0XX, D0XX, I0XX) : ");
        id = input.nextLine();
        delete(id);
    }
    public static void restockMeal() {
        Scanner input = new Scanner(System.in);
        String id;
        System.out.print("\nEnter meal ID (F0XX, D0XX, I0XX) : ");
        id = input.nextLine();
        restock(id);
    }

    //For Membership and Aniversary
    public static void discountMenu() {
        Scanner input = new Scanner(System.in);
        int choice = -1;
        boolean valid = false;
        do {
            valid = true;
            System.out.print("\nDiscount Menu\n");
            System.out.print("==============================\n");
            System.out.print("1. Display Membership list\n");
            System.out.print("2. Search Membership member\n");
            System.out.print("3. Modify Membership member\n");
            System.out.print("4. Add new Member\n");
            System.out.print("5. Remove existing Member\n");
            System.out.print("6. Modify Discount\n");
            System.out.print("7. Display Anniversary Detail\n");
            System.out.print("8. Save and Exit Menu\n");
            do {
                try {
                    System.out.print("\nYour Choice : ");
                    choice = input.nextInt();
                    input.nextLine();
                    valid = false;
                } catch (Exception e) {
                    System.out.print("Invalid input, an integer is required!\n");
                    input.nextLine();
                }
            } while (valid);
            switch (choice) {
                case 1:
                    displayMembership();
                    break;
                case 2:
                    searchMembership();
                    break;
                case 3:
                    modifyMembership();
                    break;
                case 4:
                    addMembership();
                    break;
                case 5:
                    removeMembership();
                    break;
                case 6:
                    modifyDiscount();
                    break;
                case 7:
                    System.out.print(date.toString());
                    break;
                case 8:
                    break;
                default:
                    System.out.print("Invalid input , the choice (1-8) are required!\n");
                    break;
            }
        } while (choice != 8);
        return;
    }
    public static void addMembership() {
        Scanner input = new Scanner(System.in);
        System.out.print("\n\nNew member\n");
        System.out.print("============\n");
        System.out.print("Enter new Member name : ");
        String name = input.nextLine();
        System.out.print("Enter card Number     : ");
        String cardNum = input.nextLine();
        Membership[] newmember = new Membership[member.length + 1];
        System.arraycopy(member, 0, newmember, 0, member.length);
        member = newmember;
        member[member.length - 1] = new Membership(name, cardNum);
        System.out.print("\nNew Member \"" + member[member.length - 1].getID() + "\" added!\n");
        System.out.print(member[member.length - 1].toString());
    }
    public static void searchMembership() {
        Scanner input = new Scanner(System.in);
        String id;
        int correctIndex = -1;
        System.out.print("\nEnter membership ID (M0XX) : ");
        id = input.nextLine();
        for (int i = 0; i < member.length; i++) {
            if (id.equals(member[i].getID())) {
                System.out.print(member[i].toString());
                correctIndex = i;
            }
        }
        if (correctIndex == -1) {
            System.out.print("Sorry, the membership entered is unknown.\n");
        }
    }
    public static void modifyMembership() {
        Scanner input = new Scanner(System.in);
        String id, name, cardnum;
        int correctIndex = -1, choice = -1;
        boolean dataTypeloop = true;
        System.out.print("\nEnter membership ID (M0XX) : ");
        id = input.nextLine();
        for (int i = 0; i < member.length; i++) {
            if (id.equals(member[i].getID())) {
                correctIndex = i;
            }
        }
        if (correctIndex == -1) {
            System.out.print("Sorry, your membership you want to find is unknown.\n");
            return;
        } else {
            do {
                System.out.print(member[correctIndex].toString());
                dataTypeloop = true;
                do {
                    try {
                        System.out.print("Which one you want modify?\n");
                        System.out.print("1. Name\n");
                        System.out.print("2. Card number\n");
                        System.out.print("3. Exit Modify\n");
                        System.out.print("Enter here : ");
                        choice = input.nextInt();
                        dataTypeloop = false;
                    } catch (Exception e) {
                        System.out.print("Incorrect input, an integer is required!\n");
                        input.nextLine();
                    }
                } while (dataTypeloop);
                switch (choice) {
                    case 1:
                        input.nextLine();
                        System.out.print("\nType the new member name: ");
                        name = input.nextLine();
                        System.out.printf("\nOld : %s\n", member[correctIndex].getName());
                        System.out.printf("New : %s\n", name);
                        member[correctIndex].setName(name);
                        break;
                    case 2:
                        input.nextLine();
                        System.out.print("\nType the new card Number: ");
                        cardnum = input.nextLine();
                        System.out.printf("\nOld : %s\n", member[correctIndex].getCardNum());
                        System.out.printf("New : %s\n", cardnum);
                        member[correctIndex].setcardNum(cardnum);
                        break;
                    case 3:
                        break;
                    default:
                        System.out.print("Error Input, the choice (1-3) are required!\n");
                        break;

                }
            } while (choice != 3);
        }
    }
    public static void removeMembership() {
        Scanner input = new Scanner(System.in);
        String searchid;
        int j = 0, k = 0;
        int correctIndex = -1;
        System.out.print("\n\nRemove Member\n");
        System.out.print("====================\n");
        System.out.print("Enter member ID (M0XX) : ");
        searchid = input.nextLine();
        for (int i = 0; i < member.length; i++) {
            if (searchid.equals(member[i].getID())) {
                correctIndex = i;
                j = i;
                k = i;
            }
        }
        if (correctIndex == -1) {
            System.out.print("Sorry, your membership you want to find is unknown.\n");
            return;
        } else {
            System.out.print("The member " + member[correctIndex].getName() + " is removed!\n");
            String[] id = new String[member.length - j - 1];
            for (int i = 0; i < id.length; i++) {
                id[i] = member[j].getID();
                j++;
            }
            Membership[] deleteMember = new Membership[member.length - k - 1];

            System.arraycopy(member, k + 1, deleteMember, 0, member.length - k - 1);
            System.arraycopy(deleteMember, 0, member, k, deleteMember.length);
            for (int i = 0; i < id.length; i++) {
                member[k].setID(id[i]);
                k++;
            }
            Membership[] newmember = new Membership[member.length - 1];
            System.arraycopy(member, 0, newmember, 0, member.length - 1);
            member = newmember;
        }
    }
    public static void modifyDiscount() {
        int choice = -1;
        boolean dataTypeloop = true;
        double memDis = 0, aniDis = 0;
        Scanner input = new Scanner(System.in);
        do {
            dataTypeloop = true;
            System.out.print("\nDiscount List\n");
            System.out.print("==================\n");
            System.out.print("Member discount      : " + String.format("%.2f%%\n", Membership.getDiscount() * 100));
            System.out.print("Anniversary discount : " + String.format("%.2f%%\n\n", Anniversary.getAnnDiscount() * 100));
            System.out.print("Which one you want modify?\n");
            System.out.print("1. Member Discount\n");
            System.out.print("2. Anniversary Discount\n");
            System.out.print("3. Exit Modify\n");
            do {
                try {

                    System.out.print("Enter here : ");
                    choice = input.nextInt();
                    dataTypeloop = false;
                } catch (Exception e) {
                    System.out.print("Incorrect input, an integer is required!\n");
                    input.nextLine();
                }
            } while (dataTypeloop);
            switch (choice) {
                case 1:
                    input.nextLine();
                    dataTypeloop = true;
                    do {
                        try {
                            System.out.print("\nType the new member discount(%): ");
                            memDis = input.nextDouble();
                            dataTypeloop = false;
                        } catch (Exception e) {
                            System.out.print("Incorrect input, a double is required!\n");
                            input.nextLine();
                        }
                    } while (dataTypeloop);
                    System.out.printf("\nOld Membership discount: %.2f%%\n", Membership.getDiscount() * 100);
                    System.out.printf("New Membership discount: %.2f%%\n", memDis);
                    Membership.setDiscount(memDis);
                    break;
                case 2:
                    input.nextLine();
                    dataTypeloop = true;
                    do {
                        try {
                            System.out.print("\nType the new aniversary discount(%): ");
                            aniDis = input.nextDouble();
                            dataTypeloop = false;
                        } catch (Exception e) {
                            System.out.print("Incorrect input, a double is required!\n");
                            input.nextLine();
                        }
                    } while (dataTypeloop);
                    System.out.printf("\nOld Anniversary discount: %.2f%%\n", Anniversary.getAnnDiscount() * 100);
                    System.out.printf("New Anniversary discount: %.2f%%\n", aniDis);
                    Anniversary.setAnnDiscount(aniDis);
                    break;
                case 3:
                    break;
                default:
                    System.out.print("Error Input, the choice (1-3) are required!\n");
                    break;
            }
        } while (choice != 3);
    }
    public static void displayMembership() {
        System.out.printf("\n %18s %s\n", "", "Membership List");
        System.out.print(String.format("%-15s %-25s %-15s", "MemberID", "Member Name", "Card Number") + "\n");
        System.out.print(String.format("%-15s %-25s %-15s", "===============", "=========================", "=================") + "\n");
        for (int j = 0; j < member.length; j++) {
            System.out.print(member[j].tableDisplay() + "\n");
        }
        System.out.print("\n" + "No. of Member Displayed : " + member.length + "\n");
        System.out.print("Member discount : " + String.format("%.2f", Membership.getDiscount() * 100) + "%\n");
    }

    //For Staff
    public static boolean staffMenu() {
        Scanner input = new Scanner(System.in);
        int choice = -1;
        boolean valid = false;
        do {
            valid = true;
            System.out.print("\nStaff Menu\n");
            System.out.print("==============================\n");
            System.out.print("1. Display Staff List\n");
            System.out.print("2. Search Staff Details\n");
            System.out.print("3. Modify Staff Details\n");
            System.out.print("4. Add new Staff\n");
            System.out.print("5. Remove existing Staff\n");
            System.out.print("6. Save and Exit Menu\n");
            do {
                try {
                    System.out.print("\nYour Choice : ");
                    choice = input.nextInt();
                    input.nextLine();
                    valid = false;
                } catch (Exception e) {
                    System.out.print("Invalid input, an integer is required!\n");
                    input.nextLine();
                }
            } while (valid);
            switch (choice) {
                case 1:
                    displayStaffList();
                    break;
                case 2:
                    searchStaff();
                    break;
                case 3:
                    modifyStaff();
                    break;
                case 4:
                    addStaff();
                    break;
                case 5:
                    removeStaff();
                    break;
                case 6:
                    break;
                default:
                    System.out.print("Invalid input , the choice (1-6) are required!\n");
                    break;
            }
        } while (choice != 6);
        return true;
    }
    public static void addStaff() {
        Scanner input = new Scanner(System.in);
        String name, password, position = "";
        String type;
        int choice = -1;
        boolean datatypeloop = true;
        System.out.print("\n\nAdd new Staff\n");
        System.out.print("=================================\n");
        System.out.print("Choose the type (HS = HighLevel/NS = NormalStaff) : ");
        type = input.nextLine().substring(0, 2);
        if (type.toUpperCase().equals("HS")) {
            System.out.print("\nNew High Level Management Staff\n");
            System.out.print("========================================\n");
            System.out.print("Please Enter the personal details: \n");
            System.out.print("Name : ");
            name = input.nextLine();
            System.out.print("Password: ");
            password = input.nextLine();
            System.out.print("Position: 1)Supervisor\n\t      2)Manager\n");
            do {
                try {
                    System.out.print("Choice : ");
                    choice = input.nextInt();
                    datatypeloop = false;
                    input.nextLine();
                } catch (Exception e) {
                    System.out.print("Invalid Input, an Integer is required!\n");
                    input.nextLine();
                }
                if (choice != 1 && choice != 2) {
                    System.out.print("Invalid choice entered!\n");
                    datatypeloop = true;
                }
            } while (datatypeloop);
            if (choice == 1) {
                position = "Supervisor";
            } else if (choice == 2) {
                position = "Manager";
            }
            addHighStaff(name, password, position);
        } else if (type.toUpperCase().equals("NS")) {
            System.out.print("\nNew Normal Staff\n");
            System.out.print("========================================\n");
            System.out.print("Please Enter the personal details: \n");
            System.out.print("Name : ");
            name = input.nextLine();
            System.out.print("Password: ");
            password = input.nextLine();
            position = "Waiter";
            addNomralStaff(name, password, position);
        }
    }
    public static void addNomralStaff(String name, String password, String position) {
        NormalStaff[] newNStaff = new NormalStaff[nStaff.length + 1];
        System.arraycopy(nStaff, 0, newNStaff, 0, nStaff.length);
        nStaff = newNStaff;
        nStaff[nStaff.length - 1] = new NormalStaff(name, password, position);
        System.out.print("\nNew Employee \"" + nStaff[nStaff.length - 1].getStaffID() + "\" Added!\n");
        System.out.print(nStaff[nStaff.length - 1].toString() + "\n");
    }
    public static void addHighStaff(String name, String password, String position) {
        HighLevelManagement[] newHStaff = new HighLevelManagement[hStaff.length + 1];
        System.arraycopy(hStaff, 0, newHStaff, 0, hStaff.length);
        hStaff = newHStaff;
        hStaff[hStaff.length - 1] = new HighLevelManagement(name, password, position);
        System.out.print("\nNew Employee \"" + hStaff[hStaff.length - 1].getStaffID() + "\" Added!\n");
        System.out.print(hStaff[hStaff.length - 1].toString() + "\n");
    }
    public static void searchStaff() {
        Scanner input = new Scanner(System.in);
        String id;
        int correctIndex = -1;
        System.out.print("\nSearch Staff\n");
        System.out.print("=============================");
        System.out.print("\nEnter StaffID (NS0XX/HS0XX) : ");
        id = input.nextLine();
        if (id.substring(0, 2).equals("NS")) {
            for (int i = 0; i < nStaff.length; i++) {
            	if(id.equals(nStaff[i].getStaffID())){
            		System.out.print(nStaff[i].toString() + "\n");
            		correctIndex = i;
            	}        
            }
        } else if (id.substring(0, 2).equals("HS")) {
            for (int i = 0; i < hStaff.length; i++) {
            	if(id.equals(hStaff[i].getStaffID())){
            		System.out.print(hStaff[i].toString() + "\n");
            		correctIndex = i;
            	}
            }
        } else {
            System.out.print("Sorry, we only have defined (\"NS\" and \"HS\")");
            return;
        }

        if (correctIndex == -1) {
            System.out.print("Sorry, the Staff ID entered cannot be found.\n");
        }
        return;
    }
    public static void modifyStaff() {
        Scanner input = new Scanner(System.in);
        String id;
        String comfirm;
        boolean repeat = true;
        boolean yesOrNo = true;
        boolean dataTypeloop = true;
        System.out.print("\nModify Staff\n");
        System.out.print("=============================");
        do {
            System.out.print("\nEnter Staff ID (NS0XX/HS0XX) : ");
            id = input.nextLine();

            if (id.substring(0, 2).equals("HS")) {
                yesOrNo = modifyHighStaff(id);
                dataTypeloop = false;
                if (!(yesOrNo)) {
                    System.out.print("\nDo you want to enter the StaffID again?");
                    System.out.print("\nYes or No: ");
                    comfirm = input.nextLine().toUpperCase();
                    if (comfirm.equals("YES")) {
                        dataTypeloop = true;
                    }
                }
            } else if (id.substring(0, 2).equals("NS")) {
                yesOrNo = modifyNormalStaff(id);
                dataTypeloop = false;
                if (!(yesOrNo)) {
                    System.out.print("\nDo you want to enter the StaffID again?");
                    System.out.print("\nYes or No: ");
                    comfirm = input.nextLine().toUpperCase();
                    if (comfirm.equals("YES")) {
                        dataTypeloop = true;
                    }
                }
            } else {
                System.out.print("\nInvalid Id entered!");
                System.out.print("\nDo you want to enter the StaffID again?");
                System.out.print("\nYes or No: ");
                comfirm = input.nextLine().toUpperCase();
                if (comfirm.equals("YES")) {
                    dataTypeloop = true;
                } else {
                    dataTypeloop = false;
                }
            }


        } while (dataTypeloop);

    }
    public static boolean modifyNormalStaff(String id) {
        Scanner input = new Scanner(System.in);
        int select = -1, choice = -1, correctID = -1, passConfirm = -1;
        String name, password, currentPassword, confirmPassword, position;
        boolean datatypeloop = true;
        for (int i = 0; i < nStaff.length; i++) {
            if (id.equals(nStaff[i].getStaffID())) {
                correctID = i;
            }
        }
        if (correctID != -1) {
            do {
                System.out.print(nStaff[correctID].toString() + "\n");
                System.out.print("\nWhich attribute that you want to modify?");
                System.out.print("\n1.Staff Name\n2.Password\n3.Exit");
                do {
                    datatypeloop = true;
                    try {
                        System.out.print("\nSelection(1/2/3) > ");
                        select = input.nextInt();
                        datatypeloop = false;
                        input.nextLine();
                    } catch (Exception e) {
                        System.out.print("Invalid Data type entered, an Integer is required!\n");
                        input.nextLine();
                    }
                } while (datatypeloop);

                switch (select) {
                    case 1:
                        System.out.print("\nPlease Enter the personal details: \n");
                        System.out.print("Name : ");
                        name = input.nextLine();
                        System.out.printf("\nOld : %s\n", nStaff[correctID].getname());
                        System.out.printf("New : %s\n", name);
                        nStaff[correctID].setName(name);
                        break;

                    case 2:
                        System.out.print("Enter Current Password: ");
                        currentPassword = input.nextLine();
                        if (currentPassword.equals(nStaff[correctID].getPassword())) {
                            do {
                                passConfirm = -1;
                                System.out.print("Enter the New Password: ");
                                password = input.nextLine();
                                System.out.print("Comfirm the New Password: ");
                                confirmPassword = input.nextLine();
                                if (confirmPassword.equals(password)) {
                                    nStaff[correctID].setPassword(password);
                                    System.out.print("\nNew Password Set!\n");
                                    passConfirm = 1;
                                } else {
                                    System.out.print("\nBoth Password does not Match!");
                                }
                            } while (passConfirm == -1);


                        }
                        break;
                    case 3:
                        break;
                    default:
                        System.out.print("No Selection Selected!\n");


                }
            } while (select != 3);
            return true;
        } else {
            System.out.print("\nSorry, the staff ID you want to modify is unknown\n");
            return false;
        }
    }
    public static boolean modifyHighStaff(String id) {
        Scanner input = new Scanner(System.in);
        int select = -1, choice = -1, correctID = -1, passConfirm = -1;
        String name, password, currentPassword, confirmPassword, position = "";
        boolean datatypeloop = true;
        for (int i = 0; i < hStaff.length; i++) {
            if (id.equals(hStaff[i].getStaffID())) {
                correctID = i;
            }
        }
        if (correctID != -1) {
            do {
                System.out.print(hStaff[correctID].toString() + "\n");
                System.out.print("\nWhich attribute that you want to modify?");
                System.out.print("\n1.Staff Name\n2.Staff Position\n3.Password\n4.Exit");
                do {
                    datatypeloop = true;
                    try {
                        System.out.print("\nSelection(1/2/3/4) > ");
                        select = input.nextInt();
                        datatypeloop = false;
                        input.nextLine();
                    } catch (Exception e) {
                        System.out.print("Invalid Data type entered, an Integer is required!\n");
                        input.nextLine();
                    }
                } while (datatypeloop);

                switch (select) {
                    case 1:
                        System.out.print("Please Enter the personal details: \n");
                        System.out.print("Name : ");
                        name = input.nextLine();
                        System.out.printf("\nOld : %s\n", hStaff[correctID].getname());
                        System.out.printf("New : %s\n", name);
                        hStaff[correctID].setName(name);
                        break;

                    case 2:
                        System.out.print("Position: 1)Supervisor\n\t      2)Manager\n");
                        do {
                            datatypeloop = true;
                            try {
                                System.out.print("Enter here : ");
                                choice = input.nextInt();
                                datatypeloop = false;
                                input.nextLine();
                            } catch (Exception e) {
                                System.out.print("Invalid Input, an Integer is required!\n");
                                input.nextLine();
                            }
                        } while (datatypeloop);

                        if (choice == 1) {
                            System.out.printf("\nOld : %s\n", hStaff[correctID].getHLMPosition());
                            System.out.printf("New : %s\n", "Supervisor");
                            position = "Supervisor";
                        } else if (choice == 2) {
                            System.out.printf("\nOld : %s\n", hStaff[correctID].getHLMPosition());
                            System.out.printf("New : %s\n", "Manager");
                            position = "Manager";
                        }

                        hStaff[correctID].setHLMPosition(position);
                        break;
                    case 3:
                        System.out.print("Enter Current Password: ");
                        currentPassword = input.nextLine();
                        if (currentPassword.equals(hStaff[correctID].getPassword())) {
                            do {
                                passConfirm = -1;
                                System.out.print("Enter the New Password: ");
                                password = input.nextLine();
                                System.out.print("Comfirm the New Password: ");
                                confirmPassword = input.nextLine();
                                if (confirmPassword.equals(password)) {
                                    hStaff[correctID].setPassword(password);
                                    System.out.print("\nNew Password Set!");
                                    passConfirm = 1;
                                } else {
                                    System.out.print("\nBoth Password does not Match!");
                                }
                            } while (passConfirm == -1);


                        }
                        break;
                    case 4:
                        break;
                    default:
                        System.out.print("No Selection Selected!\n");

                }
            } while (select != 4);
            return true;
        } else {
            System.out.print("\nSorry, the staff ID you want to modify is unknown\n");
            return false;
        }
    }
    public static void removeStaff() {
        Scanner input = new Scanner(System.in);
        String searchid;
        int j = 0, k = 0;
        int correctIndex = -1, type = -1;
        System.out.print("\n\nRemove Staff\n");
        System.out.print("====================\n");
        System.out.print("Enter Staff ID (HS0XX/NS0XX) : ");
        searchid = input.nextLine();
        if(trueID.equals(searchid)){
        	System.out.print("You can't remove staff ID in current used!\n");
        	return;
        }
        if (searchid.substring(0, 2).equals("HS")) {
            for (int i = 0; i < hStaff.length; i++) {
                if (searchid.equals(hStaff[i].getStaffID())) {
                    correctIndex = i;
                    j = i;
                    k = i;
                    type = 1;
                } else {
                    type = 1;
                }
            }

        } else if (searchid.substring(0, 2).equals("NS")) {
            for (int i = 0; i < nStaff.length; i++) {
                if (searchid.equals(nStaff[i].getStaffID())) {
                    correctIndex = i;
                    j = i;
                    k = i;
                    type = 2;
                } else {
                    type = 2;
                }
            }
        }

        if (type == 1) {
            if (correctIndex == -1) {
                System.out.print("Sorry, your membership you want to find is unknown.\n");
                return;
            } else {
                System.out.print("The member " + hStaff[correctIndex].getname() + " is removed!\n");
                String[] id = new String[hStaff.length - j - 1];
                for (int i = 0; i < id.length; i++) {
                    id[i] = hStaff[j].getStaffID();
                    j++;
                }
                HighLevelManagement[] deletehStaff = new HighLevelManagement[hStaff.length - k - 1];

                System.arraycopy(hStaff, k + 1, deletehStaff, 0, hStaff.length - k - 1);
                System.arraycopy(deletehStaff, 0, hStaff, k, deletehStaff.length);
                for (int i = 0; i < id.length; i++) {
                    hStaff[k].setStaffID(id[i]);
                    k++;
                }
                HighLevelManagement[] newhStaff = new HighLevelManagement[hStaff.length - 1];
                System.arraycopy(hStaff, 0, newhStaff, 0, hStaff.length - 1);
                hStaff = newhStaff;
            }
        } else if (type == 2) {
            if (correctIndex == -1) {
                System.out.print("Sorry, your membership you want to find is unknown.\n");
                return;
            } else {
                System.out.print("The member " + nStaff[correctIndex].getname() + " is removed!\n");
                String[] id = new String[nStaff.length - j - 1];
                for (int i = 0; i < id.length; i++) {
                    id[i] = nStaff[j].getStaffID();
                    j++;
                }
                NormalStaff[] deletenStaff = new NormalStaff[nStaff.length - k - 1];

                System.arraycopy(nStaff, k + 1, deletenStaff, 0, nStaff.length - k - 1);
                System.arraycopy(deletenStaff, 0, nStaff, k, deletenStaff.length);
                for (int i = 0; i < id.length; i++) {
                    nStaff[k].setStaffID(id[i]);
                    k++;
                }
                NormalStaff[] newnStaff = new NormalStaff[nStaff.length - 1];
                System.arraycopy(nStaff, 0, newnStaff, 0, nStaff.length - 1);
                nStaff = newnStaff;
            }
        } else {
            System.out.print("Sorry, we only have defined (\"NS\" and \"HS\")");
        }
    }
    public static void displayStaffList() {
        System.out.printf("\n %32s %s\n", "", "Staff List");
        System.out.print(String.format("%-15s %-25s %-30s %-20s", "StaffID", "Staff Name", "Category", "Position") + "\n");
        System.out.print(String.format("%-15s %-25s %-30s %-20s", "===============", "=========================", "==============================", "===================") + "\n");
        for (int j = 0; j < 2; j++) {
            if (j == 0) {
                for (int i = 0; i < hStaff.length; i++) {
                    System.out.print(hStaff[i].tableDisplay() + "\n");
                }
            } else if (j == 1) {
                for (int i = 0; i < nStaff.length; i++) {
                    System.out.print(nStaff[i].tableDisplay() + "\n");
                }
            }
        }
        System.out.print("\n" + "No. of Staff Displayed : " + (nStaff.length + hStaff.length) + "\n");
    }

    public static void main(String[] args) {
    	Scanner input = new Scanner(System.in);
    	int goTo = -1;
    	String yesorno;
        do{
        	goTo = -1;
        	do{
        		goTo = selection();
        	}while(goTo == 2);
        	if(goTo == 1){
        		report = new salesReport(food, drink, dessert);
        		order();
       			displayReport();
        	}
        	System.out.print("\n\nDo you want to open again? : \n");
        	System.out.print("Yes or No : ");
        	yesorno = input.nextLine();
        	if(yesorno.toUpperCase().equals("YES")){
        		goTo = 2;
        		System.out.print("\n\n");
        	}else{
        		goTo = 3;
        	}
        }while(goTo == 2);

    }

}