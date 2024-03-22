using System.ComponentModel.DataAnnotations;

namespace TelemetryFlow.ManagerApi.Requests;

public class CreateOpcServerEndpointRequest
{
    [Required] public string Name { get; set; }
    [Required] public string SecurityMode { get; set; }
    [Required] public string SecurityPolicy { get; set; }
    [Required] public string AuthenticationMode { get; set; }
    [Required] public string Username { get; set; }
    [Required] public string Password { get; set; }
    [Required] public Guid ServerId { get; set; }
}
