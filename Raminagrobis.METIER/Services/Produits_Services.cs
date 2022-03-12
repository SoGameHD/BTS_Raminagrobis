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
    public class Produits_Services
    {
        #region GetAll
        public List<Produits_METIER> GetAll()
        {
            var result = new List<Produits_METIER>();
            var depot = new ProduitsDepot_DAL();
            foreach (var item in depot.GetAll())
            {
                result.Add(new Produits_METIER(item.ID, item.Reference, item.Libelle, item.Marque, item.Actif));
            }
            return result;
        }
        #endregion

        #region GetByID
        public Produits_METIER GetByID(int id)
        {
            var depot = new ProduitsDepot_DAL();
            var produits = depot.GetByID(id);
            return new Produits_METIER(produits.ID, produits.Reference, produits.Libelle, produits.Marque, produits.Actif);
        }
        #endregion

        #region GetByIDFournisseur
        public List<Produits_METIER> GetByIDFournisseur(int id_fournisseur)
        {
            var result = new List<Produits_METIER>();
            var depot = new ProduitsDepot_DAL();

            foreach (var produits in depot.GetByIDFournisseur(id_fournisseur))
            {
                Produits_METIER produit = new Produits_METIER(produits.ID, produits.Reference, produits.Libelle, produits.Marque, produits.Actif);
                result.Add(produit);
            }
            return result;
        }
        #endregion

        #region GetByReference
        public List<Produits_METIER> GetByReference(string reference)
        {
            var result = new List<Produits_METIER>();
            var depot = new ProduitsDepot_DAL();

            foreach (var produits in depot.GetByReference(reference))
            {
                Produits_METIER produit = new Produits_METIER(produits.ID, produits.Reference, produits.Libelle, produits.Marque, produits.Actif);
                result.Add(produit);
            }
            return result;
        }
        #endregion

        #region Insert
        public Produits_DTO Insert(Produits_DTO input)
        {
            var produits = new Produits_DAL(input.Reference, input.Libelle, input.Marque, input.Actif);
            var depot = new ProduitsDepot_DAL();
            input.ID = depot.Insert(produits).ID;

            return input;
        }
        #endregion

        #region Update
        public Produits_DTO Update(int id, Produits_DTO input)
        {
            var produits = new Produits_DAL(id, input.Reference, input.Libelle, input.Marque, input.Actif);
            var depot = new ProduitsDepot_DAL();
            depot.Update(produits);

            return input;
        }
        #endregion

        #region Delete
        public void Delete(int id)
        {
            Produits_DAL produits;
            ProduitsDepot_DAL depot = new ProduitsDepot_DAL();
            produits = depot.GetByID(id);
            depot.Delete(produits);
        }
        #endregion

        #region LiaisonProduitsFournisseurs
        public void LiaisonProduitsFournisseurs(Produits_DTO produit, int idFournisseur)
        {
            LiaisonDepot_DAL liaison = new LiaisonDepot_DAL();
            var associations = new Liaison_DAL((int)produit.ID, idFournisseur);
            liaison.Insert(associations);
        }
        #endregion
    }
}
