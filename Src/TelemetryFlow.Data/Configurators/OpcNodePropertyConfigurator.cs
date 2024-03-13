using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TelemetryFlow.Model;

namespace TelemetryFlow.Data.Configurators;

public class OpcNodePropertyConfigurator : IEntityTypeConfiguration<OpcNodeProperty>
{
    public void Configure(EntityTypeBuilder<OpcNodeProperty> builder)
    {
        builder.ToTable(nameof(OpcNodeProperty));
        builder.HasKey(x => x.Id);
        //builder.HasMany<OpcNode>(x => x.Nodes);
    }
}