using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raminagrobis.DAL.DAL;
using Raminagrobis.DAL.Depot;

namespace Raminagrobis.METIER.Metier
{
    public class LignesAdherents_METIER
    {
        public int Quantite { get; set; }
        public int ID_ligne_global { get; set; }
        public int ID_produit { get; set; }
        public int ID_adherent { get; set; }
        public int ID { get; set; }

        public LignesAdherents_METIER(int id_adherent, int id_produit, int id_ligne_global, int quantite) => (ID_adherent, ID_produit, ID_ligne_global, Quantite) = (id_adherent, id_produit, id_ligne_global, quantite);

        public LignesAdherents_METIER(int id, int id_adherent, int id_produit, int id_ligne_global, int quantite) => (ID, ID_adherent, ID_produit, ID_ligne_global, Quantite) = (id, id_adherent, id_produit, id_ligne_global, quantite);
    }
}