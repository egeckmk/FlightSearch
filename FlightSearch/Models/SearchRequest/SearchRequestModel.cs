namespace FlightSearch.Models.SearchRequest;

public class SearchRequestModel
{
  public string Origin { get; set; }
  public string Destination { get; set; }
  public DateTime DepartureDate { get; set; }
}