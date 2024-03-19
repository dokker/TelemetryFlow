using System.ComponentModel.DataAnnotations;

namespace TelemetryFlow.ManagerApi.Requests;

public class CreateOpcServerRequest
{
    [Required]
    public Guid Id { get; set; }
    [Required]
    public string Name { get; set; }
}