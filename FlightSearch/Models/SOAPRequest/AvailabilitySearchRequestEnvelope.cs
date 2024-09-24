using System.Xml.Serialization;

namespace FlightSearch.Models.SOAPRequest;

[XmlRoot(ElementName = "Envelope", Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
public class AvailabilitySearchRequestEnvelope
{
  [XmlElement(ElementName = "Header", Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
  public string Header { get; set; }

  [XmlElement(ElementName = "Body", Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
  public AvailabilitySearchRequestBody Body { get; set; }
}