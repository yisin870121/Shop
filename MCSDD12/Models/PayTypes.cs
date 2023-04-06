using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MCSDD12.Models
{
    public class PayTypes
    {
        [Key]
        public int PayTypeID { get; set; }

        [DisplayName("付款方式")]
        [StringLength(10, ErrorMessage = "付款方式最多10個字")]
        [Required(ErrorMessage = "請填寫付款方式")]
        public string PayTypeName { get; set; }
    }
}