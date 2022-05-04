using Raminagrobis.DAL.DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raminagrobis.DAL.Depot
{
    public class PropositionsDepot_DAL : Depot_DAL<Propositions_DAL>
    {
        #region GetAll
        public override List<Propositions_DAL> GetAll()
        {
            CreerConnexionEtCommande();

            commande.CommandText = "SELECT id, id_ligne_global, id_fournisseur, id_produit, prix FROM Propositions";
            var reader = commande.ExecuteReader();

            var listePropositions = new List<Propositions_DAL>();

            while (reader.Read())
            {
                var commande = new Propositions_DAL(reader.GetInt32(0),
                                        reader.GetInt32(1),
                                        reader.GetInt32(2),
                                        reader.GetInt32(3),
                                        reader.GetInt32(4),
                                        reader.GetBoolean(5),
                                        reader.GetString(6),
                                        reader.GetString(7),
                                        reader.GetInt32(8)
                                        );

                listePropositions.Add(commande);
            }

            DetruireConnexionEtCommande();

            return listePropositions;
        }
        #endregion

        #region GetByID
        public override Propositions_DAL GetByID(int ID)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "SELECT ID, id_ligne_global, id_fournisseur, id_produit, prix FROM Propositions WHERE ID=@ID";
            commande.Parameters.Add(new SqlParameter("@ID", ID));
            var reader = commande.ExecuteReader();

            Propositions_DAL propositions;
            if (reader.Read())
            {
                propositions = new Propositions_DAL(reader.GetInt32(0),
                                        reader.GetInt32(1),
                                        reader.GetInt32(2),
                                        reader.GetInt32(3),
                                        reader.GetInt32(4),
                                        reader.GetBoolean(5),
                                        reader.GetString(6),
                                        reader.GetString(7),
                                        reader.GetInt32(8)
                                        );
            }
            else
            {
                throw new Exception($"Aucune occurance à l'ID {ID} dans la table Propositions");
            }


            DetruireConnexionEtCommande();

            return propositions;
        }
        #endregion

        #region GetByID_ligne_global
        public Propositions_DAL GetByID_ligne_global(int ID_ligne_global)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "SELECT ID, id_ligne_global, id_fournisseur, id_produit, prix FROM Propositions WHERE ID_ligne_global=@ID_ligne_global";
            commande.Parameters.Add(new SqlParameter("@ID_ligne_global", ID_ligne_global));
            var reader = commande.ExecuteReader();

            Propositions_DAL listePropositions;

            if (reader.Read())
            {
                listePropositions = new Propositions_DAL(reader.GetInt32(0),
                                            reader.GetInt32(1),
                                            reader.GetInt32(2),
                                            reader.GetInt32(3),
                                            reader.GetInt32(4),
                                            reader.GetBoolean(5),
                                            reader.GetString(6),
                                            reader.GetString(7),
                                            reader.GetInt32(8)
                                        );
            }
            else
            {
                throw new Exception($"Aucune occurance à l'ID {ID_ligne_global} dans la table Propositions");
            }


            DetruireConnexionEtCommande();

            return listePropositions;
        }
        #endregion

        #region GetByID_fournisseur
        public Propositions_DAL GetByID_fournisseur(int ID_fournisseur)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "SELECT ID, id_ligne_global, id_fournisseur, id_produit, prix WHERE ID_fournisseur=@ID_fournisseur";
            commande.Parameters.Add(new SqlParameter("@ID_fournisseur", ID_fournisseur));
            var reader = commande.ExecuteReader();

            Propositions_DAL listePropositions;

            if (reader.Read())
            {
                listePropositions = new Propositions_DAL(reader.GetInt32(0),
                                            reader.GetInt32(1),
                                            reader.GetInt32(2),
                                            reader.GetInt32(3),
                                            reader.GetInt32(4),
                                            reader.GetBoolean(5),
                                            reader.GetString(6),
                                            reader.GetString(7),
                                            reader.GetInt32(8)
                                        );
            }
            else
            {
                throw new Exception($"Aucune occurance à l'ID {ID_fournisseur} dans la table Propositions");
            }


            DetruireConnexionEtCommande();

            return listePropositions;
        }
        #endregion

        #region Insert
        public override Propositions_DAL Insert(Propositions_DAL propositions)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "INSERT INTO Propositions (id_ligne_global, id_fournisseur, id_produit, prix, gagne, societe, libelle_produit, quantite) VALUES (@ID_ligne_global, @ID_fournisseur, @ID_produit, @Prix, @Gagne, @Societe, @Libelle_produit, @Quantite); SELECT SCOPE_IDENTITY()";
            commande.Parameters.Add(new SqlParameter("@ID_ligne_global", propositions.ID_ligne_global));
            commande.Parameters.Add(new SqlParameter("@ID_fournisseur", propositions.ID_fournisseur));
            commande.Parameters.Add(new SqlParameter("@ID_produit", propositions.ID_produit));
            commande.Parameters.Add(new SqlParameter("@Prix", propositions.Prix));
            commande.Parameters.Add(new SqlParameter("@Gagne", propositions.Gagne));
            commande.Parameters.Add(new SqlParameter("@Societe", propositions.Societe));
            commande.Parameters.Add(new SqlParameter("@Libelle_produit", propositions.Libelle_Produit));
            commande.Parameters.Add(new SqlParameter("@Quantite", propositions.Quantite));
            var ID = Convert.ToInt32((decimal)commande.ExecuteScalar());
            propositions.ID = ID;

            DetruireConnexionEtCommande();

            return propositions;
        }
        #endregion

        #region Update
        public override Propositions_DAL Update(Propositions_DAL propositions)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "UPDATE Propositions SET prix = @Prix WHERE ID = @ID";
            commande.Parameters.Add(new SqlParameter("@Prix", propositions.Prix));
            commande.Parameters.Add(new SqlParameter("@ID", propositions.ID));
            var nombreDeLignesAffectees = commande.ExecuteNonQuery();

            if (nombreDeLignesAffectees != 1)
            {
                throw new Exception($"Impossible de mettre à jour le propositions d'ID_ligne_global {propositions.ID}");
            }

            DetruireConnexionEtCommande();

            return propositions;
        }
        #endregion

        #region Delete
        public override void Delete(Propositions_DAL propositions)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}