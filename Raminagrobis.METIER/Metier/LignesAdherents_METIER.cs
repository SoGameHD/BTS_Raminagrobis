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
        public int ID_ligne_global { get; set; }
        public int Quantite { get; set; }
        public int ID_produit { get; set; }
        public int ID_commande { get; set; }

        public LignesAdherents_METIER(int id_ligne_global, int quantite) => (ID_ligne_global, Quantite) = (id_ligne_global, quantite);

        public LignesAdherents_METIER(int id_produit, int id_commande, int id_ligne_global, int quantite) => (ID_produit, ID_commande, ID_ligne_global, Quantite) = (id_produit, id_commande, id_ligne_global, quantite);
    }
}