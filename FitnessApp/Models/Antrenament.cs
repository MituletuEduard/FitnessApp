using System.ComponentModel.DataAnnotations;

namespace FitnessApp.Models
{
    public class Antrenament
    {
        [Key]
        public int ID_Antrenament { get; set; }
        public int ID_Istoric { get; set; }
        public string Antrenament_Descriere { get; set; }

        public ICollection<Exercitiu> Exercitii { get; set; }
        public Istoric Istoric { get; set; }
    }
}
