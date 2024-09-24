using System.Xml.Serialization;

namespace FlightSearch.Models.SOAPRequest;

public class SearchRequest
{
  [XmlElement(ElementName = "DepartureDate", Namespace = "http://schemas.datacontract.org/2004/07/FlightProvider")]
  public string DepartureDate { get; set; }

  [XmlElement(ElementName = "Destination", Namespace = "http://schemas.datacontract.org/2004/07/FlightProvider")]
  public string Destination { get; set; }

  [XmlElement(ElementName = "Origin", Namespace = "http://schemas.datacontract.org/2004/07/FlightProvider")]
  public string Origin { get; set; }
}