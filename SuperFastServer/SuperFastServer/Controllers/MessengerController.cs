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
    [RoutePrefix("api/Messenger")]

    public class MessengerController : ApiController
    {
        [HttpGet]
        [Route("GetAllMessengers")]
        //get
        public IHttpActionResult GetAllMessengers()
        {
            return Ok(Messenger_DAL.GetAllMessengers());
        }

        [HttpGet]
        [Route("GetMessengersById/{Id}")]
        //get
        public IHttpActionResult GetMessengersById(int Id)
        {
            return Ok(Messenger_DAL.GetMessengersById(Id));
        }

        [HttpGet]
        [Route("GetMessengerByManegerId/{Id}")]
        //get
        public IHttpActionResult GetMessengerByManegerId(int Id)
        {
            return Ok(Messenger_DAL.GetMessengerByManegerId(Id));
        }

        [HttpGet]
        [Route("MessengerExists/{mail}/{pass}")]
        //get
        public IHttpActionResult MessengerExists(string mail, string pass)
        {
            return Ok(Messenger_DAL.MessengerExists(mail, pass));
        }

        [HttpPost]
        [Route("AddMessenger")]
        //post
        public IHttpActionResult AddMessenger([FromBody] Messenger_DTO m)
        {
            return Ok(Messenger_DAL.AddMessenger(m));
        }

        [HttpPut]
        [Route("UpdateMessenger")]
        //put
        public IHttpActionResult UpdateMessenger([FromBody] Messenger_DTO m)
        {
            return Ok(Messenger_DAL.UpdateMessenger(m));
        }

        [HttpDelete]
        [Route("DeleteMessenger/{mId}")]
        //delete
        public IHttpActionResult DeleteMessenger(int mId)
        {
            return Ok(Messenger_DAL.DeleteMessenger(mId));
        }

    }
}
