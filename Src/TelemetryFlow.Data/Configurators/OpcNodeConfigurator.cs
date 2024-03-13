using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TelemetryFlow.Model;

namespace TelemetryFlow.Data.Configurators;

public class OpcNodeConfigurator : IEntityTypeConfiguration<OpcNode>
{
    public void Configure(EntityTypeBuilder<OpcNode> builder)
    {
        builder.ToTable(nameof(OpcNode));
        builder.HasKey(x => x.Id);
        // builder.HasOne<OpcServer>(x => x.Server);
        builder.HasMany<OpcNodeGroup>(x => x.Groups)
            .WithMany(x => x.Nodes);
        builder.HasMany<OpcNodeTag>(x => x.Tags)
            .WithMany(x => x.Nodes);
        builder.HasMany<OpcNodeProperty>(x => x.Properties)
            .WithMany(x => x.Nodes);
    }
}