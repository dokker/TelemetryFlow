using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TelemetryFlow.Model;

namespace TelemetryFlow.Data.Configurators;

public class OpcServerConfigurator : IEntityTypeConfiguration<OpcServer>
{
    public void Configure(EntityTypeBuilder<OpcServer> builder)
    {
        builder.ToTable(nameof(OpcPublisher));
        builder.HasKey(x => x.Id);
        builder.HasOne<OpcPublisher>(x => x.Publisher);
        builder.HasMany<OpcNode>(x => x.Nodes);
        builder.HasMany<OpcServerEndpoint>(x => x.Endpoints);
    }
}