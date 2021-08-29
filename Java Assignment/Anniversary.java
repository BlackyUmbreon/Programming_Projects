/**
 * @(#)Anniversary.java
 *
 *
 * @author 
 * @version 1.00 2019/8/6
 */
package structure;

public class Anniversary {

    private static int day = 5;
    private static int month = 12;
    private static double annDiscount = 0.5;

    public Anniversary() {}

    public void setDay(int day) {
        this.day = day;
    }

    public void setMonth(int month) {
        this.month = month;
    }

    public int getDay() {
        return day;
    }

    public int getMonth() {
        return month;
    }

    public static void setAnnDiscount(double percent) {
        annDiscount = percent / 100;
    }

    public static double getAnnDiscount() {
        return annDiscount;
    }

    public String toString() {
        switch (month) {
            case 1:
                return "The Anniversary discount of " + String.format("%.2f%%", getAnnDiscount() * 100) + " is only every year in " + day + " January.\n";
            case 2:
                return "The Anniversary discount of " + String.format("%.2f%%", getAnnDiscount() * 100) + " is only every year in " + day + " February.\n";
            case 3:
                return "The Anniversary discount of " + String.format("%.2f%%", getAnnDiscount() * 100) + " is only every year in " + day + " March.\n";
            case 4:
                return "The Anniversary discount of " + String.format("%.2f%%", getAnnDiscount() * 100) + " is only every year in " + day + " April.\n";
            case 5:
                return "The Anniversary discount of " + String.format("%.2f%%", getAnnDiscount() * 100) + " is only every year in " + day + " May.\n";
            case 6:
                return "The Anniversary discount of " + String.format("%.2f%%", getAnnDiscount() * 100) + " is only every year in " + day + " June.\n";
            case 7:
                return "The Anniversary discount of " + String.format("%.2f%%", getAnnDiscount() * 100) + " is only every year in " + day + " July.\n";
            case 8:
                return "The Anniversary discount of " + String.format("%.2f%%", getAnnDiscount() * 100) + " is only every year in " + day + " August.\n";
            case 9:
                return "The Anniversary discount of " + String.format("%.2f%%", getAnnDiscount() * 100) + " is only every year in " + day + " September.\n";
            case 10:
                return "The Anniversary discount of " + String.format("%.2f%%", getAnnDiscount() * 100) + " is only every year in " + day + " October.\n";
            case 11:
                return "The Anniversary discount of " + String.format("%.2f%%", getAnnDiscount() * 100) + " is only every year in " + day + " November.\n";
            case 12:
                return "The Anniversary discount of " + String.format("%.2f%%", getAnnDiscount() * 100) + " is only every year in " + day + " December.\n";
            default:
                return "";
        }

    }


}