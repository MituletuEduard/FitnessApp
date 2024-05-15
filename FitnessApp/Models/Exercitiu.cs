using System.ComponentModel.DataAnnotations;
namespace FitnessApp.Models
{
    public class Exercitiu
    {
        [Key]
        public int ID_Exercitiu { get; set; }
        public int ID_Antrenament { get; set; }
        public int Nr_Repetari { get; set; }
        public int Greutate_Adaugata { get; set; }

        public Antrenament Antrenament { get; set; }
    }
}
