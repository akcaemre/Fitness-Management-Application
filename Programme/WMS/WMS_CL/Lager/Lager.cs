public class Lager
{
    private string _myID = "L";

    public Lager(string LID, string Name, string Adresse)
    {
        _myID = LID;
        this.Name = Name;
        this.Adresse = Adresse;
    }

    public Lager(int LID, string Name, string Adresse)
    {
        _myID += LID;
        this.Name = Name;
        this.Adresse = Adresse;
    }

    public string LID
	{
		get
        {
            return _myID;
        }
	}

	public string Name
	{
		get;
		set;
	}

	public string Adresse
	{
		get;
		set;
	}

    public override string ToString()
    {
        return "Lager " + Name + " in " + Adresse;
    }
}

