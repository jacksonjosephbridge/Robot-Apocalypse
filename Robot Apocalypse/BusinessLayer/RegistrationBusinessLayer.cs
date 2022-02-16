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
    public class RegistrationBusinessLayer
    {
        private readonly ISurvivorRepository<Survivor> _survivorRepository;
        public RegistrationBusinessLayer(ISurvivorRepository<Survivor> survivorDataLayer)
        {
            _survivorRepository = survivorDataLayer;
        }
        public string RegisterSurvivor(RegistrationViewModel registration)
        {
            var survivor = registration.ToSurvivorEntity();
            var result = _survivorRepository.Add(survivor);
            
            return "Survivor registered successfully";
        }
    }
}
