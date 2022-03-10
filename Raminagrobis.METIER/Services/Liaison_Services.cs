using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raminagrobis.DTO.DTO;
using Raminagrobis.DAL.Depot;
using Raminagrobis.METIER.Metier;
using Raminagrobis.DAL.DAL;

namespace Raminagrobis.METIER.Services
{
    public class Liaison_Services
    {
        private LiaisonDepot_DAL depot = new LiaisonDepot_DAL();

        #region GetAll
        public List<Liaison_METIER> GetAll()
        {
            var result = new List<Liaison_METIER>();
            var depot = new LiaisonDepot_DAL();
            foreach (var item in depot.GetAll())
            {
                result.Add(new Liaison_METIER(item.ID_produit, item.ID_fournisseur));
            }
            return result;
        }
        #endregion

        #region GetByID_produit
        public Liaison_METIER GetByID_produit(int id_produit)
        {
            var depot = new LiaisonDepot_DAL();
            var item = depot.GetByID_produit(id_produit);
            return new Liaison_METIER(item.ID_produit, item.ID_fournisseur);
        }
        #endregion

        #region GetByID_fournisseur
        public Liaison_METIER GetByID_fournisseur(int id_fournisseur)
        {
            var depot = new LiaisonDepot_DAL();
            var item = depot.GetByID_fournisseur(id_fournisseur);
            return new Liaison_METIER(item.ID_produit, item.ID_fournisseur);
        }
        #endregion

        #region Insert
        public void Insert(Liaison_DTO input)
        {
            var liaison = new Liaison_DAL(input.ID_produit, input.ID_fournisseur);
            var depot = new LiaisonDepot_DAL();
            depot.Insert(liaison);
        }
        #endregion

        #region Delete
        public void Delete(int id_produit, int id_fournisseur)
        {
            depot.Delete(id_produit, id_fournisseur);
        }
        #endregion

    }
}
