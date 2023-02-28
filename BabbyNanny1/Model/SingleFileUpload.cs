﻿using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace BabbyNanny.Model
{
    public class SingleFileUpload
    {
        [Required]
        [Display(Name = "Picture")]
        public IFormFile FormFile { get; set; }
    }
}
