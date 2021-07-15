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
        //[HttpPatch]
        //public IActionResult JsonPatchWithModelState([FromBody] JsonPatchDocument<Customer> patchDoc)
        //{
        //    if (patchDoc != null)
        //    {
        //        Customer customer = CreateCustomer();

        //        patchDoc.ApplyTo(customer, ModelState);

        //        if (!ModelState.IsValid)
        //        {
        //            return BadRequest(ModelState);
        //        }

        //        return new ObjectResult(customer);
        //    }
        //    else
        //    {
        //        return BadRequest(ModelState);
        //    }
        //}

        [HttpPatch]
        public IActionResult JsonPatchForDynamic([FromBody] JsonPatchDocument patch)
        {
            dynamic obj = new ExpandoObject();
            patch.ApplyTo(obj);

            return Ok(obj);
        }

        private Customer CreateCustomer()
        {

            List<Order> orderList = new List<Order>();
            orderList.Add(new Order { OrderName = "Kaffee", OrderType = "online" });
            orderList.Add(new Order { OrderName = "Wasser", OrderType = "online" });
            orderList.Add(new Order { OrderName = "Tee", OrderType = "online" });
            return new Customer { CustomerName = "Max Mustermann", Orders = orderList };
        }
    }
}
