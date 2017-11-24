public class Produkt
{
    private string _myID = "P";
    public Produkt () { }
    public Produkt (string PID, string Name, int Menge, int PreisProEinheit, Ebene MeineEbene)
    {
        _myID = PID;
        this.Name = Name;
        this.Menge = Menge;
        this.PreisProEinheit = PreisProEinheit;
        this.MeineEbene = MeineEbene;
    }

    public Produkt(int PID, string Name, int Menge, int PreisProEinheit, Ebene MeineEbene)
    {
        _myID += PID;
        this.Name = Name;
        this.Menge = Menge;
        this.PreisProEinheit = PreisProEinheit;
        this.MeineEbene = MeineEbene;
    }

    public string PID
	{
		get
        {
            return MeineEbene.EID + "-" + _myID;
        }
        set { _myID = value; }
	}

	public string Name
	{
		get;
		set;
	}

	public int Menge
	{
		get;
		set;
	}

	public int PreisProEinheit
	{
		get;
		set;
	}

    public Ebene MeineEbene
    {
        get;
        set;
    }

    public override string ToString()
    {
        return Name + " " + Menge + " Stück";
    }
}

