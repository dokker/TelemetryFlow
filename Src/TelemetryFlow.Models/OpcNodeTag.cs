namespace TelemetryFlow.Model;

public class OpcNodeTag
{
    public Guid Id { get; set; }
    public String Tag { get; set; }
    public List<OpcNode> Nodes { get; set; } = [];
}