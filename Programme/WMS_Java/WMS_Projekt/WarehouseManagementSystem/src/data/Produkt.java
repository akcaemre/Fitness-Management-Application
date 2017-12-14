package data;

public class Produkt {

    private String pId;
    private String name;
    private int menge;
    private double einheitspreis;
    private String ebenenId;



    public Produkt(String id, String name, int menge, double preis, String eId) {
        setpId(id);
        setName(name);
        setMenge(menge);
        setEinheitspreis(preis);
        setEbenenId(eId);
    }

    public String getpId() {
        return pId;
    }
    private void setpId(String pId) {
        this.pId = pId;
    }

    public String getName() {
        return name;
    }
    private void setName(String name) {
        this.name = name;
    }

    public int getMenge() {
        return menge;
    }
    private void setMenge(int menge) {
        this.menge = menge;
    }

    public double getEinheitspreis() {
        return einheitspreis;
    }
    private void setEinheitspreis(double einheitspreis) {
        this.einheitspreis = einheitspreis;
    }

    public String getEbenenId() {
        return ebenenId;
    }
    private void setEbenenId(String ebenenId) {
        this.ebenenId = ebenenId;
    }
}
