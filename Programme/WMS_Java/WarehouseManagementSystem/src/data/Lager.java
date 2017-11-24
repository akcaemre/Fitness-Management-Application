package data;

public class Lager {

    private String lId;
    private String name;
    private String adresse;

    public Lager(String id, String name, String adresse) {
        setlId(id);
        setName(name);
        setAdresse(adresse);
    }

    public String getlId() {
        return lId;
    }
    private void setlId(String lId) {
        this.lId = lId;
    }

    public String getName() {
        return name;
    }
    private void setName(String name) {
        this.name = name;
    }

    public String getAdresse() {
        return adresse;
    }
    private void setAdresse(String adresse) {
        this.adresse = adresse;
    }
}
