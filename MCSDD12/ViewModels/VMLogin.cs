﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace MCSDD12.ViewModels
{
    public class VMLogin
    {
        [DisplayName("帳號")]
        [Required(ErrorMessage = "請填寫帳號")]
        [StringLength(20, ErrorMessage = "帳號不可超過20個字")]  
        [RegularExpression("[A-Za-z]{1}[A-Za-z0-9]{4,19}")] 
        public string Account { get; set; }



        [DisplayName("密碼")]
        [Required(ErrorMessage = "請填寫密碼")]
        [DataType(DataType.Password)]
        [MinLength(8,ErrorMessage ="密碼最少8碼")]
        [MaxLength(20,ErrorMessage ="密碼最多20碼")]
        public string Password { get; set; }
    }
}