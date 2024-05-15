using System.ComponentModel.DataAnnotations;

namespace FitnessApp.Models
{
    public class Masuratori
    {
        [Key]
        public int ID_Masuratori { get; set; }
        public int Greutate { get; set; }
        public int ID_Utilizator { get; set; }

        public Utilizator Utilizator { get; set; }
    }
}
