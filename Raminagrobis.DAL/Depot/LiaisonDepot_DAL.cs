using Raminagrobis.DAL.DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raminagrobis.DAL.Depot
{
    public class LiaisonDepot_DAL : Depot_DAL<Liaison_DAL>
    {
        #region GetAll
        public override List<Liaison_DAL> GetAll()
        {
            CreerConnexionEtCommande();

            commande.CommandText = "SELECT id_produit, id_fournisseur FROM Liaison";
            var reader = commande.ExecuteReader();

            var listeLiaison = new List<Liaison_DAL>();

            while (reader.Read())
            {
                var liaison = new Liaison_DAL(reader.GetInt32(0),
                                        reader.GetInt32(1)
                                        );

                listeLiaison.Add(liaison);
            }

            DetruireConnexionEtCommande();

            return listeLiaison;
        }
        #endregion

        #region GetByID
        public override Liaison_DAL GetByID(int ID)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region GetByID_produit
        public List<Liaison_DAL> GetByID_produit(int ID_produit)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "SELECT ID_produit, ID_fournisseur FROM Liaison WHERE ID_produit=@ID_produit";
            commande.Parameters.Add(new SqlParameter("@ID_produit", ID_produit));
            var reader = commande.ExecuteReader();

            var listeLiaison = new List<Liaison_DAL>();

            while (reader.Read())
            {
                var liaison = new Liaison_DAL(reader.GetInt32(0),
                                        reader.GetInt32(1)
                                        );
                listeLiaison.Add(liaison);
            }

            DetruireConnexionEtCommande();

            return listeLiaison;
        }
        #endregion

        #region GetByID_fournisseur
        public Liaison_DAL GetByID_fournisseur(int ID_fournisseur)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "SELECT ID_produit, ID_fournisseur FROM Liaison WHERE ID_fournisseur=@ID_fournisseur";
            commande.Parameters.Add(new SqlParameter("@ID_fournisseur", ID_fournisseur));
            var reader = commande.ExecuteReader();

            Liaison_DAL liaison;

            if (reader.Read())
            {
                liaison = new Liaison_DAL(reader.GetInt32(0),
                                        reader.GetInt32(1)
                                        );
            }
            else
            {
                throw new Exception($"Aucune occurance à l'ID fournisseur {ID_fournisseur} dans la table Liaison");
            }

            DetruireConnexionEtCommande();

            return liaison;
        }
        #endregion

        #region Insert
        public override Liaison_DAL Insert(Liaison_DAL liaison)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "INSERT INTO Liaison (id_produit, id_fournisseur) VALUES (@ID_produit, @ID_fournisseur); SELECT SCOPE_IDENTITY()";
            commande.Parameters.Add(new SqlParameter("@ID_produit", liaison.ID_produit));
            commande.Parameters.Add(new SqlParameter("@ID_fournisseur", liaison.ID_fournisseur));
            var ID_produit = Convert.ToInt32((decimal)commande.ExecuteScalar());
            var ID_fournisseur = Convert.ToInt32((decimal)commande.ExecuteScalar());
            liaison.ID_produit = ID_produit;
            liaison.ID_fournisseur = ID_fournisseur;

            DetruireConnexionEtCommande();

            return liaison;
        }
        #endregion

        #region Update
        public override Liaison_DAL Update(Liaison_DAL liaison)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Delete
        public void Delete(int ID_produit, int ID_fournisseur)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "DELETE FROM Liaison WHERE ID_fournisseur=@ID_fournisseur and ID_produit=@ID_produit";
            commande.Parameters.Add(new SqlParameter("@ID_produit", ID_produit));
            commande.Parameters.Add(new SqlParameter("@ID_fournisseur", ID_fournisseur));
            commande.ExecuteNonQuery();

            DetruireConnexionEtCommande();
        }
        public override void Delete(Liaison_DAL item)
        {
            throw new NotImplementedException();
        }
        #endregion

    }
}