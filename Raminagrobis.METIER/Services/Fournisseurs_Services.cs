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
            var fournisseurs = depot.GetByID(id); // Récupère l'id du fournisseur à supprimer
            return new Fournisseurs_METIER(fournisseurs.ID, fournisseurs.Societe, fournisseurs.Civilite, fournisseurs.Nom, fournisseurs.Prenom, fournisseurs.Email, fournisseurs.Adresse, fournisseurs.Actif);
        }
        #endregion

        #region Insert
        public void Insert(Fournisseur_DTO input)
        {
            var fournisseurs = new Fournisseurs_DAL(input.Societe, input.Civilite, input.Nom, input.Prenom, input.Email, input.Adresse, input.Actif);
            var depot = new FournisseursDepot_DAL();
            depot.Insert(fournisseurs); // Appelle la méthode d'insertion fournisseur
        }
        #endregion

        #region Update
        public void Update(Fournisseur_DTO input)
        {
            var fournisseurs = new Fournisseurs_DAL(input.ID, input.Societe, input.Civilite, input.Nom, input.Prenom, input.Email, input.Adresse, input.Actif);
            var depot = new FournisseursDepot_DAL();
            depot.Update(fournisseurs); // Appelle la méthode de modification fournisseur
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
            fournisseurs = depot.GetByID(id); // Récupère l'id du fournisseur à supprimer
            depot.Delete(fournisseurs); // Appelle la méthode de suppression fournisseur 
        }
        #endregion

        #region GetProduitsByCsv
        private List<Produits_METIER> GetProduitsByCsv(int id, IEnumerable<String> csv_file)
        {
            List<Produits_METIER> listproduit = new List<Produits_METIER>();

            for (int i = 0; i < csv_file.Count(); i++)
            {
                var liste = csv_file.ElementAt(i).Split(';'); // Précise ';' comme élément de séparation des différentes informations récupérés
                // Initialise les données du CSV sous forme de liste/tableau
                string reference = liste[0];
                string libelle = liste[1];
                string marque = liste[2];

                Produits_METIER produit = new Produits_METIER(reference, libelle, marque, true); // On assigne par défaut la colonne actif sur TRUE
                listproduit.Add(produit); // Ajoute chaque produit du CSV à la liste de produit
            }

            return listproduit;
        }
        #endregion

        #region GetListProduitsByFournisseur
        public void GetListProduitsByFournisseur(int id, IEnumerable<String> csv_file)
        {
            Produits_Services produits_services = new Produits_Services();
            Liaison_Services liaison_services = new Liaison_Services();

            List<Produits_METIER> listProduitBDD = produits_services.GetByIDFournisseur(id); // Obtiens la liste des produits en BDD du fournisseur sélectionné par l'utilisateur

            List<Produits_METIER> listProduitCSV = GetProduitsByCsv(id, csv_file); // Obtiens la liste des produits contenu dans le fichier CSV sélectionné

            List<Produits_METIER> produitToAdd = new List<Produits_METIER>(); // Initialise une liste des produits qu'il va falloir ajouter à la BDD
            List<Produits_METIER> produitToUnable = new List<Produits_METIER>(); // Initialise une liste des produits qu'il va falloir désactiver de la BDD

            foreach (var csvproduit in listProduitCSV) // Parcours chaque produits de la liste issu du CSV
            {
                Produits_METIER matchproduits = null;
                if (listProduitBDD.Count == 0)
                {
                    produitToAdd.Add(csvproduit); // Ajout de chaque produits dans la BDD si il n'existe aucun produits
                }
                foreach (var produitsBDD in listProduitBDD) // Parcours chaque produits de la liste issu de la BDD
                {
                    if (produitsBDD.Reference.Equals(csvproduit.Reference)) // Compare les deux colonnes Références des deux listes 
                    {
                        matchproduits = produitsBDD;
                        break;
                    }
                    produitToAdd.Add(csvproduit); // Ajoute les différents produits du fichier CSV dans la liste de produit à ajouter
                }
            }
            // Liste de produit à ajouter effectuer

            foreach (var produitsBDD in listProduitBDD)
            {
                Produits_METIER matchproduits = null;
                foreach (var csvproduit in listProduitCSV)
                {
                    if (produitsBDD.Reference.Equals(csvproduit.Reference)) // Compare les deux colonnes Références des deux listes
                    {
                        matchproduits = produitsBDD;
                        break;
                    }
                    produitToUnable.Add(produitsBDD); // Ajoute les différents produits du fichier CSV dans la liste de produit à désactiver
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

                Liaison_DTO liaison_DTO = new Liaison_DTO();
                liaison_DTO.ID_fournisseur = id; 

                produits_services.Insert(produit_DTO); // Insère chaque produits dans la BDD
                liaison_DTO.ID_produit = produit_DTO.ID; // Récupère chaque ID des produits qui ont été inséré
                liaison_services.Insert(liaison_DTO); // Insère une liaison avec les fournisseurs pour chaque produit
            }
            foreach (var produit in produitToUnable)
            {
                Produits_DTO produit_DTO = new Produits_DTO();
                produit_DTO.Reference = produit.Reference;
                produit_DTO.Libelle = produit.Libelle;
                produit_DTO.Marque = produit.Marque;
                produit_DTO.Actif = produit.Actif;

                liaison_services.Delete(produit.ID, id); // Supprime chaque liaison des éléments de la liste "produitToUnable"
            }

            // Permets d'update un produits actif ou inactif
            produits_services.UpdateActif(); // Assigne TRUE pour tout les produits qui ont un id_produit dans la table liaison
            produits_services.UpdateNotActif(); // Assigne FALSE pour tout les produits qui n'ont aucun id_produit dans la table liaison
        }
        #endregion
    }
}
