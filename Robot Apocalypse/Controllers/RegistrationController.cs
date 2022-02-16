using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Robot_Apocalypse.BusinessLayer;
using Robot_Apocalypse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Robot_Apocalypse.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly RegistrationBusinessLayer _registrationBusinessLayer;
        public RegistrationController(RegistrationBusinessLayer registrationBusinessLayer)
        {
            _registrationBusinessLayer = registrationBusinessLayer;
        }

        /// <summary>
        /// To register a survivor
        /// </summary>
        /// <remarks>
        /// Test
        /// </remarks>
        /// <param name="registrationViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Registration(RegistrationViewModel registrationViewModel)
        {
            var result = _registrationBusinessLayer.RegisterSurvivor(registrationViewModel);
            return Ok(result);
        }
    }
}
