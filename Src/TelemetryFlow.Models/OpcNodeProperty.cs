namespace TelemetryFlow.Model;

public class OpcNodeProperty
{
    public Guid Id { get; set; }
    public String Name { get; set; }
    public String Value { get; set; }
    public List<OpcNode> Nodes { get; set; } = [];
}