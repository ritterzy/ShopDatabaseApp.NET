using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Practise.DAL.Constants;
using Practise.DAL.Models;

namespace Practise.DAL.EntityTypeConfigurations
{
    public class CategoryEntityTypeConfiguration: IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> entityTypeBuilder)
        {
            entityTypeBuilder.ToTable("Category");

            entityTypeBuilder.HasKey(k => k.Id).HasName("PK_Category");

            entityTypeBuilder.Property(p => p.Id).HasColumnType(StringConstants.Int).UseMySqlIdentityColumn();
            entityTypeBuilder.Property(p => p.Name).HasColumnType(StringConstants.Varchar20).IsRequired();

            entityTypeBuilder.HasMany(k => k.Products).WithOne(p => p.Category).HasForeignKey(p => p.CategoryId);
        }
    }
}
