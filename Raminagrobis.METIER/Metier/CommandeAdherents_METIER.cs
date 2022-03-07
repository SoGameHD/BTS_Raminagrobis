using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raminagrobis.DAL.DAL;
using Raminagrobis.DAL.Depot;

namespace Raminagrobis.METIER.Metier
{
    public class CommandeAdherents_METIER
    {
        public int ID_adherent { get; set; }
        public int ID_panier { get; set; }
        public int ID { get; set; }

        public CommandeAdherents_METIER(int id_adherent, int id_panier) => (ID_adherent, ID_panier) = (id_adherent, id_panier);
        public CommandeAdherents_METIER(int id, int id_adherent, int id_panier) => (ID, ID_adherent, ID_panier) = (id, id_adherent, id_panier);
    }
}