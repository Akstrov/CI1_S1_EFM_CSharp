using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace efm_c_.Models
{
    public class Membre
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public DateTime DateInscription { get; set; }
        public string Role { get; set; }
    }

}
