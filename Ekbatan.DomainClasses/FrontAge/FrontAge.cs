using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Ekbatan.DomainClasses.FrontAge
{
    public class FrontAge
    {
        public FrontAge()
        {

        }
        [Key]
        public int FrontAge_ID { get; set; }

        [Display(Name = "نوع نما")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(100)]
        public string FrontAge_Desc { get; set; }

        public virtual List<Melk> Melks { get; set; }

    }
}
