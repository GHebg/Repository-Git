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
    [RoutePrefix("api/Customer")]
    public class CustomerController : ApiController
    {
        [HttpGet]
        [Route("GetAllCustomers")]
        //get
        public IHttpActionResult GetAllCustomers()
        {
            return Ok(Customer_DAL.GetAllCustomers());
        }

        [HttpGet]
        [Route("GetCustomerById/{Id}")]
        //get
        public IHttpActionResult GetCustomerById(int Id)
        {
            return Ok(Customer_DAL.GetCustomerById(Id));
        }

        [HttpGet]
        [Route("GetCustomersByUserId/{Id}")]
        //get
        public IHttpActionResult GetCustomersByUserId(int Id)
        {
            return Ok(Customer_DAL.GetCustomersByUserId(Id));
        }

        [HttpPost]
        [Route("AddCustomer")]
        //post
        public IHttpActionResult AddCustomer([FromBody] Customer_DTO c)
        {
            return Ok(Customer_DAL.AddCustomer(c));
        }

        [HttpPut]
        [Route("UpdateCustomers")]
        //put
        public IHttpActionResult UpdateCustomers([FromBody] Customer_DTO c)
        {
            return Ok(Customer_DAL.UpdateCustomers(c));
        }

        [HttpDelete]
        [Route("DeleteCustomer/{id}")]
        //delete
        public IHttpActionResult DeleteCustomer(int id)
        {
            return Ok(Customer_DAL.DeleteCustomer(id));
        }

    }
}
