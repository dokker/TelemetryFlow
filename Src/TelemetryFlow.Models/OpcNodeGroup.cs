namespace TelemetryFlow.Model;

public class OpcNodeGroup
{
    public Guid Id { get; set; }
    public String Name { get; set; }
    public List<OpcNode> Nodes { get; set; } = [];
}