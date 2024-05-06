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
    [Route("api/project")]
    public class ProjectController : Controller
    {
        /// <summary>
        /// 
        /// </summary>
        protected readonly IProjectRepository _projectRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="projectRepository"></param>
        public ProjectController(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Produces("application/json")]
        [AllowAnonymous]
        [HttpGet]
        [Route("listar")]
        public ActionResult GetProjects()
        {
            var rest = _projectRepository.GetProjects();
            return Json(rest);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Produces("application/json")]
        [AllowAnonymous]
        [HttpGet]
        [Route("obtener")]
        public ActionResult GetProject(int id)
        {
            var rest = _projectRepository.GetProject(id);
            return Json(rest);
        }
    }
}