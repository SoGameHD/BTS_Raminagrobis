using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raminagrobis.DAL.DAL;
using Raminagrobis.DAL.Depot;
using Raminagrobis.DTO.DTO;
using Raminagrobis.METIER.Metier;

namespace Raminagrobis.METIER.Services
{
    public class CommandeAdherents_Services
    {
        #region GetAll
        public List<CommandeAdherents_METIER> GetAll()
        {
            var result = new List<CommandeAdherents_METIER>();
            var depot = new CommandeAdherentsDepot_DAL();
            foreach (var item in depot.GetAll())
            {
                result.Add(new CommandeAdherents_METIER(item.ID, item.ID_adherent, item.ID_panier));
            }
            return result;
        }
        #endregion

        #region GetByID
        public CommandeAdherents_METIER GetByID(int id)
        {
            var depot = new CommandeAdherentsDepot_DAL();
            var commandeAdherents = depot.GetByID(id);
            return new CommandeAdherents_METIER(commandeAdherents.ID, commandeAdherents.ID_adherent, commandeAdherents.ID_panier);
        }
        #endregion

        #region Insert
        public void Insert(CommandeAdherent_DTO input)
        {
            var commandeAdherents = new CommandeAdherents_DAL(input.ID_adherent, input.ID_panier);
            var depot = new CommandeAdherentsDepot_DAL();
            depot.Insert(commandeAdherents);
        }
        #endregion

        #region Update
        public void Update(int id, CommandeAdherent_DTO input)
        {
            var commandeAdherents = new CommandeAdherents_DAL(input.ID_adherent, input.ID_panier);
            var depot = new CommandeAdherentsDepot_DAL();
            depot.Update(commandeAdherents);
        }
        #endregion

        #region Delete
        public void Delete(int id)
        {
            CommandeAdherents_DAL adherent;
            CommandeAdherentsDepot_DAL depot = new CommandeAdherentsDepot_DAL();
            adherent = depot.GetByID(id);
            depot.Delete(adherent);
        }
        #endregion
    }
}
