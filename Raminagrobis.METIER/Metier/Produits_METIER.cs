using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raminagrobis.DAL.DAL;
using Raminagrobis.DAL.Depot;

namespace Raminagrobis.METIER.Metier
{
    public class Produits_METIER
    {
        public string Reference { get; set; }
        public string Libelle { get; set; }
        public string Marque { get; set; }
        public bool Actif { get; set; }

        public int ID { get; set; }
        public Produits_METIER(string reference, string libelle, string marque, bool actif) => (Reference, Libelle, Marque, Actif) = (reference, libelle, marque, actif);
        public Produits_METIER(int id, string reference, string libelle, string marque, bool actif) => (ID, Reference, Libelle, Marque, Actif) = (id, reference, libelle, marque, actif);
    }
}