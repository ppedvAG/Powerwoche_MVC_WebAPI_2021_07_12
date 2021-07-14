using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCOREMVC.Controllers
{
    public class ActionFilterSampleController : Controller
    {
        [Authorize("Read")]
        public IActionResult Read()
        {
            return View();
        }

        [Authorize("Write")]
        public IActionResult Edit()
        {
            return View();
        }
    }
}
