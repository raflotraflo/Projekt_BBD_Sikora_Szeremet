using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_BBD_Sikora_Szeremet.Models
{
    public class VisitMap : EntityTypeConfiguration<Visit>
    {
        public VisitMap()
        {
            ToTable("Visits");

            HasKey(t => t.Id);
            Property(t => t.Date).IsOptional();
            Property(t => t.Cost).IsRequired();
            Property(t => t.Description).IsOptional().HasMaxLength(150);

            Property(t => t.OwnerId).IsOptional();
            HasOptional(p => p.Owner).WithMany().HasForeignKey(x => x.OwnerId).WillCascadeOnDelete(false);

            Property(t => t.VetId).IsOptional();
            HasOptional(p => p.Vet).WithMany().HasForeignKey(x => x.VetId).WillCascadeOnDelete(false);

            Property(t => t.AnimalId).IsOptional();
            HasOptional(p => p.Animal).WithMany().HasForeignKey(x => x.AnimalId).WillCascadeOnDelete(false);

        }
    }
}
