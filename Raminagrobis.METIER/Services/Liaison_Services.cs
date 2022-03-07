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

        #region Insert
        public void Insert(Liaison_DTO input)
        {
            var liaison = new Liaison_DAL(input.ID_produit, input.ID_fournisseur);
            var depot = new LiaisonDepot_DAL();
            depot.Insert(liaison);
        }
        #endregion

    }
}
