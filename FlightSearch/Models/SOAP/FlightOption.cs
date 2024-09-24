using System.Xml.Serialization;

namespace FlightSearch.Models.SOAP;

public class FlightOption
{
  [XmlElement(ElementName = "ArrivalDateTime", Namespace = "http://schemas.datacontract.org/2004/07/FlightProvider")]
  public string ArrivalDateTime { get; set; }

  [XmlElement(ElementName = "DepartureDateTime", Namespace = "http://schemas.datacontract.org/2004/07/FlightProvider")]
  public string DepartureDateTime { get; set; }

  [XmlElement(ElementName = "FlightNumber", Namespace = "http://schemas.datacontract.org/2004/07/FlightProvider")]
  public string FlightNumber { get; set; }

  [XmlElement(ElementName = "Price", Namespace = "http://schemas.datacontract.org/2004/07/FlightProvider")]
  public decimal Price { get; set; }
}