using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Xml.Serialization;
using FlightSearch.Models.SearchRequest;
using FlightSearch.Models.SOAPRequest;
using FlightSearch.Models.SOAP;

using Newtonsoft.Json;
using Microsoft.AspNetCore.Cors;


namespace FlightSearch.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FlightsController : ControllerBase
{
  private readonly HttpClient _httpClient;

  public FlightsController(HttpClient httpClient)
  {
    _httpClient = httpClient;
  }

  [HttpGet("health-check")]
  public IActionResult HealthCheck()
  {
    return Ok("OK");
  }

  [HttpPost("search")]
  public async Task<IActionResult> SearchFlights([FromBody] SearchRequestModel request)
  {
    var soapEnvelope = CreateSoapEnvelope(request);

    var httpRequest = new HttpRequestMessage(HttpMethod.Post, "http://localhost:5001/Service.svc")
    {
      Content = new StringContent(soapEnvelope, Encoding.UTF8, "text/xml")
    };

    httpRequest.Headers.Add("SOAPAction", "http://tempuri.org/IAirSearch/AvailabilitySearch");

    var response = await _httpClient.SendAsync(httpRequest);

    if (response.IsSuccessStatusCode)
    {
      var responseContent = await response.Content.ReadAsStringAsync();
      return Ok(ParseXmlToJson(responseContent));
    }

    var errorContent = await response.Content.ReadAsStringAsync();
    return StatusCode((int)response.StatusCode, $"Error occurred while calling the SOAP service. Details: {errorContent}");
  }

  private string CreateSoapEnvelope(SearchRequestModel request)
  {
    var envelope = new AvailabilitySearchRequestEnvelope
    {
      Header = null,
      Body = new AvailabilitySearchRequestBody
      {
        AvailabilitySearch = new AvailabilitySearch
        {
          Request = new SearchRequest
          {
            DepartureDate = request.DepartureDate.ToString("yyyy-MM-dd"),
            Destination = request.Destination,
            Origin = request.Origin
          }
        }
      }
    };

    var xmlSerializer = new XmlSerializer(typeof(AvailabilitySearchRequestEnvelope));

    var xmlNamespaces = new XmlSerializerNamespaces();
    xmlNamespaces.Add("soapenv", "http://schemas.xmlsoap.org/soap/envelope/");
    xmlNamespaces.Add("tem", "http://tempuri.org/");
    xmlNamespaces.Add("flig", "http://schemas.datacontract.org/2004/07/FlightProvider");

    using (var memoryStream = new MemoryStream())
    using (var streamWriter = new StreamWriter(memoryStream, Encoding.UTF8))
    {
      xmlSerializer.Serialize(streamWriter, envelope, xmlNamespaces);
      streamWriter.Flush();
      memoryStream.Position = 0;

      using (var streamReader = new StreamReader(memoryStream))
      {
        return streamReader.ReadToEnd();
      }
    }
  }

  public string ParseXmlToJson(string xmlResponse)
  {
    try
    {
      var xmlSerializer = new XmlSerializer(typeof(Envelope));

      using (var stringReader = new StringReader(xmlResponse))
      {
        var envelope = (Envelope)xmlSerializer.Deserialize(stringReader);
        return JsonConvert.SerializeObject(envelope, Formatting.Indented);
      }
    }
    catch (Exception ex)
    {
      Console.WriteLine($"Deserialization Error: {ex.Message}");
      return null;
    }
  }
}