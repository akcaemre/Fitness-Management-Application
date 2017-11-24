package data;

public class Regal {

    private String rId;
    private int maxEbene;
    private int xPosition;
    private int yPosition;
    private String lagerId;

    public Regal(String id, int maxEbene, int xP, int yP, String lId) {
        setrId(id);
        setMaxEbene(maxEbene);
        setxPosition(xP);
        setyPosition(yP);
        setLagerId(lId);
    }

    public String getrId() {
        return rId;
    }
    private void setrId(String rId) {
        this.rId = rId;
    }

    public int getMaxEbene() {
        return maxEbene;
    }
    private void setMaxEbene(int maxEbene) {
        this.maxEbene = maxEbene;
    }

    public int getxPosition() {
        return xPosition;
    }
    private void setxPosition(int xPosition) {
        this.xPosition = xPosition;
    }

    public int getyPosition() {
        return yPosition;
    }
    private void setyPosition(int yPosition) {
        this.yPosition = yPosition;
    }

    public String getLagerId() {
        return lagerId;
    }
    private void setLagerId(String lagerId) {
        this.lagerId = lagerId;
    }
}
