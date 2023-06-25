using ECommerce.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain
{
    [Table("OrderDetail", Schema = "ECommerce")]
    public class OrderDetail : BaseModel
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int ProductCount { get; set; }
        public decimal ProductAmount { get; set; }
        public decimal ProductTotalAmount { get; set; }
    }

    public class OrderDetailConfiguration : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.Property(x => x.Id).IsRequired(true).UseIdentityColumn();
            builder.Property(x => x.CreatedAt).IsRequired(false);
            builder.Property(x => x.CreatedBy).IsRequired(false).HasMaxLength(30);
            builder.Property(x => x.UpdatedAt).IsRequired(false);
            builder.Property(x => x.UpdatedBy).IsRequired(false).HasMaxLength(30);

            builder.Property(x => x.OrderId).IsRequired(true).HasMaxLength(9);
            builder.Property(x => x.ProductId).IsRequired(true);
            builder.Property(x => x.ProductCount).IsRequired(true).HasMaxLength(50);
            builder.Property(x => x.ProductTotalAmount).IsRequired(true);
        }
    }
}
