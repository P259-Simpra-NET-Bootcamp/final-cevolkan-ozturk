using ECommerce.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain
{
    [Table("ProductCategoryMap", Schema = "ECommerce")]
    public class ProductCategoryMap : BaseModel
    {
        public int CategoryId { get; set; }

        public int ProductId { get; set; }

    }
}
