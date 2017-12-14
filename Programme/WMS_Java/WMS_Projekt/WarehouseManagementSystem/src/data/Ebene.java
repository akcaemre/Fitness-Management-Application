package data;

public class Ebene {

    private String eId;
    private String regalId;

    public Ebene(String id, String regalId) {
        seteId(id);
    }

    public String geteId() {
        return eId;
    }
    private void seteId(String eId) {
        this.eId = eId;
    }

    public String getRegalId() {
        return regalId;
    }
    private void setRegalId(String regalId) {
        this.regalId = regalId;
    }
}
