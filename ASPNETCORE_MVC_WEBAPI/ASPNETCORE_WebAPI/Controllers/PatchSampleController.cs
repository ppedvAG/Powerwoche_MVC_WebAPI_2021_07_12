using ASPNETCORE_WebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCORE_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatchSampleController : ControllerBase
    {
        [HttpPatch]
        public IActionResult JsonPatchWithModelState([FromBody] JsonPatchDocument<Customer> patchDoc)
        {
            if (patchDoc != null)
            {
                Customer customer = CreateCustomer();

                //customer wird auf attribut ebene manipliert (add/remove/replace/move) 
                patchDoc.ApplyTo(customer, ModelState);

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                //Hier kann man den Datensatz mit EFCore als Update verarbeiten 

                return new ObjectResult(customer);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpGet]
        public IActionResult JsonPatchWithModelState()
        {
            var customer = CreateCustomer();
            return new ObjectResult(customer);
        }

        //[HttpPatch]
        //public IActionResult JsonPatchForDynamic([FromBody] JsonPatchDocument patch)
        //{
        //    dynamic obj = new ExpandoObject();
        //    patch.ApplyTo(obj);

        //    return Ok(obj);
        //}

        private Customer CreateCustomer()
        {
            return new Customer
            {
                CustomerName = "John",
                Orders = new List<Order>()
                {
                    new Order
                    {
                        OrderName = "Order0"
                    },
                    new Order
                    {
                        OrderName = "Order1"
                    }
                }
            };
        }
    }
}
