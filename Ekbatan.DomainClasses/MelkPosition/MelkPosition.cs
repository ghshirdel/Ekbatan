using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Ekbatan.DomainClasses.MelkPosition
{
    public class MelkPosition
    {
        public MelkPosition()
        {

        }

        [Key]
        public int MelkPosition_ID { get; set; }

        [Display(Name ="موقعیت ملک")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(100)]
        public string MelkPosition_Desc { get; set; }

        public virtual List<Melk> Melks { get; set; }

       
    }
}
