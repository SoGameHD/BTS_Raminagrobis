using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Raminagrobis.METIER.Services;
using Raminagrobis.DTO.DTO;

namespace Raminagrobis.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CommandeAdherents_Controller : ControllerBase
    {
        private CommandeAdherents_Services service;

        public CommandeAdherents_Controller(CommandeAdherents_Services srv)
        {
            service = srv;
        }

        #region GetAll
        [HttpGet]
        public IEnumerable<CommandeAdherent_DTO> GetAll()
        {
            return service.GetAll().Select(item => new CommandeAdherent_DTO()
            {
                ID = item.ID,
                ID_panier = item.ID_panier,
                ID_adherent = item.ID_adherent,
            });
        }
        #endregion

        #region GetByID
        [HttpGet("{id}")]
        public CommandeAdherent_DTO GetByID(int id)
        {
            var item = service.GetByID(id);
            return new CommandeAdherent_DTO()
            {
                ID = item.ID,
                ID_panier = item.ID_panier,
                ID_adherent = item.ID_adherent,
            };
        }
        #endregion

        #region Insert
        [HttpPost]
        public void Insert([FromBody] CommandeAdherent_DTO item)
        {
            service.Insert(item);
        }
        #endregion

        #region Update
        [HttpPut("{id}")]
        public void Update(int id, [FromBody] CommandeAdherent_DTO item)
        {
            service.Update(id, item);
        }
        #endregion

        #region Delete
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            service.Delete(id);
        }
        #endregion
    }
}
