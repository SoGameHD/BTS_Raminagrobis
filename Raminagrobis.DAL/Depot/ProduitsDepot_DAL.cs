using Raminagrobis.DAL.DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raminagrobis.DAL.Depot
{
    public class ProduitsDepot_DAL : Depot_DAL<Produits_DAL>
    {
        #region GetAll
        public override List<Produits_DAL> GetAll()
        {
            CreerConnexionEtCommande();

            commande.CommandText = "SELECT id, reference, libelle, marque, actif FROM Produits";
            var reader = commande.ExecuteReader();

            var listeProduits = new List<Produits_DAL>();

            while (reader.Read())
            {
                var produits = new Produits_DAL(reader.GetInt32(0),
                                        reader.GetString(1),
                                        reader.GetString(2),
                                        reader.GetString(3),
                                        reader.GetBoolean(4)
                                        );

                listeProduits.Add(produits);
            }

            DetruireConnexionEtCommande();

            return listeProduits;
        }
        #endregion

        #region GetByID
        public override Produits_DAL GetByID(int ID)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "SELECT ID, reference, libelle, marque, actif FROM Produits WHERE ID=@ID";
            commande.Parameters.Add(new SqlParameter("@ID", ID));
            var reader = commande.ExecuteReader();

            Produits_DAL listeProduits;

            if (reader.Read())
            {
                listeProduits = new Produits_DAL(reader.GetInt32(0),
                                        reader.GetString(1),
                                        reader.GetString(2),
                                        reader.GetString(3),
                                        reader.GetBoolean(4)
                                        );
            }
            else
            {
                throw new Exception($"Aucune occurance ?? l'ID {ID} dans la table Produits");
            }

            DetruireConnexionEtCommande();

            return listeProduits;
        }
        #endregion

        #region GetByIDFournisseur
        public List<Produits_DAL> GetByIDFournisseur(int ID_fournisseur)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "SELECT id, libelle, marque, reference, actif FROM produits INNER JOIN Liaison ON id = id_produit WHERE id_fournisseur = @ID_fournisseur";
            commande.Parameters.Add(new SqlParameter("@ID_fournisseur", ID_fournisseur));
            var reader = commande.ExecuteReader();

            var listeProduits = new List<Produits_DAL>();

            while (reader.Read())
            {
                var produits = new Produits_DAL(reader.GetInt32(0),
                                        reader.GetString(1),
                                        reader.GetString(2),
                                        reader.GetString(3),
                                        reader.GetBoolean(4)
                                        );
                listeProduits.Add(produits);
            }

            DetruireConnexionEtCommande();

            return listeProduits;
        }
        #endregion

        #region GetByReference
        public List<Produits_DAL> GetByReference(string reference)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "SELECT id, reference, libelle, marque, actif FROM produits WHERE reference = @Reference";
            commande.Parameters.Add(new SqlParameter("@Reference", reference));
            var reader = commande.ExecuteReader();

            var listeProduits = new List<Produits_DAL>();
            
            while (reader.Read())
            {
                var produits = new Produits_DAL(reader.GetInt32(0),
                                        reader.GetString(1),
                                        reader.GetString(2),
                                        reader.GetString(3),
                                        reader.GetBoolean(4)
                                        );
                listeProduits.Add(produits);
            }

            DetruireConnexionEtCommande();

            return listeProduits;
        }
        #endregion

        #region Insert
        public override Produits_DAL Insert(Produits_DAL produits)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "INSERT INTO Produits (reference, libelle, marque, actif) VALUES (@Reference, @Libelle, @Marque, @Actif); SELECT SCOPE_IDENTITY()";
            commande.Parameters.Add(new SqlParameter("@Reference", produits.Reference));
            commande.Parameters.Add(new SqlParameter("@Libelle", produits.Libelle));
            commande.Parameters.Add(new SqlParameter("@Marque", produits.Marque));
            commande.Parameters.Add(new SqlParameter("@Actif", produits.Actif));

            var ID = Convert.ToInt32((decimal)commande.ExecuteScalar());

            produits.ID = ID;

            DetruireConnexionEtCommande();

            return produits;
        }
        #endregion

        #region Update
        public override Produits_DAL Update(Produits_DAL produits)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "UPDATE Produits SET reference = @Reference, libelle = @Libelle, marque = @Marque, actif = @Actif WHERE ID = @ID";
            commande.Parameters.Add(new SqlParameter("@Reference", produits.Reference));
            commande.Parameters.Add(new SqlParameter("@Libelle", produits.Libelle));
            commande.Parameters.Add(new SqlParameter("@Marque", produits.Marque));
            commande.Parameters.Add(new SqlParameter("@Actif", produits.Actif));
            commande.Parameters.Add(new SqlParameter("@ID", produits.ID));
            var nombreDeLignesAffectees = commande.ExecuteNonQuery();

            if (nombreDeLignesAffectees != 1)
            {
                throw new Exception($"Impossible de mettre ?? jour le Produits d'ID {produits.ID}");
            }


            DetruireConnexionEtCommande();

            return produits;
        }
        #endregion

        #region UpdateActif
        public void UpdateActif()
        {
            CreerConnexionEtCommande();

            commande.CommandText = "UPDATE produits SET actif=1 FROM produits P WHERE EXISTS (SELECT * FROM Liaison WHERE id_produit=P.id)";

            DetruireConnexionEtCommande();
        }
        #endregion
        
        #region UpdateNotActif
        public void UpdateNotActif()
        {
            CreerConnexionEtCommande();

            commande.CommandText = "UPDATE produits SET actif=0 FROM produits P WHERE NOT EXISTS (SELECT * FROM Liaison WHERE id_produit=P.id)";

            DetruireConnexionEtCommande();
        }
        #endregion

        #region Delete
        public override void Delete(Produits_DAL produits)
        {
            CreerConnexionEtCommande();
            commande.CommandText = "DELETE FROM Produits WHERE ID = @ID";
            commande.Parameters.Add(new SqlParameter("@ID", produits.ID));

            var nombreDeLignesAffectees = commande.ExecuteNonQuery();

            if (nombreDeLignesAffectees < 0)
            {
                throw new Exception($"Impossible de supprimer le produit d'ID {produits.ID}");
            }
            DetruireConnexionEtCommande();
        }
        #endregion
    }
}
