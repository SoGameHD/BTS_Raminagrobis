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
                result.Add(new LignesAdherents_METIER(item.ID_ligne_global, item.Quantite, item.ID_produit, item.ID_adherent));
            }
            return result;
        }
        #endregion

        #region GetByID_ligne_global
        public LignesAdherents_METIER GetByID_ligne_global(int id_ligne_global)
        {
            var depot = new LignesAdherentsDepot_DAL();
            var input = depot.GetByID_ligne_global(id_ligne_global);
            return new LignesAdherents_METIER(input.ID_produit, input.Quantite, input.ID_adherent, input.ID_ligne_global);
        }
        #endregion

        #region GetByID_adherent
        public LignesAdherents_METIER GetByID_adherent(int id_adherent)
        {
            var depot = new LignesAdherentsDepot_DAL();
            var input = depot.GetByID_adherent(id_adherent);
            return new LignesAdherents_METIER(input.ID_produit, input.Quantite, input.ID_adherent, input.ID_ligne_global);
        }
        #endregion

        #region Insert
        public void Insert(LignesAdherents_DTO input)
        {
            var lignesAdherents = new LignesAdherents_DAL(input.ID_produit, input.Quantite, input.ID_adherent, input.ID_ligne_global);
            var depot = new LignesAdherentsDepot_DAL();
            depot.Insert(lignesAdherents);
        }
        #endregion

        #region Update
        public void Update(LignesAdherents_DTO input)
        {
            var lignesAdherents = new LignesAdherents_DAL(input.ID_ligne_global, input.Quantite, input.ID_produit, input.ID_adherent);
            var depot = new LignesAdherentsDepot_DAL();
            depot.Update(lignesAdherents);
        }
        #endregion

        #region Delete
        public void Delete(int id)
        {
            LignesAdherents_DAL lignesAdherent;
            LignesAdherentsDepot_DAL depot = new LignesAdherentsDepot_DAL();
            lignesAdherent = depot.GetByID(id);
            depot.Delete(lignesAdherent);
        }
        #endregion
    }
}
