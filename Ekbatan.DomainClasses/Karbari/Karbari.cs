using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Ekbatan.DomainClasses.Karbari
{
    public class Karbari
    {
        public Karbari()
        {

        }
        [Key]
        public int Karbari_ID { get; set; }

        [Display(Name = "نوع کاربری")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(100)]
        public string Karbari_Desc { get; set; }

        public virtual List<Melk> Melks { get; set; }
    }
}
