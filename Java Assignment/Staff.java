/**
 * @(#)Staff.java
 *
 *
 * @author 
 * @version 1.00 2019/8/6
 */
package structure;

public class Staff {
    private String staffID;
    private String name;
    private String password;
    private static int noOfStaff = 0;
    private String category;

    public Staff() {}

    public Staff(String levelHeading, String name, String password, String category, int noOflevel) {
        if (noOflevel < 9) {
            this.staffID = levelHeading + "00" + (noOflevel + 1);
        } else if (noOflevel >= 9 && noOflevel < 99) {
            this.staffID = levelHeading + "0" + (noOflevel + 1);
        } else if (noOflevel >= 99 && noOflevel < 999) {
            this.staffID = levelHeading + "" + (noOflevel + 1);
        } else {
            System.out.print("Too much staff!\n");
            return;
        }
        this.name = name;
        this.password = password;
        this.category = category;
        noOfStaff++;
    }

    public void setStaffID(String staffID) {
        this.staffID = staffID;
    }

    public void setName(String name) {
        this.name = name;
    }

    public void setPassword(String password) {
        this.password = password;
    }

    public void setCategory(String category) {
        this.category = category;
    }

    public String getStaffID() {
        return staffID;
    }

    public String getname() {
        return name;
    }

    public String getPassword() {
        return password;
    }

    public String getCategory() {
        return category;
    }

    public String tableDisplay() {
        return String.format("%-15s %-25s %-30s ", staffID, name, category);
    }

    public String toString() {
        return "\n";
    }

}