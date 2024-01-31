using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace efm_c_.Models
{
    public class Evenement
    {
        public int Id { get; set; }
        public string Titre { get; set; }
        public string Description { get; set; }
        public int IdClub { get; set; }
        public DateTime DateDebut { get; set; }
        public DateTime DateFin { get; set; }
        public string Status { get; set; }
        public double? Prix { get; set; }
        // Foreign Key relationship
        public Club Club { get; set; }
    }
}
