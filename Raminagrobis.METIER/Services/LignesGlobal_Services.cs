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
    public class LignesGlobal_Services
    {
        private LignesGlobalDepot_DAL depot = new LignesGlobalDepot_DAL();

        #region GetAll
        public List<LignesGlobal_METIER> GetAll()
        {
            var result = new List<LignesGlobal_METIER>();
            var depot = new LignesGlobalDepot_DAL();
            foreach (var item in depot.GetAll())
            {
                result.Add(new LignesGlobal_METIER(item.ID, item.ID_panier, item.Quantite, item.ID_produit));
            }
            return result;
        }
        #endregion

        #region GetByID
        public LignesGlobal_METIER GetByID(int id)
        {
            var depot = new LignesGlobalDepot_DAL();
            var input = depot.GetByID(id);
            return new LignesGlobal_METIER(input.ID, input.ID_panier, input.Quantite, input.ID_produit);
        }
        #endregion

        #region Insert
        public void Insert(LignesGlobal_DTO input)
        {
            var lignesGlobal = new LignesGlobal_DAL(input.ID_panier, input.Quantite, input.ID_produit);
            var depot = new LignesGlobalDepot_DAL();
            depot.Insert(lignesGlobal);
        }
        #endregion

        #region Update
        public void Update(int id, LignesGlobal_DTO input)
        {
            var lignesGlobal = new LignesGlobal_DAL(id, input.ID_panier, input.Quantite, input.ID_produit);
            var depot = new LignesGlobalDepot_DAL();
            depot.Update(lignesGlobal);
        }
        #endregion

        #region Delete
        public void Delete(int id)
        {
            LignesGlobal_DAL lignesGlobal;
            LignesGlobalDepot_DAL depot = new LignesGlobalDepot_DAL();
            lignesGlobal = depot.GetByID(id);
            depot.Delete(lignesGlobal);
        }
        #endregion
    }
}
