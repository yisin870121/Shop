using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.SessionState;

namespace MCSDD12.Models
{
    public class Employees
    {
        [Key]
        public int EmployeeID { get; set; }

        [DisplayName("員工姓名")]
        [StringLength(40,ErrorMessage = "員工姓名不可超過40個字")]
        [Required(ErrorMessage ="請填寫員工姓名")]
        public string EmployeeName { get; set; }

        [DisplayName("建立日期")]                            //編輯模式下也會伴隨屬性
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd hh:mm}", ApplyFormatInEditMode =true)]
        [DataType(DataType.DateTime)]
        [Required]
        public DateTime CreatedDate { get; set; }

        [DisplayName("帳號")]
        [Required(ErrorMessage = "請填寫帳號")]
        [StringLength(20, ErrorMessage = "帳號不可超過20個字")]  //[EmailAddress]
        [RegularExpression("[A-Za-z]{1}[A-Za-z0-9]{4,19}")]   //,5:最多五次，5,:最少五次，5,20:5到20次
        public string Account { get; set; }


        //field
        string password;   //欄位

        [DisplayName("密碼")]
        [Required(ErrorMessage = "請填寫密碼")]
        [DataType(DataType.Password)]
        //[MinLength(8,ErrorMessage ="密碼最少8碼")]
        //[MaxLength(20, ErrorMessage = "密碼最多20碼")]
        //[StringLength(20)]
        public string Password //屬性
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