using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TelemetryFlow.Model;

namespace TelemetryFlow.Data.Configurators;

public class OpcServerConfigurator : IEntityTypeConfiguration<OpcServer>
{
    public void Configure(EntityTypeBuilder<OpcServer> builder)
    {
        builder.ToTable(nameof(OpcServer));
        builder.HasKey(x => x.Id);
        builder.HasOne<OpcPublisher>(x => x.Publisher)
            .WithOne(x => x.Server)
            .HasForeignKey<OpcPublisher>(x => x.ServerId)
            .IsRequired();
        builder.HasMany<OpcNode>(x => x.Nodes)
            .WithOne(x => x.Server)
            .HasForeignKey(x => x.ServerId)
            .IsRequired();
        builder.HasMany<OpcServerEndpoint>(x => x.Endpoints)
            .WithOne(x => x.Server)
            .HasForeignKey(x => x.ServerId)
            .IsRequired();
    }
}