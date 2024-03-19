using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TelemetryFlow.Model;

namespace TelemetryFlow.Data.Configurators;

public class OpcPublisherConfigurator : IEntityTypeConfiguration<OpcPublisher>
{
    public void Configure(EntityTypeBuilder<OpcPublisher> builder)
    {
        builder.ToTable(nameof(OpcPublisher));
        builder.HasKey(x => x.Id);
        // builder.HasOne<OpcServer>(x => x.Server);
    }
}