using System.Xml.Serialization;

namespace FlightSearch.Models.SOAPRequest;

public class AvailabilitySearchRequestBody
{
  [XmlElement(ElementName = "AvailabilitySearch", Namespace = "http://tempuri.org/")]
  public AvailabilitySearch AvailabilitySearch { get; set; }
}