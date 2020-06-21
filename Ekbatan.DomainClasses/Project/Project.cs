using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Ekbatan.DomainClasses;
using System.Globalization;

namespace Ekbatan.DomainClasses.Project
{
    public class Project
    {

        public Project()
        {

        }
        [Key]
        public int Project_ID { get; set; }

        [Display(Name ="نام پروژه")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(100)]
        public string Project_name { get; set; }

        [Display(Name = "تاریخ اخذ پروانه ساخت ")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public System.DateTime? Parv_Date { get; set; }

        [Display(Name = "تاریخ شروع پروژه ")]
        [DisplayFormat(DataFormatString ="{0:yyyy/MM/dd}",ApplyFormatInEditMode =true)]
        [DataType(DataType.Date)]
        public System.DateTime? PStart_Date { get; set; }

        [Display(Name = "تاریخ پایان پروژه ")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public System.DateTime? PEnd_Date { get; set; }

        [Display(Name = "تاریخ اخذ پایان کار ")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public System.DateTime ? Payan_Date { get; set; }

        public virtual List<Melk> Melks { get; set; }
    }
}
