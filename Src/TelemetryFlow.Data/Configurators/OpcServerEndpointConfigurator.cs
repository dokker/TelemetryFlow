using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TelemetryFlow.Model;

namespace TelemetryFlow.Data.Configurators;

public class OpcServerEndpointConfigurator : IEntityTypeConfiguration<OpcServerEndpoint>
{
    public void Configure(EntityTypeBuilder<OpcServerEndpoint> builder)
    {
        builder.ToTable(nameof(OpcServerEndpoint));
        builder.HasKey(x => x.Id);
        // builder.HasOne<OpcServer>(x => x.Server);
    }
}