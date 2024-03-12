using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TelemetryFlow.Model;

namespace TelemetryFlow.Data.Configurators;

public class OpcNodeGroupConfigurator : IEntityTypeConfiguration<OpcNodeGroup>
{
    public void Configure(EntityTypeBuilder<OpcNodeGroup> builder)
    {
        builder.ToTable(nameof(OpcNodeGroup));
        builder.HasKey(x => x.Id);
        builder.HasMany<OpcNode>(x => x.Nodes);
    }
}