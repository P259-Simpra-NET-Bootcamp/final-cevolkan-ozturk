using ECommerce.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain
{
    [Table("Product", Schema = "ECommerce")]
    public class Product : BaseModel
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public string Tag { get; set; }
        public int Stock { get; set; }

        public decimal Price { get; set; }

        public string Properties { get; set; }

        public string Description { get; set; }

        public int IsActive { get; set; }

        public decimal PercentageOfPoints { get; set; }

        public decimal MaxPointAmount { get; set; }

        public decimal PointBalance { get; set; }

        public ICollection<Order> Orders { get; set; }

    }
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(x => x.Id).IsRequired(true).UseIdentityColumn();
            builder.Property(x => x.CreatedAt).IsRequired(false);
            builder.Property(x => x.CreatedBy).IsRequired(false).HasMaxLength(30);
            builder.Property(x => x.UpdatedAt).IsRequired(false);
            builder.Property(x => x.UpdatedBy).IsRequired(false).HasMaxLength(30);

            builder.Property(x => x.Name).IsRequired(true).HasMaxLength(30);
            builder.Property(x => x.Url).IsRequired(true).HasMaxLength(100);
            builder.Property(x => x.Tag).IsRequired(true).HasMaxLength(100);
            
            builder.HasIndex(x => x.Name).IsUnique(true);
        }
    }
}
