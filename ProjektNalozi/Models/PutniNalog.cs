using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjektNalozi.Models
{
    public class PutniNalog
    {
        [Key]
        public int PutniNalogId { get; set; }


        [Required(ErrorMessage = "Obavezan podatak")]
        [Column(TypeName = "nvarchar(100)")]
        [Display(Name = "Razlog Putovanja")]
        public string RazlogPutovanja { get; set; }


        [Required(ErrorMessage = "Obavezan podatak")]
        public DateTime Polazak { get; set; }


        [Required(ErrorMessage = "Obavezan podatak")]
        public DateTime Povratak { get; set; }


        [Required(ErrorMessage = "Obavezan podatak")]
        [Display(Name = "Broj Putnika")]
        public int BrojPutnika { get; set; }



        [Required(ErrorMessage = "Obavezan podatak")]
        [Column(TypeName = "nvarchar(20)")]
        [Display(Name = "Polazište")]
        public string Polaziste { get; set; }


        [Required(ErrorMessage = "Obavezan podatak")]
        [Column(TypeName = "nvarchar(200)")]
        [Display(Name = "Odredište")]
        public string Odrediste { get; set; }


        public string Prijevoz { get; set; }


        [Column(TypeName = "varchar(8)")]
        [Display(Name = "Registracija Vozila")]
        public string RegistracijaVozila { get; set; }


        [Column(TypeName = "nvarchar(200)")]
        [StringLength(200,ErrorMessage ="Maksimalan broj znakova za komentar je 200!")]
        public string Komentar { get; set; }


        [Required(ErrorMessage = "Obavezan podatak")]
        [Column(TypeName = "nvarchar(50)")]
        public string Email { get; set; }

        public IEnumerable<Putnik> Putnici { get; set; }
        public ICollection<PutnikovNalog> PutnikoviNalozi { get; set; }
    }
}
