using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Projekt_BBD_Sikora_Szeremet.Repository;

namespace Projekt_BBD_Sikora_Szeremet
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            RepositoryContext db = new RepositoryContext(@"Data Source=RCHODZIDLO--AK\SQLEXPRESS;Initial Catalog=bbd;Integrated Security=True");
            
            AnimalRepository animalRepo = new AnimalRepository(db);
            OwnerRepository ownerRepo = new OwnerRepository(db);
            VetRepository vetRepo = new VetRepository(db);
            VisitRepository visitRepo = new VisitRepository(db);

            var animal = animalRepo.All().ToList();

            var owner = ownerRepo.All().ToList();

            var vet = vetRepo.All().ToList();

            var visit = visitRepo.All().ToList();

            //_userRepository = new ContractorRepository(db);
            // _addressRepository = new AddressRepository(db);
            //Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }
    }
}
