using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raminagrobis.DTO.DTO
{
    public class Propositions_DTO
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
    }
}
