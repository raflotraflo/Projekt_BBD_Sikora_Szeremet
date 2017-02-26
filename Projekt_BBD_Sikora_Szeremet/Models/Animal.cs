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
        public int? AddressId { get; set; }
        public string Breed { get; set; }
    }
}
