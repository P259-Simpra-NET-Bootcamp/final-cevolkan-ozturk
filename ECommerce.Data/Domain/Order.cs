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
    [Table("Order", Schema = "ECommerce")]
    public class Order : BaseModel
    {
        public int OrderId;
        public int UserId { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public decimal BasketAmount { get; set; }

        public decimal CouponAmount { get; set; }

        public string CouponCode { get; set; }

        public decimal PointAmount { get; set; }

        public int OrderStatus { get; set; }

        public List<OrderDetail> orderDetails { get; set; }
    }

    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.Property(x => x.Id).IsRequired(true).UseIdentityColumn();
            builder.Property(x => x.CreatedAt).IsRequired(false);
            builder.Property(x => x.CreatedBy).IsRequired(false).HasMaxLength(30);
            builder.Property(x => x.UpdatedAt).IsRequired(false);
            builder.Property(x => x.UpdatedBy).IsRequired(false).HasMaxLength(30);

            builder.Property(x => x.OrderId).IsRequired(true).HasMaxLength(9);
            builder.Property(x => x.UserId).IsRequired(true);
            builder.Property(x => x.Address).IsRequired(true).HasMaxLength(150);
        }
    }
}
