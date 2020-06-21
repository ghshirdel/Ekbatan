using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Ekbatan.DomainClasses.Images
{
    public class ImageType
    {
        [Key]
        public int ImageType_ID { get; set; }

        [Display(Name = "توع تصویر")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200)]
        public string ImageType_desc { get; set; }

        public virtual List<Images> Images { get; set; }
    }
}
