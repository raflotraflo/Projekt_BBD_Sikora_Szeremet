using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_BBD_Sikora_Szeremet.Models
{
    public class Visit
    {
        public int Id { get; set; }
        public DateTime? Date { get; set; }
        public int Cost { get; set; }
        public string Description { get; set; }

        public Owner Owner { get; set; }
        public Vet Vet { get; set; }

    }
}
