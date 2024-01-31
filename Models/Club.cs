using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace efm_c_.Models
{
    public class Club
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public int? IdGerant { get; set; }
        public DateTime DateCreation { get; set; }
        // Foreign Key relationship
        public Membre Gerant { get; set; }
    }

 }
