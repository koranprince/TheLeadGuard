using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace The_Lead_Guard.Models
{
    public class Subscriber_Table
    {
        [Key]
        public int Subscriber_ID { get; set; }
        public int Login_Id { get; set; }
    }
}
