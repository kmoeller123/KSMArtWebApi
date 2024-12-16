using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KSMArtWebApi.Models
{
    public partial class Genre
    {
        public int Id { get; set; }

        [Required(AllowEmptyStrings =false)]
        public string? Name { get; set; }
    }
}
