using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Practise.DAL.Constants;
using Practise.DAL.Models;

namespace Practise.DAL.EntityTypeConfigurations
{
    public class ProductEntityTypeConfiguration: IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> entityTypeBuilder)
        {
            entityTypeBuilder.ToTable("Product");

            entityTypeBuilder.HasKey(k => k.Id).HasName("PK_Product");

            entityTypeBuilder.Property(p => p.Id).HasColumnType(StringConstants.Int).UseMySqlIdentityColumn();
            entityTypeBuilder.Property(p => p.Name).HasColumnType(StringConstants.Varchar20).IsRequired();
            entityTypeBuilder.Property(p => p.Price).HasColumnType(StringConstants.Int).IsRequired();

            entityTypeBuilder.HasOne(k => k.Category).WithMany(p => p.Products).HasForeignKey(p => p.CategoryId);
        }
    }
}
