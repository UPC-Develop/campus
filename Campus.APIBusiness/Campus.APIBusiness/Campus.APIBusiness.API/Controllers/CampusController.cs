using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Campus.APIBusiness.DBContext.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Campus.APIBusiness.API.Controllers
{
    [Produces("application/json")]
    [Route("api/campus")]
    public class CampusController : Controller
    {

        protected readonly ICampusRepository _CampusRepository;

        public CampusController(ICampusRepository CampusRepository)
        {
            _CampusRepository = CampusRepository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="campus_id"></param>
        /// <param name="active"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [AllowAnonymous]
        [HttpGet]
        [Route("list_campus")]
        public ActionResult List_Campus(Int32 campus_id, int active)
        {
            var ret = _CampusRepository.List_Campus(campus_id, active);
            return Json(ret);
        }

    }
}
