using DBContext;
using DBEntity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NSwag.Annotations;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;

namespace API.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Produces("application/json")]
    [Route("api/User")]
    public class UserController : Controller
    {

        /// <summary>
        /// Constructor
        /// </summary>
        protected readonly IUserRepository _UserRepository;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="UserRepository"></param>
        public UserController(IUserRepository UserRepository)
        {
            _UserRepository = UserRepository;

        }

        /// <summary>
        /// GetValidUser
        /// </summary>
        /// <returns></returns>
        [Produces("application/json")]
        [SwaggerOperation("GetValidUser")]
        [AllowAnonymous]
        [HttpGet]
        [Route("GetValidUser")]
        public ActionResult GetValidUser(string userName, string Contrasena)
        {
            var ret = _UserRepository.ValidUser(userName, Contrasena);

            if (ret == null)
                return StatusCode(401);

            return Json(ret);
        }

        /// <summary>
        /// GetListUser
        /// </summary>
        /// <returns></returns>
        [Produces("application/json")]
        [SwaggerOperation("GetListUser")]
        [AllowAnonymous]
        [HttpGet]
        [Route("GetListUser")]
        public ActionResult Get()
        {
            var ret = _UserRepository.GetUsers();

            if (ret == null)
                return StatusCode(401);

            return Json(ret);
        }
    }
}