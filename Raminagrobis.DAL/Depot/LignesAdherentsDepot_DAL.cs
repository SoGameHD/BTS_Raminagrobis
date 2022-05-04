using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using Raminagrobis.DAL.DAL;

namespace Raminagrobis.DAL.Depot
{
    public class LignesAdherentsDepot_DAL : Depot_DAL<LignesAdherents_DAL>
    {
        #region GetAll
        public override List<LignesAdherents_DAL> GetAll()
        {
            CreerConnexionEtCommande();

            commande.CommandText = "SELECT ID, id_produit, id_ligne_global, id_adherent, quantite FROM LignesAdherent";
            var reader = commande.ExecuteReader();

            var listeAdherents = new List<LignesAdherents_DAL>();

            while (reader.Read())
            {
                var lignesAdherent = new LignesAdherents_DAL(reader.GetInt32(0),
                                        reader.GetInt32(1),
                                        reader.GetInt32(2),
                                        reader.GetInt32(3),
                                        reader.GetInt32(4)
                                        );

                listeAdherents.Add(lignesAdherent);
            }

            DetruireConnexionEtCommande();

            return listeAdherents;
        }
        #endregion

        #region GetByID
        public override LignesAdherents_DAL GetByID(int ID)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "SELECT ID, id_produit, id_ligne_global, id_adherent, quantite FROM LignesAdherent WHERE ID=@ID";
            commande.Parameters.Add(new SqlParameter("@ID", ID));
            var reader = commande.ExecuteReader();

            LignesAdherents_DAL lignesAdherents;
            if (reader.Read())
            {
                lignesAdherents = new LignesAdherents_DAL(reader.GetInt32(0),
                                        reader.GetInt32(1),
                                        reader.GetInt32(2),
                                        reader.GetInt32(3),
                                        reader.GetInt32(4)
                                        );
            }
            else
            {
                throw new Exception($"Aucune occurance à l'ID {ID} dans la table LignesAdherent");
            }


            DetruireConnexionEtCommande();

            return lignesAdherents;
        }
        #endregion

        #region GetByID_ligne_global
        public LignesAdherents_DAL GetByID_ligne_global(int ID_ligne_global)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "SELECT ID_ligne_global, id_produit, id_adherent, quantite FROM LignesAdherent WHERE ID_ligne_global=@ID_ligne_global";
            commande.Parameters.Add(new SqlParameter("@ID_ligne_global", ID_ligne_global));
            var reader = commande.ExecuteReader();

            LignesAdherents_DAL listeAdherent;

            if (reader.Read())
            {
                listeAdherent = new LignesAdherents_DAL(reader.GetInt32(0),
                                        reader.GetInt32(1),
                                        reader.GetInt32(2),
                                        reader.GetInt32(3),
                                        reader.GetInt32(4)
                                        );
            }
            else
            {
                throw new Exception($"Aucune occurance à l'ID_ligne_global {ID_ligne_global} dans la table LignesAdherent");
            }

            DetruireConnexionEtCommande();

