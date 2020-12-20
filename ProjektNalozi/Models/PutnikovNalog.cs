using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjektNalozi.Models
{
    public class PutnikovNalog
    {
        
        public int PutnikId { get; set; }
        public Putnik Putnik { get; set; }
        public int PutniNalogId { get; set; }
        public PutniNalog PutniNalog { get; set; }
    }
}
