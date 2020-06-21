using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Ekbatan.DomainClasses.MelkType
{
    public class MelkType
    {
        public MelkType()
        {

        }
        [Key]
        public int MelkType_ID { get; set; }

        [Display(Name ="نوع ملک")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(100)]
        public string TypeMelk_Desc { get; set; }

        public virtual List<Melk> Melks { get; set; }

    }
}
