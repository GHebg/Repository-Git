using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Entities_DTO.Tables;
using DAL;

namespace SuperFastServer.Controllers
{
    [RoutePrefix("api/Manager")]

    public class ManagerController : ApiController
    {
        [HttpGet]
        [Route("GetAllManagers")]
        //get
        public IHttpActionResult GetAllManagers()
        {
            return Ok(Manager_DAL.GetAllManagers());
        }

        [HttpGet]
        [Route("GetManagerByID/{id}")]
        //get
        public IHttpActionResult GetManagerByID(int id)
        {
            return Ok(Manager_DAL.GetManagerByID(id));
        }

        [HttpGet]
        [Route("ManagerExists/{mail}/{pass}")]
        //get
        public IHttpActionResult ManagerExists(string mail, string pass)
        {
            return Ok(Manager_DAL.ManagerExists(mail, pass));
        }

        [HttpPost]
        [Route("AddManager")]
        //post
        public IHttpActionResult AddManager([FromBody] Manager_DTO m)
        {
            return Ok(Manager_DAL.AddManager(m));
        }

        [HttpPut]
        [Route("UpdatManager")]
        //put
        public IHttpActionResult UpdatManager([FromBody] Manager_DTO m)
        {
            return Ok(Manager_DAL.UpdatManager(m));
        }


    }
}
