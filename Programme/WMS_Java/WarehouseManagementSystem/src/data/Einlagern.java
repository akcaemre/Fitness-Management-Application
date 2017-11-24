package data;

import java.util.Date;

public class Einlagern {

    private String eMail;
    private String pId;
    private Date am;

    private int menge;
    private double preis;

    public Einlagern(String eMail, String productId, Date am, int menge, double price) {
        seteMail(eMail);
        setpId(productId);
        setAm(am);
        setMenge(menge);
        setPreis(price);
    }

    public String geteMail() {
        return eMail;
    }
    private void seteMail(String eMail) {
        this.eMail = eMail;
    }

    public String getpId() {
        return pId;
    }
    private void setpId(String pId) {
        this.pId = pId;
    }

    public Date getAm() {
        return am;
    }
    private void setAm(Date am) {
        this.am = am;
    }

    public int getMenge() {
        return menge;
    }
    private void setMenge(int menge) {
        this.menge = menge;
    }

    public double getPreis() {
        return preis;
    }
    private void setPreis(double preis) {
        this.preis = preis;
    }
}
