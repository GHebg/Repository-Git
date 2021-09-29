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
    [RoutePrefix("api/Order")]

    public class OrderController : ApiController
    {
        [HttpGet]
        [Route("GetAllOrders")]
        //get
        public IHttpActionResult GetAllOrders()
        {
            return Ok(Order_DAL.GetAllOrders());
        }

        [HttpGet]
        [Route("GetOrderByMessenger/{Id}")]
        //get
        public IHttpActionResult GetOrderByMessenger(int Id)
        {
            return Ok(Order_DAL.GetOrderByMessenger(Id));
        }

        [HttpGet]
        [Route("GetOrderByCustId/{Id}")]
        //get
        public IHttpActionResult GetOrderByCustId(int Id)
        {
            return Ok(Order_DAL.GetOrderByCustId(Id));
        }

        [HttpGet]
        [Route("GetOrderByManegertId/{Id}")]
        //get
        public IHttpActionResult GetOrderByManegertId(int Id)
        {
            return Ok(Order_DAL.GetOrderByManegertId(Id));
        }

        [HttpPost]
        [Route("AddOrder")]
        //post
        public IHttpActionResult AddOrder([FromBody] Order_DTO o)
        {
            return Ok(Order_DAL.AddOrder(o));
        }

        [HttpPut]
        [Route("UpdateOrder")]
        //put
        public IHttpActionResult UpdateOrder([FromBody] Order_DTO o)
        {
            return Ok(Order_DAL.UpdateOrder(o));
        }

        [HttpDelete]
        [Route("DeleteOrder/{oId}")]
        //delete
        public IHttpActionResult DeleteOrder(int cId)
        {
            return Ok(Order_DAL.DeleteOrder(cId));
        }

    }
}
