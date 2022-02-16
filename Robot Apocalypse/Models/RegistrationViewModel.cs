using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Robot_Apocalypse.Models
{
    public class RegistrationViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Food { get; set; }
        public string Water { get; set; }
        public string Medication { get; set; }
        public string Ammunition { get; set; }
    }
}
