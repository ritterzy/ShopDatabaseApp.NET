using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Practise.DAL.Constants;
using Practise.DAL.Models;

namespace Practise.DAL.EntityTypeConfigurations
{
    public class OrderListEntityTypeConfiguration: IEntityTypeConfiguration<OrderList>
    {
        public void Configure(EntityTypeBuilder<OrderList> entityTypeBuilder)
        {
            entityTypeBuilder.ToTable("OrderList");

            entityTypeBuilder.HasKey(k => k.Id).HasName("PK_OrderList");

            entityTypeBuilder.Property(p => p.Id).HasColumnType(StringConstants.Int).UseMySqlIdentityColumn();
            entityTypeBuilder.Property(p => p.TotalPrice).HasColumnType(StringConstants.Int).IsRequired();

        }
    }
}
