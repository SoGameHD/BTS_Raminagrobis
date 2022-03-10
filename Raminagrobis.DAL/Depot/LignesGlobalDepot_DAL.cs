using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using Raminagrobis.DAL.DAL;

namespace Raminagrobis.DAL.Depot
{
    public class LignesGlobalDepot_DAL : Depot_DAL<LignesGlobal_DAL>
    {
        #region GetAll
        public override List<LignesGlobal_DAL> GetAll()
        {
            CreerConnexionEtCommande();

            commande.CommandText = "SELECT id, annee, num_semaine, actif FROM LignesGlobal";
            var reader = commande.ExecuteReader();

            var listeGlobal = new List<LignesGlobal_DAL>();

            while (reader.Read())
            {
                var lignesGlobal = new LignesGlobal_DAL(reader.GetInt32(0),
                                        reader.GetInt32(1),
                                        reader.GetInt32(2),
                                        reader.GetBoolean(3)
                                        );

                listeGlobal.Add(lignesGlobal);
            }

            DetruireConnexionEtCommande();

            return listeGlobal;
        }
        #endregion

        #region GetByID
        public override LignesGlobal_DAL GetByID(int ID)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "SELECT ID, annee, num_semaine, actif FROM LignesGlobal WHERE ID=@ID";
            commande.Parameters.Add(new SqlParameter("@ID", ID));
            var reader = commande.ExecuteReader();

            LignesGlobal_DAL listeGlobal;

            if (reader.Read())
            {
                listeGlobal = new LignesGlobal_DAL(reader.GetInt32(0),
                                        reader.GetInt32(1),
                                        reader.GetInt32(2),
                                        reader.GetBoolean(3)
                                        );
            }
            else
            {
                throw new Exception($"Aucune occurance à l'ID {ID} dans la table LignesGlobal");
            }

            DetruireConnexionEtCommande();

            return listeGlobal;
        }
        #endregion

        #region GetByAnneNumSemaine
        public LignesGlobal_DAL GetByAnneNumSemaine(int annee, int num_semaine)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "SELECT ID, annee, num_semaine, actif FROM LignesGlobal WHERE annee=@annee AND num_semaine=num_semaine";
            commande.Parameters.Add(new SqlParameter("@annee", annee));
            commande.Parameters.Add(new SqlParameter("@num_semaine", num_semaine));
            var reader = commande.ExecuteReader();

            LignesGlobal_DAL listeGlobal;

            if (reader.Read())
            {
                listeGlobal = new LignesGlobal_DAL(reader.GetInt32(0),
                                        reader.GetInt32(1),
                                        reader.GetInt32(2),
                                        reader.GetBoolean(3)
                                        );
            }
            else
            {
                throw new Exception($"Aucune occurance à l'année {annee} et à la semaine {num_semaine} dans la table LignesGlobal");
            }

            DetruireConnexionEtCommande();

            return listeGlobal;
        }
        #endregion

        #region Insert
        public override LignesGlobal_DAL Insert(LignesGlobal_DAL lignesGlobal)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "INSERT INTO LignesGlobal(annee, num_semaine, actif) VALUES (@Annee, @Num_semaine, @Actif); SELECT SCOPE_IDENTITY()";
            commande.Parameters.Add(new SqlParameter("@Annee", lignesGlobal.Annee));
            commande.Parameters.Add(new SqlParameter("@Num_semaine", lignesGlobal.Num_semaine));
            commande.Parameters.Add(new SqlParameter("@Actif", lignesGlobal.Actif));

            var ID = Convert.ToInt32((decimal)commande.ExecuteScalar());

            lignesGlobal.ID = ID;

            DetruireConnexionEtCommande();

            return lignesGlobal;
        }
        #endregion

        #region Update
        public override LignesGlobal_DAL Update(LignesGlobal_DAL lignesGlobal)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "UPDATE LignesGlobal SET annee = @Annee, num_semaine = @Num_semaine, actif = @Actif WHERE ID = @ID";
            commande.Parameters.Add(new SqlParameter("@Annee", lignesGlobal.Annee));
            commande.Parameters.Add(new SqlParameter("@Num_semaine", lignesGlobal.Num_semaine));
            commande.Parameters.Add(new SqlParameter("@Actif", lignesGlobal.Actif));
            commande.Parameters.Add(new SqlParameter("@ID", lignesGlobal.ID));
            var nombreDeLignesAffectees = commande.ExecuteNonQuery();

            if (nombreDeLignesAffectees != 1)
            {
                throw new Exception($"Impossible de mettre à jour la LignesGlobal d'ID {lignesGlobal.ID}");
            }


            DetruireConnexionEtCommande();

            return lignesGlobal;
        }
        #endregion

        #region Delete
        public override void Delete(LignesGlobal_DAL lignesGlobal)
        {
            CreerConnexionEtCommande();
            commande.CommandText = "DELETE FROM LignesGlobal WHERE ID = @ID";
            commande.Parameters.Add(new SqlParameter("@ID", lignesGlobal.ID));

            var nombreDeLignesAffectees = commande.ExecuteNonQuery();

            if (nombreDeLignesAffectees < 0)
            {
                throw new Exception($"Impossible de supprimer la LignesGlobal d'ID : {lignesGlobal.ID}");
            }
            DetruireConnexionEtCommande();
        }
        #endregion
    }
}
