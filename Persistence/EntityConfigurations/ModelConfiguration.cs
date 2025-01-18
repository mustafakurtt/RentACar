using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class ModelConfiguration : IEntityTypeConfiguration<Model>
{
    public void Configure(EntityTypeBuilder<Model> builder)
    {
        builder.ToTable("Models").HasKey(b => b.Id);
        builder.Property(x => x.Name).HasColumnName("Name").IsRequired();
        builder.Property(x => x.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(x => x.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(x => x.DeletedDate).HasColumnName("DeletedDate");
        
        builder.Property(x => x.BrandId).HasColumnName("BrandId");
        builder.Property(x => x.FuelId).HasColumnName("FuelId");
        builder.Property(x => x.ColorId).HasColumnName("ColorId");
        builder.Property(x => x.TransmissionId).HasColumnName("TransmissionId");
        
        builder.Property(x => x.DailyPrice).HasColumnName("DailyPrice");
        builder.Property(x => x.ImageUrl).HasColumnName("ImageUrl");
        
        builder.HasIndex(indexExpression: b => b.Name, name: "UK_Models_Name").IsUnique();

        builder.HasOne(m => m.Color);
        builder.HasOne(m => m.Fuel);
        builder.HasOne(m => m.Transmission);
        builder.HasOne(m => m.Brand);

        builder.HasMany(m => m.Cars);



        builder.HasQueryFilter(b => !b.DeletedDate.HasValue);

    }
}