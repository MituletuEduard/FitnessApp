using System.ComponentModel.DataAnnotations;

namespace FitnessApp.Models
{
    public class Utilizator
    {
        [Key]
        public int ID_Utilizator { get; set; }
        public string Nume { get; set; }
        public string EMail { get; set; }
        public string Gen { get; set; }

        public ICollection<Istoric> Istoric { get; set; }
        public Masuratori Masuratori { get; set; }
    }
}
