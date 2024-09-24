using System.Xml.Serialization;

namespace FlightSearch.Models.SOAP;

public class Body
{
  [XmlElement(ElementName = "AvailabilitySearchResponse", Namespace = "http://tempuri.org/")]
  public AvailabilitySearchResponse AvailabilitySearchResponse { get; set; }
}