using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace The_Lead_Guard.Models
{
    public class Team
    {
        [Key]
        public int Team_ID { get; set; }
        public string Name { get; set; }
    }
}
