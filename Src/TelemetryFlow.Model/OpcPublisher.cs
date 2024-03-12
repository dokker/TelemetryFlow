namespace TelemetryFlow.Model;

public class OpcPublisher
{
    public Guid Id { get; set; }
    public String Name { get; set; }
    public String MethodTopics { get; set; }
    public Guid ServerId { get; set; }
    public OpcServer Server { get; set; }
}