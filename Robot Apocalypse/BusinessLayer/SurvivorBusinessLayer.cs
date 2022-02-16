using Robot_Apocalypse.Abstractions;
using Robot_Apocalypse.DataLayer.Entities;
using Robot_Apocalypse.Extensions;
using Robot_Apocalypse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Robot_Apocalypse.BusinessLayer
{
    public class SurvivorBusinessLayer
    {
        private readonly ISurvivorRepository<Survivor> _survivorRepository;
        private readonly IDataRepository<Location> _locationRepository;
        private readonly IDataRepository<ContaminationReport> _contaminationReportRepository;
        public SurvivorBusinessLayer(ISurvivorRepository<Survivor> survivorDataLayer, IDataRepository<Location> locationDataLayer, IDataRepository<ContaminationReport> contaminationReportDataLayer)
        {
            _survivorRepository = survivorDataLayer;
            _locationRepository = locationDataLayer;
            _contaminationReportRepository = contaminationReportDataLayer;
        }

        public List<SurvivorDetails> InfectedSurvivors()
        {
            var result = _survivorRepository.GetAllInfected().Select(survivor => survivor.ToSurvivorDetailsViewModel())?.ToList();
            return result;
        }

        public List<SurvivorDetails> NonInfectedSurvivors()
        {
            var result = _survivorRepository.GetAllNonInfected().Select(survivor => survivor.ToSurvivorDetailsViewModel())?.ToList();
            return result;
        }

        public string UpdateLocation(long survivorId, string latitude, string longitude)
        {
            try
            {
                var location = _locationRepository.Get(survivorId);

                var locationToUpdate = new Location
                {
                    Latitude = latitude,
                    Longitude = longitude
                };
                _locationRepository.Update(location, locationToUpdate);
                return "Updated Successfully";
            }
            catch (Exception)
            {

                throw;
            }
        }
        public string ReportContamination(ContaminationReportViewModel report)
        {
            var entity = report.ToContaminationReportEntity();
            var result = _contaminationReportRepository.Add(entity);
            
            return result == 0 ? "Already Reported":"Success";
        }

        public string InfectedPercentage()
        {
            var totalCount = _survivorRepository.TotalSurvivors();
            var infectedCount = _survivorRepository.Infected();
            decimal percentage = (infectedCount * 100) / totalCount;
            return $"{percentage.ToString("#.##") }%";
        }

        public string NonInfectedPercentage()
        {
            var totalCount = _survivorRepository.TotalSurvivors();
            var infectedCount = _survivorRepository.Infected();
            decimal infectedPercentage = (infectedCount * 100) / totalCount;
            decimal nonInfectedPercentage = 100 - infectedPercentage;

            return $"{nonInfectedPercentage.ToString("#.##")}%";
        }
    }
}
