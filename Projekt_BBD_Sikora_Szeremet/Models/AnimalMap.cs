using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_BBD_Sikora_Szeremet.Models
{
    public class AnimalMap : EntityTypeConfiguration<Animal>
    {
        public AnimalMap()
        {
            ToTable("Animals");

            HasKey(t => t.Id);
            Property(t => t.Name).IsOptional().HasMaxLength(50);
            Property(t => t.Breed).IsOptional().HasMaxLength(20);
            Property(t => t.DateOfBirth).IsOptional();

            HasRequired<Owner>(s => s.Owner) // Student entity requires Standard 
                .WithMany(s => s.Animals) // Standard entity includes many Students entities
                .HasForeignKey(s => s.OwnerId);
        }
    }
}
