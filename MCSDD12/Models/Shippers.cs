using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MCSDD12.Models
{
    public class Shippers
    {
        [Key]
        public int ShipID { get; set; }

        [DisplayName("運送方式")]
        [StringLength(20, ErrorMessage = "運送方式最多20個字")]
        [Required(ErrorMessage = "請填寫運送方式")]
        public string ShipVia { get; set; }
    }
}