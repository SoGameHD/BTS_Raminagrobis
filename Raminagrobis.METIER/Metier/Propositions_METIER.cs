using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raminagrobis.DAL.DAL;
using Raminagrobis.DAL.Depot;

namespace Raminagrobis.METIER.Metier
{
    public class Propositions_METIER
    {
        public int Prix { get; set; }
        public int ID_ligne_global { get; set; }
        public int ID_fournisseur { get; set; }
        public int ID_produit { get; set; }
        public int ID { get; set; }

        public Propositions_METIER(int prix, int id_ligne_global, int id_fournisseur, int id_produit) => (Prix, ID_ligne_global, ID_fournisseur, ID_produit) = (prix, id_ligne_global, id_fournisseur, id_produit);
        public Propositions_METIER(int id, int prix, int id_ligne_global, int id_fournisseur, int id_produit) => (ID, Prix, ID_ligne_global, ID_fournisseur, ID_produit) = (id, prix, id_ligne_global, id_fournisseur, id_produit);
    }
}