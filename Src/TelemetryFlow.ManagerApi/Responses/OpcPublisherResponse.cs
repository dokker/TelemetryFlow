using System.ComponentModel.DataAnnotations;

namespace TelemetryFlow.ManagerApi.Responses;

public class OpcPublisherResponse
{
    [Required] public Guid Id { get; set; }
    [Required] public string Name { get; set; }
    [Required] public string MethodTopics { get; set; }
    [Required] public Guid ServerId { get; set; }
}