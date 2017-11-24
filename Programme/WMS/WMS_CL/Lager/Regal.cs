using System.Collections.Generic;
using System.Windows;

public class Regal
{
    private string _myID = "R";
    public Regal (Lager MeinLager, string RID, int MaxEbene, List<Point> Position)
    {
        this.MeinLager = MeinLager;
        _myID = RID;
        this.MaxEbene = MaxEbene;
        this.Position = Position;
    }

    public Regal(Lager MeinLager, int RID, int MaxEbene, List<Point> Positio)
    {
        this.MeinLager = MeinLager;
        _myID += RID;
        this.MaxEbene = MaxEbene;
        this.Position = Position;
    }

    public Regal(Lager MeinLager, string RID, int MaxEbene)
    {
        this.MeinLager = MeinLager;
        _myID = RID;
        this.MaxEbene = MaxEbene;
        Position = new List<Point>();
    }

    public Regal(Lager MeinLager, int RID, int MaxEbene)
    {
        this.MeinLager = MeinLager;
        _myID += RID;
        this.MaxEbene = MaxEbene;
        Position = new List<Point>();
    }


    public string RID
	{
		get
        {
            return MeinLager.LID + "-" + _myID;
        }
	}

	public int MaxEbene
	{
		get;
		set;
	}

	public List<Point> Position
	{
		get;
		set;
	}

	public Lager MeinLager
	{
		get;
		private set;
	}
    public override string ToString()
    {
        return "Regal " + RID.Remove(0, RID.Length - 1) + " in Lager " + MeinLager.LID.Remove(0, MeinLager.LID.Length - 1);
    }
}

