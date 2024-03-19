using System.ComponentModel.DataAnnotations;

namespace TelemetryFlow.ManagerApi.Responses;

public class OpcServerResponse
{
    [Required]
    public Guid Id { get; set; }

}