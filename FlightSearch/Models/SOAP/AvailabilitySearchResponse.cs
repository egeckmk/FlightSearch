using System.Xml.Serialization;

namespace FlightSearch.Models.SOAP;

public class AvailabilitySearchResponse
{
  [XmlElement(ElementName = "AvailabilitySearchResult", Namespace = "http://tempuri.org/")]
  public AvailabilitySearchResult AvailabilitySearchResult { get; set; }
}