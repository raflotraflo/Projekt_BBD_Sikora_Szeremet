using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_BBD_Sikora_Szeremet.Models
{
    public class VetMap : EntityTypeConfiguration<Vet>
    {
        public VetMap()
        {
            ToTable("Vets");

            HasKey(t => t.Id);
            Property(t => t.Name).IsOptional().HasMaxLength(50);
            Property(t => t.Surname).IsOptional().HasMaxLength(50);
            Property(t => t.Email).IsOptional().HasMaxLength(50);
            Property(t => t.PhoneNumber).IsOptional().HasMaxLength(50);
            Property(t => t.LicenceNo).IsOptional().HasMaxLength(50);

        }
    }
}
