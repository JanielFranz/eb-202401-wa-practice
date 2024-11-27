using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.EntityFrameworkCore;
using si730ebu2019126668.API.Inventory.Domain.Model.Aggregates;
using si730ebu2019126668.API.Observability.Domain.Model.Aggregates;
using si730ebu2019126668.API.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;

namespace si730ebu2019126668.API.Shared.Infrastructure.Persistence.EFC.Configuration;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        builder.AddCreatedUpdatedInterceptor();
        base.OnConfiguring(builder);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        //Inventory BC

        builder.Entity<Thing>().HasKey(t => t.Id);
        builder.Entity<Thing>().Property(t => t.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Thing>().Property(t => t.MinimumHumidityThreshold).IsRequired();
        builder.Entity<Thing>().Property(t => t.MaximumTemperatureThreshold).IsRequired();
        builder.Entity<Thing>().Property(t => t.OperationMode).IsRequired();
        builder.Entity<Thing>().OwnsOne(t => t.SerialNumber, sn =>
        {
            sn.WithOwner().HasForeignKey("Id");
            sn.Property(s => s.Identifier).HasColumnName("SerialNumber");
        });
        
        //Observability BC
        builder.Entity<ThingState>().HasKey(ts => ts.Id);
        builder.Entity<ThingState>().Property(ts => ts.Id).IsRequired().ValueGeneratedOnAdd();

        builder.Entity<ThingState>().OwnsOne(ts => ts.ThingSerialNumber, sn =>
        {
            sn.WithOwner().HasForeignKey("Id");
            sn.Property(tsn => tsn.SerialNumber).HasColumnName("ThingSerialNumber");
        });
        
        builder.Entity<ThingState>().Property(ts => ts.CurrentTemperature).IsRequired();
        builder.Entity<ThingState>().Property(ts => ts.CurrentHumidity).IsRequired();
        builder.Entity<ThingState>().Property(ts => ts.CollectedAt).IsRequired();


        builder.UseSnakeCaseNamingConvention();
    }
}