using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace The_Lead_Guard.Models
{
    public class Images
    {
        [Key]
        public string Graphic_Name  { get; set; }
        public string File_Location { get; set; }
        public int Graphic_ID { get; set; }

    }
    
}
