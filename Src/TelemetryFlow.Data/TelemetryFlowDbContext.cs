using Microsoft.EntityFrameworkCore;
using TelemetryFlow.Data.Configurators;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using TelemetryFlow.Model;

namespace TelemetryFlow.Data;

public class TelemetryFlowDbContext : DbContext
{
    public DbSet<OpcNode> opcNodes { get; set; }
    public DbSet<OpcNodeGroup> OpcNodeGroups { get; set; }
    public DbSet<OpcNodeProperty> OpcNodeProperties { get; set; }
    public DbSet<OpcNodeTag> OpcNodeTags { get; set; }
    public DbSet<OpcPublisher> OpcPublishers { get; set; }
    public DbSet<OpcServer> OpcServers { get; set; }
    public DbSet<OpcServerEndpoint> OpcServerEndpoints { get; set; }

    // : calls base class constructor (only at ctor)
    public TelemetryFlowDbContext(DbContextOptions options) : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("opc");

        modelBuilder.ApplyConfiguration<OpcNode>(new OpcNodeConfigurator());
        modelBuilder.ApplyConfiguration<OpcNodeGroup>(new OpcNodeGroupConfigurator());
        modelBuilder.ApplyConfiguration<OpcNodeProperty>(new OpcNodePropertyConfigurator());
        modelBuilder.ApplyConfiguration<OpcNodeTag>(new OpcNodeTagConfigurator());
        modelBuilder.ApplyConfiguration<OpcPublisher>(new OpcPublisherConfigurator());
        modelBuilder.ApplyConfiguration<OpcServer>(new OpcServerConfigurator());
        modelBuilder.ApplyConfiguration<OpcServerEndpoint>(new OpcServerEndpointConfigurator());
        
        base.OnModelCreating(modelBuilder);
    }
}