package data;

import java.util.Date;

public class Auslagern {

    private String eMail;
    private String pId;
    private Date  am;

    private int menge;
    private double preis;

    public Auslagern() {

    }

    public String geteMail() {
        return eMail;
    }
    public void seteMail(String eMail) {
        this.eMail = eMail;
    }

    public String getpId() {
        return pId;
    }
    public void setpId(String pId) {
        this.pId = pId;
    }

    public Date getAm() {
        return am;
    }
    public void setAm(Date am) {
        this.am = am;
    }

    public int getMenge() {
        return menge;
    }
    public void setMenge(int menge) {
        this.menge = menge;
    }

    public double getPreis() {
        return preis;
    }

    public void setPreis(double preis) {
        this.preis = preis;
    }
}
