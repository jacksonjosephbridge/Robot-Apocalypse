using Robot_Apocalypse.DataLayer.Entities;
using Robot_Apocalypse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Robot_Apocalypse.Extensions
{
    public static class ModelHelpers
    {
        // Extension for mapping registrationViewModel to Survivor Entity
        public static Survivor ToSurvivorEntity(this RegistrationViewModel registration)
        {
            return new Survivor
            {
                FirstName = registration.FirstName,
                LastName = registration.LastName,
                Age = registration.Age,
                Gender = registration.Gender,
                Inventory = new Inventory
                {
                    Food = registration.Food,
                    Water = registration.Water,
                    Medication = registration.Medication,
                    Ammunition = registration.Ammunition
                },
                Location = new Location
                {
                    Latitude = registration.Latitude,
                    Longitude = registration.Longitude
                }
            };
        }
        //Extension method fro mapping Survivor Entity to SurvivorDetails ViewModel
        public static SurvivorDetails ToSurvivorDetailsViewModel(this Survivor survivor)
        {
            return new SurvivorDetails
            {
                FirstName = survivor.FirstName,
                LastName = survivor.LastName,
                Age = survivor.Age,
                Gender = survivor.Gender
            };
        }

        public static ContaminationReport ToContaminationReportEntity(this ContaminationReportViewModel contaminationReportViewModel)
        {
            return new ContaminationReport
            {
               ReporterId = contaminationReportViewModel.ReporterId,
               SurvivorId = contaminationReportViewModel.SurviverId
            };
        }
    }
}
