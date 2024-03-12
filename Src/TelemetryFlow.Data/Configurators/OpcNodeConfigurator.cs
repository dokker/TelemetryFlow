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
        builder.HasMany<OpcNodeGroup>(x => x.Groups);
        builder.HasMany<OpcNodeTag>(x => x.Tags);
        builder.HasMany<OpcNodeProperty>(x => x.Properties);
    }
}