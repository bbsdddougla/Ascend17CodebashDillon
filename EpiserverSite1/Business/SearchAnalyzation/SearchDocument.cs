namespace EpiserverSite1.Business.SearchAnalyzation
{ 
public interface ISearchDocument
{

    int Id { get; set; }

    string Language { get; set; }

    string Text { get; set; }
}

public class SearchDocument : ISearchDocument
{

    public int Id { get; set; }

    public string Language { get; set; }

    public string Text { get; set; }
}
}