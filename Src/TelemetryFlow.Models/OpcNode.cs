namespace TelemetryFlow.Model;

public class OpcNode
{
    public Guid Id { get; set; }
    public String ExpandedNodeId { get; set; }
    public String Name { get; set; }
    public List<OpcNodeTag> Tags { get; set; } = [];
    public List<OpcNodeGroup> Groups { get; set; } = [];
    public List<OpcNodeProperty> Properties { get; set; } = [];
}