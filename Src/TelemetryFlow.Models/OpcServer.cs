namespace TelemetryFlow.Model;

public class OpcServer
{
    public Guid Id { get; set; }
    public String Name { get; set; }
    public String Address { get; set; }
    public List<OpcNode> Nodes { get; set; } = [];
    public List<OpcServerEndpoint> Endpoints { get; set; } = [];
    public OpcPublisher? Publisher { get; set; }
}