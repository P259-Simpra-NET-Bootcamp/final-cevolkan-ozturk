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
    [Table("User", Schema = "ECommerce")]
    public class User : BaseModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public string Password { get; set; }
        public int Status { get; set; }
        public DateTime LastActivity { get; set; }
        public int PasswordRetryCount { get; set; }
        
        public decimal PointBalance { get; set; }
    }

    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(x => x.Id).IsRequired(true).UseIdentityColumn();
            builder.Property(x => x.CreatedAt).IsRequired(false);
            builder.Property(x => x.CreatedBy).IsRequired(false).HasMaxLength(30);
            builder.Property(x => x.UpdatedAt).IsRequired(false);
            builder.Property(x => x.UpdatedBy).IsRequired(false).HasMaxLength(30);

            builder.Property(x => x.UserName).IsRequired(true).HasMaxLength(30);
            builder.Property(x => x.Email).IsRequired(true).HasMaxLength(30);
            builder.Property(x => x.Password).IsRequired(true).HasMaxLength(100);
            builder.Property(x => x.Name).IsRequired(true).HasMaxLength(50);
            builder.Property(x => x.Surname).IsRequired(true).HasMaxLength(50);
            builder.Property(x => x.Role).IsRequired(true).HasMaxLength(10);

            builder.Property(x => x.LastActivity).IsRequired(true);
            builder.Property(x => x.PasswordRetryCount).IsRequired(true);
            builder.Property(x => x.Status).IsRequired(true);

            builder.HasIndex(x => x.UserName).IsUnique(true);
        }
    }
}
