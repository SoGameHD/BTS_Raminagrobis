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
    public class LignesGlobal_Controller : ControllerBase
    {
        private LignesGlobal_Services service;

        public LignesGlobal_Controller(LignesGlobal_Services srv)
        {
            service = srv;
        }

        #region GetAll
        [HttpGet]
        public IEnumerable<LignesGlobal_DTO> GetAll()
        {
            return service.GetAll().Select(item => new LignesGlobal_DTO()
            {
                ID = item.ID,
                Annee = item.Annee,
                Num_semaine = item.Num_semaine,
                Actif = item.Actif,
            });
        }
        #endregion


        #region GetByID
        [HttpGet("{id}")]
        public LignesGlobal_DTO GetByID(int id)
        {
            var item = service.GetByID(id);
            return new LignesGlobal_DTO()
            {
                ID = item.ID,
                Annee = item.Annee,
                Num_semaine = item.Num_semaine,
                Actif = item.Actif,
            };
        }
        #endregion

        #region Insert
        [HttpPost]
        public void Insert([FromBody] LignesGlobal_DTO item)
        {
            service.Insert(item);
        }
        #endregion


        #region Update
        [HttpPut]
        public void Update([FromBody] LignesGlobal_DTO item)
        {
            service.Update(item);
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
