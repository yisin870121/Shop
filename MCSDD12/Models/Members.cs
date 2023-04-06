using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace MCSDD12.Models
{
    public class Members
    {
        [Key]
        [DisplayName("會員編號")]
        public int MemberID { get; set; }

        [DisplayName("姓名")]
        [StringLength(40, ErrorMessage = "姓名不可超過40個字")]
        [Required(ErrorMessage = "請填寫姓名")]
        public string MemberName { get; set; }

        [DisplayName("照片")]
        public string MemberPhotoFile { get; set; }

        [DisplayName("生日")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.DateTime)]
        public DateTime MemberBirthday { get; set; }

        [DisplayName("建立日期")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.DateTime)]
        [Required]
        public DateTime CreatedDate { get; set; }

        [DisplayName("帳號")]
        [Required(ErrorMessage = "請填寫帳號")]
        [StringLength(20, ErrorMessage = "帳號不可超過20個字")]
        [RegularExpression("[A-Za-z][A-Za-z0-9]{4,19}")]
        public string Account { get; set; }


        //field
        string password;

        [DisplayName("密碼")]
        [Required(ErrorMessage = "請填寫密碼")]
        [DataType(DataType.Password)]
        //[MinLength(8, ErrorMessage = "密碼最少8碼")]
        //[MaxLength(20, ErrorMessage = "密碼最多20碼")]
        //[StringLength(20)]

        //商業邏輯寫在Models裡
        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                
                //我們要先把Password收到的value做雜湊,再把值給password
                password = BR.getHashPassword(value);
            }

        }

    }
}