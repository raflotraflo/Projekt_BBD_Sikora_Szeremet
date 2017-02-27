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

        public virtual Owner Owner { get; set; }
        public int OwnerId { get; set; }
        public virtual Vet Vet { get; set; }
        public int VetId { get; set; }

    }
}
