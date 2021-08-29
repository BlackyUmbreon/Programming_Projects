/**
 * @(#)HighLevelManagement.java
 *
 *
 * @author 
 * @version 1.00 2019/8/6
 */
package structure;

public class HighLevelManagement extends Staff {
    private String HLMPosition;
    private static int noOfManager = 0;
    private static String hlmHeading = "HS";

    public HighLevelManagement() {}

    public HighLevelManagement(String name, String password, String HLMPosition) {
        super(hlmHeading, name, password, "High Level Management", noOfManager);
        this.HLMPosition = HLMPosition;
        noOfManager++;
    }

    public void setHLMPosition(String HLMPosition) {
        this.HLMPosition = HLMPosition;
    }

    public String getHLMPosition() {
        return HLMPosition;
    }

    public String toString() {
        return "\nStaff ID: " + super.getStaffID() + "\nName: " + super.getname() + "\nCategory: High Level Management" + "\nManagement Position: " + HLMPosition;
    }

    public String tableDisplay() {
        return super.tableDisplay() + String.format("%-20s", HLMPosition);
    }

}