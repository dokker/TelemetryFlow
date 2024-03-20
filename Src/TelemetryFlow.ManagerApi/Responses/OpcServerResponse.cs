using System.ComponentModel.DataAnnotations;

namespace TelemetryFlow.ManagerApi.Responses;

public class OpcServerResponse
{
    [Required] public Guid Id { get; set; }
    [Required] public string Name { get; set; }
    [Required] public string Address { get; set; }
}