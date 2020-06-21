using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Ekbatan.DomainClasses;
using Ekbatan.DomainClasses.MContract;

namespace Ekbatan.DomainClasses
{
    public class Melk
    {
        public Melk()
        {

        }
        [Key]
        public int Melk_ID { get; set; }

        // Foreign Key Table  Priject
        [Display(Name = "نام پروژه")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int Project_ID { get; set; }

        // Foreign Key Table  Melk Type
        [Display(Name ="نوع ملک")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int MelkType_ID { get; set; }

        [Display(Name = "آدرس ملک")]
        [DataType(DataType.MultilineText)]
        public string? Address { get; set; }

        [Display(Name = "منطقه شهرداری")]
        public int? ShPosition { get; set; }

        // Foreign Key Table  Melk Position

        [Display(Name = "موقعیت ملک")]
        public int? MelkPosition_ID { get; set; }


        [Display(Name = "پلاک اصلی")]
        public string? PAsli { get; set; }

        [Display(Name = "پلاک فرعی")]
        public string? PFarei { get; set; }

        [Display(Name = "مساحت عرصه")]
        public double? MArseh { get; set; }

        [Display(Name ="مساحت اعیان")]
        public double? MAyan { get; set; }

        [Display(Name ="کاربری ملک")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int? Karbari_ID { get; set; }

        [Display(Name = "تعداد طبقه")]
        public int? CFloor { get; set; }

        [Display(Name = "طبقه ")]
        public int? NFloor { get; set; }

        [Display(Name = "نوع نما")]
        public int? FrontAge_ID { get; set; }

        [Display(Name = "بالکن")]
        public bool Balkon { get; set; }

        [Display(Name = "انباری")]
        public bool Anbari { get; set; }         
        
        [Display(Name = "متراژ انباری")]
        public float? MAnbari { get; set; }
        
        [Display(Name = "پارکینگ")]
        public bool Parking { get; set; }
        
        [Display(Name = "آسانسور")]
        public bool Elevator { get; set; }

        //[Display(Name ="شماره قرارداد")]
        //public int? Contract_ID { get; set; }

        public virtual Project.Project Project { get; set; }

        public virtual Karbari.Karbari Karbari { get; set; }

        public virtual MelkPosition.MelkPosition MelkPosition { get; set; }

        public virtual MelkType.MelkType MelkType { get; set; }

        public virtual FrontAge.FrontAge FrontAge { get; set; }
        
        public virtual MContract.MContract MContract { get; set; }
        
    }
}
