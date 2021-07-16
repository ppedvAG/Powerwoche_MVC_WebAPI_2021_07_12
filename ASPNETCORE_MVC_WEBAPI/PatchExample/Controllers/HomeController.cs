using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using PatchExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatchExample.Controllers
{
    [Route("jsonpatch/[action]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public IActionResult JsonPatchWithModelState()
        {
            var customer = CreateCustomer();
            return new ObjectResult(customer);
        }

        [HttpPatch]
        public IActionResult JsonPatchWithModelState(
            [FromBody] JsonPatchDocument<Customer> patchDoc)
        {
            if (patchDoc != null)
            {
                var customer = CreateCustomer();

                patchDoc.ApplyTo(customer, ModelState);

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                return new ObjectResult(customer);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

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
