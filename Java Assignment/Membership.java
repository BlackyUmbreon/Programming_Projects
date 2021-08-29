/**
 * @(#)Membership.java
 *
 *
 * @author 
 * @version 1.00 2019/8/6
 */
package structure;

public class Membership {
    private String memberID;
    private String memberName;
    private String cardNum;
    private static double discount = 0.1;
    private static int noOfMember;

    public Membership() {
        if (noOfMember < 9)
            this.memberID = "M00" + (noOfMember + 1);
        else if (noOfMember >= 9 && noOfMember < 99)
            this.memberID = "M0" + (noOfMember + 1);
        else if (noOfMember >= 99 && noOfMember < 999)
            this.memberID = "M" + (noOfMember + 1);
        else {
            System.out.println("Member registration is full.");
            return;
        }
    }

    public Membership(String memberName, String cardNum) {
        if (noOfMember < 9)
            this.memberID = "M00" + (noOfMember + 1);
        else if (noOfMember >= 9 && noOfMember < 99)
            this.memberID = "M0" + (noOfMember + 1);
        else if (noOfMember >= 99 && noOfMember < 999)
            this.memberID = "M" + (noOfMember + 1);
        else {
            System.out.println("Member registration is full.");
            return;
        }
        this.memberName = memberName;
        this.cardNum = cardNum;
        noOfMember++;
    }

    public void membershipValid(String memberID, String memberName, String cardNum) {
        this.memberID = memberID;
        this.memberName = memberName;
        this.cardNum = cardNum;
    }

    public void setID(String memberID) {
        this.memberID = memberID;
    }

    public void setName(String memberName) {
        this.memberName = memberName;
    }

    public void setcardNum(String cardNum) {
        this.cardNum = cardNum;
    }

    public static void setDiscount(double percent) {
        discount = percent / 100;
    }

    public String getID() {
        return memberID;
    }

    public String getName() {
        return memberName;
    }

    public String getCardNum() {
        return cardNum;
    }

    public static double getDiscount() {
        return discount;
    }

    public int getNoOfMember() {
        return noOfMember;
    }

    public String tableDisplay() {
        String s1 = String.format("%-15s %-25s %-15s", memberID, memberName, cardNum);
        return s1;
    }

    public String toString() {
        return "\nMember ID   : " + memberID + "\nMember Name : " + memberName + "\nCard Number : " + cardNum + "\n\n";
    }

}