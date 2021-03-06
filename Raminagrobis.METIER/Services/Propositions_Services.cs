using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raminagrobis.DAL.DAL;
using Raminagrobis.DAL.Depot;
using Raminagrobis.DTO.DTO;
using Raminagrobis.METIER.Metier;

namespace Raminagrobis.METIER.Services
{
    public class Propositions_Services
    {
        #region GetAll
        public List<Propositions_METIER> GetAll()
        {
            var result = new List<Propositions_METIER>();
            var depot = new PropositionsDepot_DAL();
            foreach (var item in depot.GetAll())
            {
                result.Add(new Propositions_METIER(item.ID, item.ID_ligne_global, item.ID_fournisseur, item.ID_produit, item.Prix, item.Gagne, item.Societe, item.Libelle_Produit, item.Quantite));
            }
            return result;
        }
        #endregion

        #region GetByID
        public Propositions_METIER GetByID(int id)
        {
            var depot = new PropositionsDepot_DAL();
            var input = depot.GetByID(id);
            return new Propositions_METIER(input.ID, input.ID_ligne_global, input.ID_fournisseur, input.ID_produit, input.Prix, input.Gagne, input.Societe, input.Libelle_Produit, input.Quantite);
        }
        #endregion

        #region GetByID_fournisseur
        public Propositions_METIER GetByID_fournisseur(int id_fournisseur)
        {
            var depot = new PropositionsDepot_DAL();
            var input = depot.GetByID_fournisseur(id_fournisseur);
            return new Propositions_METIER(input.ID, input.ID_ligne_global, input.ID_fournisseur, input.ID_produit, input.Prix, input.Gagne, input.Societe, input.Libelle_Produit, input.Quantite);
        }
        #endregion

        #region GetByID_ligne_global
        public Propositions_METIER GetByID_ligne_global(int id_ligne_global)
        {
            var depot = new PropositionsDepot_DAL();
            var input = depot.GetByID_fournisseur(id_ligne_global);
            return new Propositions_METIER(input.ID, input.ID_ligne_global, input.ID_fournisseur, input.ID_produit, input.Prix, input.Gagne, input.Societe, input.Libelle_Produit, input.Quantite);
        }
        #endregion

        #region Insert
        public void Insert(Propositions_DTO input)
        {
            var propositions = new Propositions_DAL(input.ID_ligne_global, input.ID_fournisseur, input.ID_produit, input.Prix, input.Gagne, input.Societe, input.Libelle_Produit, input.Quantite);
            var depot = new PropositionsDepot_DAL();
            depot.Insert(propositions);
        }
        #endregion

        #region Update
        public void Update(Propositions_DTO input)
        {
            var propositions = new Propositions_DAL(input.ID, input.ID_ligne_global, input.ID_fournisseur, input.ID_produit, input.Prix, input.Gagne, input.Societe, input.Libelle_Produit, input.Quantite);
            var depot = new PropositionsDepot_DAL();
            depot.Update(propositions);
        }
        #endregion

        #region Delete
        public void Delete(int id)
        {
            Propositions_DAL propositions;
            PropositionsDepot_DAL depot = new PropositionsDepot_DAL();
            propositions = depot.GetByID(id);
            depot.Delete(propositions);
        }
        #endregion
    }
}
