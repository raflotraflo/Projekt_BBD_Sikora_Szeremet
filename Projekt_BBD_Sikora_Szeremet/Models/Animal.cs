using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_BBD_Sikora_Szeremet.Models
{
    public class Animal 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Breed { get; set; }

        public virtual Owner Owner { get; set; }
        public int OwnerId { get; set; }

        public override string ToString()
        {

            return Name;
        }
    }
}
