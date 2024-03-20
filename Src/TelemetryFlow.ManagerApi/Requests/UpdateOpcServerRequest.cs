using System.ComponentModel.DataAnnotations;

namespace TelemetryFlow.ManagerApi.Requests;

public class UpdateOpcServerRequest
{
    [Required]
    public Guid Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string Address { get; set; }
}