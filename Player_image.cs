using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace The_Lead_Guard.Models
{
    public class Player_image
    {
        [Key]
        public int Player_ID { get; set; }

        public string Player_ImageLocation { get; set; }
    }
}
