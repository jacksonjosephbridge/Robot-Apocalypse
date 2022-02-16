using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Robot_Apocalypse.DataLayer.Entities
{
    public class ContaminationReport
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int contaminationReportId { get; set; }
        public long? SurvivorId { get; set; }
        public long? ReporterId { get; set; }
    }
}
