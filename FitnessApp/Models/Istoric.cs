using System.ComponentModel.DataAnnotations;

namespace FitnessApp.Models
{
    public class Istoric
    {
        [Key]
        public int ID_Istoric { get; set; }
        public int ID_Utilizator { get; set; }
        public int ID_Antrenament { get; set; }

        public Utilizator Utilizator { get; set; }
        public Antrenament Antrenament { get; set; }
    }

}
