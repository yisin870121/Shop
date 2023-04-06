using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MCSDD12.Models
{
    public class OrderDetails
    {
        [Key]
        [DisplayName("訂單編號")]
        [Column(Order =1)]
        public string OrderID { get; set; }

        [Key]
        [DisplayName("商品編號")]
        [Column(Order = 2)]
        public string ProductID { get; set; }

        [DisplayName("商品售價")]
        [Required(ErrorMessage = "請填寫商品售價")]
        [Range(0,short.MaxValue,ErrorMessage ="商品售價不可小於0")]
        public short UnitPrice { get; set; }

        [DisplayName("數量")]
        [Required(ErrorMessage ="請填寫商品數量")]
        [Range(1,short.MaxValue,ErrorMessage ="商品數量不可小於1")]
        public short Quantity { get; set; }

        //拉關聯
        public virtual Orders Orders { get; set; }
        public virtual Products Products { get; set; }
    }
}