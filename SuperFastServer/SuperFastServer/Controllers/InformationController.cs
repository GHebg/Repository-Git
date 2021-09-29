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
    [RoutePrefix("api/Information")]

    public class InformationController : ApiController
    {
        [HttpGet]
        [Route("GetAllInformation")]
        //get
        public IHttpActionResult GetAllInformation()
        {
            return Ok(Information_DAL.GetAllInformation());
        }

        [HttpGet]
        [Route("GetInfoByMessenger/{MessengerId}")]
        //get
        public IHttpActionResult GetInfoByMessenger(int MessengerId)
        {
            return Ok(Information_DAL.GetInfoByMessenger(MessengerId));
        }

        [HttpGet]
        [Route("GetInfoByCust/{CustId}")]
        //get
        public IHttpActionResult GetInfoByCust(int CustId)
        {
            return Ok(Information_DAL.GetInfoByCust(CustId));
        }
        [HttpPost]
        [Route("AddInfo")]
        //post
        public IHttpActionResult AddInfo([FromBody] Information_DTO i)
        {
            return Ok(Information_DAL.AddInfo(i));
        }

        [HttpPut]
        [Route("UpdateInfo")]
        //put
        public IHttpActionResult UpdateInfo([FromBody] Information_DTO i)
        {
            return Ok(Information_DAL.UpdateInfo(i));
        }

        [HttpDelete]
        [Route("DeleteInfo/{cId}")]
        //delete
        public IHttpActionResult DeleteInfo(int cId)
        {
            return Ok(Information_DAL.DeleteInfo(cId));
        }

    }
}
