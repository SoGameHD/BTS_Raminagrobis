using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Raminagrobis.DTO.DTO;
using Raminagrobis.DAL.Depot;
using Raminagrobis.METIER.Metier;
using Raminagrobis.DAL.DAL;

namespace Raminagrobis.METIER.Services
{
    public class Fournisseurs_Services
    {
        private FournisseursDepot_DAL depot = new FournisseursDepot_DAL();

        #region GetAll
        public List<Fournisseurs_METIER> GetAll()
        {
            var result = new List<Fournisseurs_METIER>();
            var depot = new FournisseursDepot_DAL();
            foreach (var item in depot.GetAll())
            {
                result.Add(new Fournisseurs_METIER(item.ID, item.Societe, item.Civilite, item.Nom, item.Prenom, item.Email, item.Adresse, item.Actif));
            }
            return result;
        }
        #endregion

        #region GetByID
        public Fournisseurs_METIER GetByID(int id)
        {
            var depot = new FournisseursDepot_DAL();
            var fournisseurs = depot.GetByID(id);
            return new Fournisseurs_METIER(fournisseurs.ID, fournisseurs.Societe, fournisseurs.Civilite, fournisseurs.Nom, fournisseurs.Prenom, fournisseurs.Email, fournisseurs.Adresse, fournisseurs.Actif);
        }
        #endregion

        #region Insert
        public void Insert(Fournisseur_DTO input)
        {
            var fournisseurs = new Fournisseurs_DAL(input.Societe, input.Civilite, input.Nom, input.Prenom, input.Email, input.Adresse, input.Actif);
            var depot = new FournisseursDepot_DAL();
            depot.Insert(fournisseurs);
        }
        #endregion

        #region Update
        public void Update(int id, Fournisseur_DTO input)
        {
            var fournisseurs = new Fournisseurs_DAL(id, input.Societe, input.Civilite, input.Nom, input.Prenom, input.Email, input.Adresse, input.Actif);
            var depot = new FournisseursDepot_DAL();
            depot.Update(fournisseurs);
        }
        #endregion

        #region UpdateActif
        public Fournisseur_DTO UpdateActif(int id, Fournisseur_DTO input)
        {
            var fournisseurs = new Fournisseurs_DAL(id, input.Societe, input.Civilite, input.Nom, input.Prenom, input.Email, input.Adresse, input.Actif);
            var depot = new FournisseursDepot_DAL();
            depot.UpdateActif(fournisseurs);

            return input;
        }
        #endregion

        #region Delete
        public void Delete(int id)
        {
            Fournisseurs_DAL fournisseurs;
            FournisseursDepot_DAL depot = new FournisseursDepot_DAL();
            fournisseurs = depot.GetByID(id);
            depot.Delete(fournisseurs);
        }
        #endregion

        #region GetProduitsByCsv
        private List<Produits_METIER> GetProduitsByCsv(int id, IEnumerable<String> csv_file)
        {
            List<Produits_METIER> listproduit = new List<Produits_METIER>();

            for (int i = 0; i < csv_file.Count(); i++)
            {
                var liste = csv_file.ElementAt(i).Split(';');
                string reference = liste[0];
                string libelle = liste[1];
                string marque = liste[2];

                Produits_METIER produit = new Produits_METIER(reference, libelle, marque, true);
                listproduit.Add(produit);
            }

            return listproduit;
        }
        #endregion

        #region GetListProduitsByFournisseur
        public void GetListProduitsByFournisseur(int id, IEnumerable<String> csv_file)
        {
            Produits_Services produits_services = new Produits_Services();
            Liaison_Services liaison_services = new Liaison_Services();

            List<Produits_METIER> listProduitBDD = produits_services.GetByIDFournisseur(id);

            List<Produits_METIER> listProduitCSV = GetProduitsByCsv(id, csv_file);

            List<Produits_METIER> produitToAdd = new List<Produits_METIER>();
            List<Produits_METIER> produitToUnable = new List<Produits_METIER>();

            foreach (var csvproduit in listProduitCSV)
            {
                Produits_METIER matchproduits = null;
                if (listProduitBDD.Count == 0)
                {
                    produitToAdd.Add(csvproduit);
                }
                foreach (var produitsBDD in listProduitBDD)
                {
                    if (produitsBDD.Reference.Equals(csvproduit.Reference))
                    {
                        matchproduits = produitsBDD;
                        break;
                    }
                    produitToAdd.Add(csvproduit);
                }
            }
            // Liste de produit à ajouter effectuer

            foreach (var produitsBDD in listProduitBDD)
            {
                Produits_METIER matchproduits = null;
                foreach (var csvproduit in listProduitCSV)
                {
                    if (produitsBDD.Reference.Equals(csvproduit.Reference))
                    {
                        matchproduits = produitsBDD;
                        break;
                    }
                    produitToUnable.Add(produitsBDD);
                }
            }
            // Liste de produits à désactiver effectuer

            foreach (var produit in produitToAdd)
            {
                Produits_DTO produit_DTO = new Produits_DTO();
                produit_DTO.Reference = produit.Reference;
                produit_DTO.Libelle = produit.Libelle;
                produit_DTO.Marque = produit.Marque;
                produit_DTO.Actif = produit.Actif;

                produits_services.Insert(produit_DTO);
            }
            foreach (var produit in produitToUnable)
            {
                Produits_DTO produit_DTO = new Produits_DTO();
                produit_DTO.Reference = produit.Reference;
                produit_DTO.Libelle = produit.Libelle;
                produit_DTO.Marque = produit.Marque;
                produit_DTO.Actif = produit.Actif;

                produits_services.UpdateActif(produit.ID, produit_DTO);
                liaison_services.Delete(produit.ID, id);
            }
            Console.WriteLine(csv_file);
        }
        #endregion
    }
}
