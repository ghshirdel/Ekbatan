using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;
using System.Text;

namespace Ekbatan.DomainClasses.MContract
{

    public class SubContract
    {
        public SubContract()
        {

        }
        [Key]
        public int SubContract_ID { get; set; }

        [Display(Name ="ملک")]   
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int Melk_ID { get; set; }

        [Display(Name = "مشخصات خریدار")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int Customer_ID { get; set; }

        [Display(Name = "میزان سهم خریدار")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public float Sahm { get; set; }

        public virtual  MContract MContract { get; set; }
        
    }
}
