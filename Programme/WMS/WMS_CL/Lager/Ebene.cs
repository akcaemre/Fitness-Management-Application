public class Ebene
{
    private string _myID = "E";

    public Ebene (Regal MeinRegal, int EID)
    {
        _myID += EID;
        this.MeinRegal = MeinRegal;
    }

    public Ebene(Regal MeinRegal, string EID)
    {
        _myID = EID;
        this.MeinRegal = MeinRegal;
    }

    public string EID
	{
		get
        {
            return MeinRegal.RID + "-" + _myID;
        }
	}

	public Regal MeinRegal
	{
		get;
		set;
	}

    public override string ToString()
    {
        return "Ebene " + EID.Remove(0, EID.Length-1) + " in Regal " + MeinRegal.RID.Remove(0, MeinRegal.RID.Length-1);
    }
}

