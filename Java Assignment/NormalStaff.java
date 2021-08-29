/**
 * @(#)NormalStaff.java
 *
 *
 * @author 
 * @version 1.00 2019/8/6
 */
package structure;

public class NormalStaff extends Staff {
    private String NSPosition;
    private static String nsHeading = "NS";
    private static int noOfNorStaff = 0;

    public NormalStaff() {}

    public NormalStaff(String name, String password, String NSPosition) {
        super(nsHeading, name, password, "Normal Staff", noOfNorStaff);
        this.NSPosition = NSPosition;
        noOfNorStaff++;
    }

    public void setNSPosition(String NSPosition) {
        this.NSPosition = NSPosition;
    }

    public String getNSPosition() {
        return NSPosition;
    }

    public String toString() {
        return "\nStaff ID: " + super.getStaffID() + "\nName: " + super.getname() + "\nCategory: Normal Staff" + "\nStaff Position: " + NSPosition;
    }

    public String tableDisplay() {
        return super.tableDisplay() + String.format("%-20s", NSPosition);
    }

}