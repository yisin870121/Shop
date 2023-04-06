using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MCSDD12.Models
{
    public class Products
    {
        [Key]
        [DisplayName("商品編號")]
        [StringLength(6)]
        [RegularExpression("[A-F][0-9]{5}")]
        public string ProductID { get; set; }

        [DisplayName("商品名稱")]
        [StringLength(150, ErrorMessage = "商品名稱最多150個字")]
        [Required(ErrorMessage = "請填寫商品名稱")]
        public string ProductName { get; set; }

        [DisplayName("商品照片")]
        [Required(ErrorMessage = "請上傳商品照片")]
        public byte[] PhotoFile { get; set; }

        [DisplayName("照片類型")]
        [StringLength(10)]
        public string ImageMimeType { get; set; }

        [DisplayName("商品單價")]
        [Required(ErrorMessage = "請輸入商品單價")]
        [Range(0, short.MaxValue, ErrorMessage = "單價不可小於0")]
        [DisplayFormat(DataFormatString = "{0:C0}", ApplyFormatInEditMode = true)]  /*只有單純0代表原封不動，加:C代表貨幣，加0代表小數第0位*/
        public short UnitPrice { get; set; }

        [DisplayName("商品說明")]
        [Required(ErrorMessage = "請輸入商品說明")]
        [StringLength(1000, ErrorMessage = "商品介紹不得超過1000個字")]
        public string Description { get; set; }

        [DisplayName("庫存量")]
        [Required(ErrorMessage = "請輸入庫存量")]
        [Range(0, short.MaxValue, ErrorMessage = "庫存量不可小於0")]
        public short UnitsInStock { get; set; }

        [DisplayName("已下架")]
        [DefaultValue(false)]   //預設是上架所以是false，已下架才是true
        public bool Discontinued { get; set; }

        [DisplayName("建立日期")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime CreatedDate { get; set; }

    }
}