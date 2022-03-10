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
    public class Liaison_Controller : ControllerBase
    {
        private Liaison_Services service;

        public Liaison_Controller(Liaison_Services srv)
        {
            service = srv;
        }

        #region GetAll
        [HttpGet]
        public IEnumerable<Liaison_DTO> GetAll()
        {
            return service.GetAll().Select(item => new Liaison_DTO()
            {
                ID_produit = item.ID_produit,
                ID_fournisseur = item.ID_fournisseur,
            });
        }
        #endregion

        #region Insert
        [HttpPost]
        public void Insert([FromBody] Liaison_DTO item)
        {
            service.Insert(item);
        }
        #endregion
    }
}
