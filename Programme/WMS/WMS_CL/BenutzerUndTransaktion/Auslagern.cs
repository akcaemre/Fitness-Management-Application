public class Auslagern
{
    public Auslagern (System.DateTime am, int Menge, int Preis, Produkt MeinProdukt, Benutzer MeinBenutzer)
    {
        this.am = am;
        this.Menge = Menge;
        this.Preis = Preis;
        this.MeinProdukt = MeinProdukt;
        this.MeinBenutzer = MeinBenutzer;
    }

	public System.DateTime am
	{
		get;
		set;
	}

	public int Menge
	{
		get;
		set;
	}

	public int Preis
	{
		get;
		set;
	}

	public Produkt MeinProdukt
	{
		get;
		set;
	}

	public Benutzer MeinBenutzer
	{
		get;
		set;
	}
}