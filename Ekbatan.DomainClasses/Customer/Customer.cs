using Ekbatan.DomainClasses.MContract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Text;

namespace Ekbatan.DomainClasses.Customer
{
   public class Customer
    {
        public Customer()
        {

        }
        [Key]
        public int Customer_ID { get; set; }

        [Display(Name ="نام")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(100)]
        public string CName { get; set; }

        [Display(Name = "نام خانوادگی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(150)]
        public string CFamily { get; set; }

        [Display(Name = "کد ملی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(10)]
        public string? MelliCode { get; set; }

        [Display(Name = "شماره شناسنامه")]
        public int? SHNo { get; set; }

        [Display(Name = "شماره ثابت")]
        [DataType(DataType.PhoneNumber)]
        [MaxLength(100)]
        public string? Phone { get; set; }

        [Display(Name = "شمارهمراه")]
        [DataType(DataType.PhoneNumber)]
        [MaxLength(100)]
        public string? MobilePhone { get; set; }

        [Display(Name = "ادرس ایمیل")]
        [DataType(DataType.EmailAddress)]
        [MaxLength(100)]
        public string? Email { get; set; }

        [Display(Name = "آدرس ")]
        [MaxLength(100)]
        [DataType(DataType.MultilineText)]
        public string? Address { get; set; }

    }
}
