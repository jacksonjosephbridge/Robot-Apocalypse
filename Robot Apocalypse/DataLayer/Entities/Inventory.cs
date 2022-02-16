using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Robot_Apocalypse.DataLayer.Entities
{
    public class Inventory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int InventoryId { get; set; }
        [ForeignKey("Survivor")]
        public long SurvivorId { get; set; }
        public string Food { get; set; }
        public string Water { get; set; }
        public string Medication { get; set; }
        public string Ammunition { get; set; }
        public virtual Survivor Survivor { get; set; }
    }
}
