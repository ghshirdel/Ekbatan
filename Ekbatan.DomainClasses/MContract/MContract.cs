using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Ekbatan.DomainClasses.MContract
{
    public class MContract
    {
        public MContract()
        {

        }
        [Key]
        public int Contract_ID { get; set; }

        [Display(Name ="شماره قرارداد")]
        [MaxLength(200)]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Contract_No { get; set; }

        [Display(Name = "ناریخ قرارداد")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime Contract_Date { get; set; }

        [Display(Name = "ملک")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int Mel_ID { get; set; }

        public virtual List<SubContract> SubContracts { get; set; }

       public virtual List<Melk> Melks { get; set; }
    }
}
