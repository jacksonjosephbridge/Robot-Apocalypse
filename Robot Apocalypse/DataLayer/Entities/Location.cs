using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Robot_Apocalypse.DataLayer.Entities
{
    public class Location
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LocationId { get; set; }
        [ForeignKey("Survivor")]
        public long SurvivorId { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public virtual Survivor Survivor { get; set; }
    }
}
