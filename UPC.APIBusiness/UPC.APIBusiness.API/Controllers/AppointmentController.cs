using DBEntity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Produces("application/json")]
    [Route("api/Appointment")]    
    public class AppointmentController : ControllerBase
    {

        [Produces("application/json")]
        [SwaggerOperation("history")]        
        [HttpGet]        
        public IEnumerable<string> GetHistory(string user)
        {
            return new string[] { "value1", "value2" };
        }

        
        [Produces("application/json")]
        [AllowAnonymous]
        [HttpGet]
        [Route("pending")]
        public string GetAppointmentPending(string user)
        {
            return "value";
        }
        //// GET api/<AppointmentController>/5
        //[HttpGet("{id}")]
        //public string GetAppointmentById(int id)
        //{
        //    return "value";
        //}

        //// POST api/<AppointmentController>
        //[HttpPost]
        //public string SaveAppointment(EntityCita cita)
        //{
        //    return "value";
        //}

    }
}
