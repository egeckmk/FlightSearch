using System.Xml.Serialization;

namespace FlightSearch.Models.SOAPRequest;

public class AvailabilitySearch
{
  [XmlElement(ElementName = "request", Namespace = "http://tempuri.org/")]
  public SearchRequest Request { get; set; }
}