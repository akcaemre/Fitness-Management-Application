public class Benutzer
{
    public Benutzer (string eMail)
    {
        this.eMail = eMail;
    }

	public string eMail
	{
		get;
		set;
	}

    public override string ToString()
    {
        return eMail;
    }
}

