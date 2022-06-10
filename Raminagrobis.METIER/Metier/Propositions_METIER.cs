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
        public int Quantite { get; set; }
        public string Libelle_Produit { get; set; }
        public string Societe { get; set; }
        public Boolean Gagne { get; set; }
        public int Prix { get; set; }
        public int ID_ligne_global { get; set; }
        public int ID_fournisseur { get; set; }
        public int ID_produit { get; set; }
        public int ID { get; set; }

        public Propositions_METIER(int prix, int id_ligne_global, int id_fournisseur, int id_produit, bool gagne, string societe, string libelle_produit, int quantite) => (Prix, ID_ligne_global, ID_fournisseur, ID_produit, Gagne, Societe, Libelle_Produit, Quantite) = (prix, id_ligne_global, id_fournisseur, id_produit, gagne, societe, libelle_produit, quantite);
        public Propositions_METIER(int id, int prix, int id_ligne_global, int id_fournisseur, int id_produit, bool gagne, string societe, string libelle_produit, int quantite) => (ID, Prix, ID_ligne_global, ID_fournisseur, ID_produit, Gagne, Societe, Libelle_Produit, Quantite) = (id, prix, id_ligne_global, id_fournisseur, id_produit, gagne, societe, libelle_produit, quantite);
    }
}