using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Robot_Apocalypse.DataLayer.Entities
{
    public class Survivor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long SurviverId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public virtual Location Location { get; set; }
        public virtual Inventory Inventory { get; set; }
        [ForeignKey("ReportedId")]
        public ICollection<ContaminationReport> ReportedCases { get; set; }
        [ForeignKey("SurvivorId")]
        public ICollection<ContaminationReport> ReportedBy { get; set; }
    }
}
