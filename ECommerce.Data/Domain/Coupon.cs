using ECommerce.Base;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Data
{
    [Table("Coupon", Schema ="ECommerce")]
    public class Coupon : BaseModel
    {
        public string CouponCode { get; set; }

        public decimal CouponAmount { get; set; }

        public int UserId { get; set; }

        public DateTime? CouponExpireDate { get; set; }

        public int CouponRedemptionStatus { get; set; }

    }

    public class CouponConfiguration : IEntityTypeConfiguration<Coupon>
    {
        public void Configure(EntityTypeBuilder<Coupon> builder)
        {
            builder.Property(x => x.Id).IsRequired(true).UseIdentityColumn();
            builder.Property(x => x.CreatedAt).IsRequired(false);
            builder.Property(x => x.CreatedBy).IsRequired(false).HasMaxLength(30);
            builder.Property(x => x.UpdatedAt).IsRequired(false);
            builder.Property(x => x.UpdatedBy).IsRequired(false).HasMaxLength(30);

            builder.Property(x => x.CouponCode).IsRequired(true).HasMaxLength(30);
            builder.Property(x => x.CouponAmount).IsRequired(true);
            builder.Property(x => x.UserId).IsRequired(true);
            builder.Property(x => x.CouponExpireDate).IsRequired(true);
            builder.Property(x => x.CouponRedemptionStatus).IsRequired(true);

            builder.HasIndex(x => x.CouponCode).IsUnique(true);
        }
    }
}
