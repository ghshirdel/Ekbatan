using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Emit;
using System.Text;

namespace Ekbatan.DomainClasses.Images
{
    public class Images
    {
        [Key]
        public int Image_ID { get; set; }

        [Display(Name = "توع تصویر")]
        public int ImageType_ID { get; set; }

        public int Object_ID { get; set; }

        public string ImageName { get; set; }
  
        [Display(Name = "توضیحات ")]
        public string Image_Desc { get; set; }

        public virtual ImageType ImageType { get; set; }
    }
}
