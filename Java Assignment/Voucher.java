/**
 * @(#)Voucher.java
 *
 *
 * @author 
 * @version 1.00 2019/8/6
 */
package structure;

public class Voucher {

    private String voucherCode;
    private double voucherPrice;
    private static int noOfVoucher;

    public Voucher(String voucherCode, double voucherPrice) {
        this.voucherCode = voucherCode;
        this.voucherPrice = voucherPrice;
        noOfVoucher++;
    }

    public Voucher() {

    }

    public double getVoucherPrice() {
        return voucherPrice;
    }

    public String getVoucherCode() {
        return voucherCode;
    }



}