using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MCSDD12.Models
{
    public class Orders
    {
        [Key]
        [DisplayName("訂單編號")]
        [StringLength(12)]
        public string OrderID { get; set; }

        [DisplayName("訂單成立時間")]
        [DataType(DataType.DateTime)]
        [Required]
        public DateTime OrderDate { get; set; }

        [DisplayName("收貨人姓名")]
        [Required(ErrorMessage ="請填寫收貨人姓名")]
        [StringLength(40,ErrorMessage ="收貨人姓名最多40個字")]
        public string ShipName { get; set; }

        [DisplayName("收貨人地址")]
        [Required(ErrorMessage ="請填寫收貨人地址")]
        [StringLength(100,ErrorMessage = "收貨人地址最多100個字")]
        public string ShipAddress { get; set; }

        [DisplayName("出貨日")]
        [DataType(DataType.DateTime)]
        public Nullable<DateTime> ShippedDate { get; set; }

        //Forign Key
        public int ShipID { get; set; }
        public int MemberID { get; set; }
        public int EmployeeID { get; set; }
        public int PayTypeID { get; set; }

        //拉關聯
        public virtual Employees Employees { get; set; }
        public virtual Members Members { get; set; }
        public virtual Shippers Shippers { get; set; }
        public virtual PayTypes PayTypes { get; set; }
    }
}