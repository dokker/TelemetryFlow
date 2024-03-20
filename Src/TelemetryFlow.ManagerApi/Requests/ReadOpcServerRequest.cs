using System.ComponentModel.DataAnnotations;

namespace TelemetryFlow.ManagerApi.Requests;

public class ReadOpcServerRequest
{
    [Required]
    public Guid Id { get; set; }
}