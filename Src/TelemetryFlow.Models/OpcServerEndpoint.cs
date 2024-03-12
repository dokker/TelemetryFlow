namespace TelemetryFlow.Model;

public class OpcServerEndpoint
{
    public Guid Id { get; set; }
    public String Name { get; set; }
    public String SecurityMode { get; set; }
    public String SecurityPolicy { get; set; }
    public String AuthenticationMode { get; set; }
    public String Username { get; set; }
    public String Password { get; set; }
    public Guid ServerId { get; set; }
    public OpcServer Server { get; set; }
}