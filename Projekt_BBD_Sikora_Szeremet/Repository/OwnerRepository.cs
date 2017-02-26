using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projekt_BBD_Sikora_Szeremet.Models;

namespace Projekt_BBD_Sikora_Szeremet.Repository
{
    public class OwnerRepository : RepositoryBase<Owner>
    {
        public OwnerRepository(RepositoryContext context) : base(context)
        {
        }
    }
}
