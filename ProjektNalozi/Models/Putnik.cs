using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjektNalozi.Models
{
    public class Putnik
    {
        [Key]
        public int PutnikId { get; set; }


        [Required(ErrorMessage = "Obavezan podatak")]
        [Column(TypeName ="nvarchar(20)")]
        public string Ime { get; set; }


        [Required(ErrorMessage = "Obavezan podatak")]
        [Column(TypeName = "nvarchar(20)")]
        public string Prezime { get; set; }
               

        public IEnumerable<PutniNalog> PutniNalozi { get; set; }
        public ICollection<PutnikovNalog> PutnikoviNalozi { get; set; }
    }
}