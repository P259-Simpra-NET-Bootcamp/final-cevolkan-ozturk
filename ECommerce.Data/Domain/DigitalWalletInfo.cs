using ECommerce.Base;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Data
{
    [Table("Category", Schema ="ECommerce")]
    public class DigitalWalletInfo : BaseModel
    {
        public int UserId { get; set; }

        public decimal DigitalWalletBalance { get; set; }

    }

    public class DigitalWalletInfoConfiguration : IEntityTypeConfiguration<DigitalWalletInfo>
    {
        public void Configure(EntityTypeBuilder<DigitalWalletInfo> builder)
        {
            builder.Property(x => x.Id).IsRequired(true).UseIdentityColumn();
            builder.Property(x => x.CreatedAt).IsRequired(false);
            builder.Property(x => x.CreatedBy).IsRequired(false).HasMaxLength(30);
            builder.Property(x => x.UpdatedAt).IsRequired(false);
            builder.Property(x => x.UpdatedBy).IsRequired(false).HasMaxLength(30);

            builder.Property(x => x.UserId).IsRequired(true);
           
        }
    }
}
