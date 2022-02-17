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
    [Route("api/survivor")]
    [ApiController]
    public class SurvivorController : ControllerBase
    {
        private readonly SurvivorBusinessLayer _survivorBusinessLayer;
        public SurvivorController(SurvivorBusinessLayer survivorBusinessLayer)
        {
            _survivorBusinessLayer = survivorBusinessLayer;
        }

        /// <summary>
        /// Get method for selecting all non infected survivors
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetNonInfectedSurvivors")]
        public IActionResult GetAllNonInfectedSurvivors()
        {
            var survivors = _survivorBusinessLayer.NonInfectedSurvivors();
            return Ok(survivors);
        }
        /// <summary>
        /// Get method for selecting all infected survivors
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetInfectedSurvivors")]
        public IActionResult GetAllInfectedSurvivors()
        {
            var survivors = _survivorBusinessLayer.InfectedSurvivors();
            if (survivors.Any())
            {
                return Ok(survivors);
            }
            return Ok("No infected survivors");
        }

        /// <summary>
        /// Get infected percentage
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetInfectedPercentage")]
        public IActionResult GetInfectedPercentage()
        {
            var result = _survivorBusinessLayer.InfectedPercentage();
            return Ok(result);
        }


        /// <summary>
        /// Get non infected percentage
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetNonInfectedPercentage")]
        public IActionResult GetNonInfectedPercentage()
        {
            var result = _survivorBusinessLayer.NonInfectedPercentage();
            return Ok(result);
        }

        /// <summary>
        /// Update location of a survivor
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [Route("UpdateLocation")]
        public IActionResult UpdateLocation(long survivorId, string latitude, string longitude)
        {
            try
            {
                var survivors = _survivorBusinessLayer.UpdateLocation(survivorId, latitude, longitude);
                return Ok(survivors);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message + e.InnerException.Message);
            }
        }

        /// <summary>
        /// Report Surviver as infected
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("ReportSurviverAsInfected")]
        public IActionResult ReportSurviverAsInfected(ContaminationReportViewModel report)
        {
            try
            {
                var result = _survivorBusinessLayer.ReportContamination(report);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message + e.InnerException.Message);
            }
        }
    }
}
