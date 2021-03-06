﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_BBD_Sikora_Szeremet.Models
{
    public class Owner
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public virtual List<Animal> Animals { get; set; }

        public override string ToString()
        {

            return Name + " " + Surname;
        }
    }
}
