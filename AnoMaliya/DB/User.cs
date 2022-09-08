using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnoMaliya.DB
{
    internal class User
    {
        [Key]
        public int UserId { get; set; }
        public string UserName { get; set; }
        public int UserAge { get; set; }

        public string Coment;
        public string Gender { get; set; }
        public double UserNumber { get; set; }
    }
}
