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
                result.Add(new LignesGlobal_METIER(item.ID, item.Annee, item.Num_semaine, item.Actif));
            }
            return result;
        }
        #endregion

        #region GetByID
        public LignesGlobal_METIER GetByID(int id)
        {
            var depot = new LignesGlobalDepot_DAL();
            var input = depot.GetByID(id);
            return new LignesGlobal_METIER(input.ID, input.Annee, input.Num_semaine, input.Actif);
        }
        #endregion

        #region GetByAnneNumSemaine
        public LignesGlobal_METIER GetByAnneNumSemaine(int annee, int num_semaine)
        {
            var depot = new LignesGlobalDepot_DAL();
            var input = depot.GetByAnneNumSemaine(annee, num_semaine);
            return new LignesGlobal_METIER(input.ID, input.Annee, input.Num_semaine, input.Actif);
        }
        #endregion

        #region Insert
        public LignesGlobal_DTO Insert(LignesGlobal_DTO input)
        {
            var lignesGlobal = new LignesGlobal_DAL(input.Annee, input.Num_semaine, input.Actif);
            var depot = new LignesGlobalDepot_DAL();
            depot.Insert(lignesGlobal);

            return input;
        }
        #endregion

        #region Update
        public LignesGlobal_DTO Update(int id, LignesGlobal_DTO input)
        {
            var lignesGlobal = new LignesGlobal_DAL(id, input.Annee, input.Num_semaine, input.Actif);
            var depot = new LignesGlobalDepot_DAL();
            depot.Update(lignesGlobal);

            return input;
        }
        #endregion

        #region UpdateActif
        public LignesGlobal_DTO UpdateActif(LignesGlobal_DTO input)
        {
            var lignesGlobal = new LignesGlobal_DAL(input.ID, input.Annee, input.Num_semaine, input.Actif);
            var depot = new LignesGlobalDepot_DAL();
            depot.UpdateActif(lignesGlobal);

            return input;
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