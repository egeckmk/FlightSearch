using System.Xml.Serialization;

namespace FlightSearch.Models.SOAP;

public class AvailabilitySearchResult
{
  [XmlArray(ElementName = "FlightOptions", Namespace = "http://schemas.datacontract.org/2004/07/FlightProvider")]
  [XmlArrayItem(ElementName = "FlightOption", Namespace = "http://schemas.datacontract.org/2004/07/FlightProvider")]
  public List<FlightOption> FlightOptions { get; set; }

  [XmlElement(ElementName = "HasError", Namespace = "http://schemas.datacontract.org/2004/07/FlightProvider")]
  public bool HasError { get; set; }
}