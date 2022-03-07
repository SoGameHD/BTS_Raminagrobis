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
    public class LignesAdherents_Services
    {
        private LignesAdherentsDepot_DAL depot = new LignesAdherentsDepot_DAL();

        #region GetAll
        public List<LignesAdherents_METIER> GetAll()
        {
            var result = new List<LignesAdherents_METIER>();
            var depot = new LignesAdherentsDepot_DAL();
            foreach (var item in depot.GetAll())
            {
                result.Add(new LignesAdherents_METIER(item.ID_ligne_global, item.Quantite, item.ID_produit, item.ID_commande));
            }
            return result;
        }
        #endregion

        #region Insert
        public void Insert(LignesAdherents_DTO input)
        {
            var lignesAdherents = new LignesAdherents_DAL(input.ID_ligne_global, input.Quantite);
            var depot = new LignesAdherentsDepot_DAL();
            depot.Insert(lignesAdherents);
        }
        #endregion

        #region Update
        public void Update(LignesAdherents_DTO input)
        {
            var lignesAdherents = new LignesAdherents_DAL(input.ID_ligne_global, input.Quantite, input.ID_produit, input.ID_commande);
            var depot = new LignesAdherentsDepot_DAL();
            depot.Update(lignesAdherents);
        }
        #endregion

        #region Delete
        public void Delete(int id)
        {
            LignesAdherents_DAL lignesAdherents;
            LignesAdherentsDepot_DAL depot = new LignesAdherentsDepot_DAL();
            lignesAdherents = depot.GetByID(id);
            depot.Delete(lignesAdherents);
        }
        #endregion
    }
}
