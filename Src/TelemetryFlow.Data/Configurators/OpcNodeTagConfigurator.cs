using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TelemetryFlow.Model;

namespace TelemetryFlow.Data.Configurators;

public class OpcNodeTagConfigurator : IEntityTypeConfiguration<OpcNodeTag>
{
    public void Configure(EntityTypeBuilder<OpcNodeTag> builder)
    {
        builder.ToTable(nameof(OpcNodeTag));
        builder.HasKey(x => x.Id);
        //builder.HasMany<OpcNode>(x => x.Nodes);
    }
}