            return listeAdherent;
        }
        #endregion

        #region GetByID_adherent
        public LignesAdherents_DAL GetByID_adherent(int ID_adherent)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "SELECT ID_adherent, id_produit, id_ligne_global, quantite FROM LignesAdherent WHERE ID_adherent=@ID_adherent";
            commande.Parameters.Add(new SqlParameter("@ID_adherent", ID_adherent));
            var reader = commande.ExecuteReader();

            LignesAdherents_DAL listeAdherent;

            if (reader.Read())
            {
                listeAdherent = new LignesAdherents_DAL(reader.GetInt32(0),
                                        reader.GetInt32(1),
                                        reader.GetInt32(2),
                                        reader.GetInt32(3),
                                        reader.GetInt32(4)
                                        );
            }
            else
            {
                throw new Exception($"Aucune occurance à l'ID_adherent {ID_adherent} dans la table LignesAdherent");
            }

            DetruireConnexionEtCommande();

            return listeAdherent;
        }
        #endregion

        #region GetByID_fournisseurAndID_lignesGlobal
        public List<LignesAdherents_DAL> GetByID_fournisseurAndID_lignesGlobal(int ID_fournisseur, int ID_ligne_global)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "SELECT LA.id, LA.id_produit, LA.quantite, LA.id_ligne_global, LA.id_adherent FROM LignesAdherent LA INNER JOIN produits P ON LA.id = P.id INNER JOIN Liaison L ON P.id = L.id_produit WHERE LA.id_ligne_global=@ID_ligne_global AND L.id_fournisseur=@ID_fournisseur";
            commande.Parameters.Add(new SqlParameter("@ID_ligne_global", ID_ligne_global));
            commande.Parameters.Add(new SqlParameter("@ID_fournisseur", ID_fournisseur));
            var reader = commande.ExecuteReader();

            var listLignesAdherent = new List<LignesAdherents_DAL>();

            while (reader.Read())
            {
                LignesAdherents_DAL lignesAdherents = new LignesAdherents_DAL(reader.GetInt32(0),
                                        reader.GetInt32(1),
                                        reader.GetInt32(2),
                                        reader.GetInt32(3),
                                        reader.GetInt32(4)
                                        );
                listLignesAdherent.Add(lignesAdherents);
            }

            DetruireConnexionEtCommande();

            return listLignesAdherent;
        }
        #endregion

        #region Insert
        public override LignesAdherents_DAL Insert(LignesAdherents_DAL lignesAdherent)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "INSERT INTO LignesAdherent (id_produit, id_ligne_global, id_adherent, quantite) VALUES (@ID_produit, @ID_ligne_global, @ID_adherent, @Quantite); SELECT SCOPE_IDENTITY()";
            commande.Parameters.Add(new SqlParameter("@ID_produit", lignesAdherent.ID_produit));
            commande.Parameters.Add(new SqlParameter("@ID_ligne_global", lignesAdherent.ID_ligne_global));
            commande.Parameters.Add(new SqlParameter("@ID_adherent", lignesAdherent.ID_adherent));
            commande.Parameters.Add(new SqlParameter("@Quantite", lignesAdherent.Quantite));
            var ID = Convert.ToInt32((decimal)commande.ExecuteScalar());
            lignesAdherent.ID = ID;

            DetruireConnexionEtCommande();

            return lignesAdherent;
        }
        #endregion

        #region Update
        public override LignesAdherents_DAL Update(LignesAdherents_DAL lignesAdherent)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "UPDATE LignesAdherent SET id_produit = @ID_produit, id_ligne_global = @ID_ligne_global, id_adherent = @ID_adherent, quantite = @Quantite WHERE ID = @ID";
            commande.Parameters.Add(new SqlParameter("@ID_produit", lignesAdherent.ID_produit));
            commande.Parameters.Add(new SqlParameter("@ID_ligne_global", lignesAdherent.ID_ligne_global));
            commande.Parameters.Add(new SqlParameter("@ID_adherent", lignesAdherent.ID_adherent));
            commande.Parameters.Add(new SqlParameter("@Quantite", lignesAdherent.Quantite));
            commande.Parameters.Add(new SqlParameter("@ID", lignesAdherent.ID));
            var nombreDeLignesAffectees = commande.ExecuteNonQuery();

            if (nombreDeLignesAffectees != 1)
            {
                throw new Exception($"Impossible de mettre à jour la LignesAdherents d'ID {lignesAdherent.ID} ");
            }

            DetruireConnexionEtCommande();

            return lignesAdherent;
        }
        #endregion

        #region Delete
        public override void Delete(LignesAdherents_DAL lignesAdherent)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "DELETE FROM LignesAdherent WHERE ID=@ID";
            commande.Parameters.Add(new SqlParameter("@ID", lignesAdherent.ID));

            var nombreDeLignesAffectees = commande.ExecuteNonQuery();

            if (nombreDeLignesAffectees < 0)
            {
                throw new Exception($"Impossible de supprimer la ligneAdherent d'ID {lignesAdherent.ID}");
            }

            DetruireConnexionEtCommande();
        }
        #endregion
    }
}
