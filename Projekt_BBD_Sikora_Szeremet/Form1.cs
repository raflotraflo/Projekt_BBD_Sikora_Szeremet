using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Projekt_BBD_Sikora_Szeremet.Models;
using Projekt_BBD_Sikora_Szeremet.Repository;

namespace Projekt_BBD_Sikora_Szeremet
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            try
            {
                GetData();
                labelConnectionStatus.Text = "Połączono";
            }
            catch (Exception)
            {
                labelConnectionStatus.Text = "Error";
            }
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            try
            {
                GetData();
                labelConnectionStatus.Text = "Połączono";
            }
            catch (Exception)
            {
                labelConnectionStatus.Text = "Error";
            }    
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void GetData()
        {
            RepositoryContext db = new RepositoryContext("RepositoryContext");

            AnimalRepository animalRepo = new AnimalRepository(db);
            OwnerRepository ownerRepo = new OwnerRepository(db);
            VetRepository vetRepo = new VetRepository(db);
            VisitRepository visitRepo = new VisitRepository(db);

            var animalList = animalRepo.All().ToList();

            dataGridViewAnimals.DataSource = animalList;
            //comboBoxAnimals.DataSource = animalList;


            var ownerList = ownerRepo.All().ToList();

            dataGridViewOwners.DataSource = ownerList;
            comboBoxOwnerList.DataSource = ownerList;
            comboBoxOwnersFromVisit.DataSource = ownerList;


            var vetList = vetRepo.All().ToList();

            dataGridViewVets.DataSource = vetList;
            comboBoxVets.DataSource = vetList;

            var visitList = visitRepo.All().ToList();

            dataGridViewVisits.DataSource = visitList;

            db.Dispose();
        }

        #region Vet

        private void AddNewVet_Click(object sender, EventArgs e)
        {
            Vet newVet = new Vet
            {
                Name = textBoxVetName.Text,
                Surname = textBoxVetSurname.Text,
                LicenceNo = textBoxVetLicenceNo.Text,
                Email = textBoxVetEmail.Text,
                PhoneNumber = textBoxVetPhoneNumber.Text
            };

            textBoxVetName.Text = "";
            textBoxVetSurname.Text = "";
            textBoxVetLicenceNo.Text = "";
            textBoxVetEmail.Text = "";
            textBoxVetPhoneNumber.Text = "";

            using (RepositoryContext db = new RepositoryContext("RepositoryContext"))
            {
                VetRepository vetRepo = new VetRepository(db);

                var vet = vetRepo.Add(newVet);
                vetRepo.SaveChanges();
            }


            GetData();
        }

        private void buttonDeleteVet_Click(object sender, EventArgs e)
        {
            if (dataGridViewVets.CurrentRow == null)
                return;

            var selectedVet = (Vet) dataGridViewVets.CurrentRow.DataBoundItem;

            using (RepositoryContext db = new RepositoryContext("RepositoryContext"))
            {
                VetRepository vetRepo = new VetRepository(db);

                var vet = vetRepo.GetById(selectedVet.Id);
                vetRepo.Delete(vet);
                vetRepo.SaveChanges();
            }


            GetData();
        }

        #endregion


        #region Owner

        private void buttonAddNewOwner_Click(object sender, EventArgs e)
        {
            Owner newOwner = new Owner
            {
                Name = textBoxOwnerName.Text,
                Surname = textBoxOwnerSurname.Text,
                Email = textBoxOwnerEmail.Text,
                PhoneNumber = textBoxOwnerPhoneNumber.Text
            };

            textBoxOwnerName.Text = "";
            textBoxOwnerSurname.Text = "";
            textBoxOwnerEmail.Text = "";
            textBoxOwnerPhoneNumber.Text = "";

            using (RepositoryContext db = new RepositoryContext("RepositoryContext"))
            {
                OwnerRepository ownerRepo = new OwnerRepository(db);

                var owner = ownerRepo.Add(newOwner);
                ownerRepo.SaveChanges();
            }


            GetData();
        }


        private void buttonDeleteOwner_Click(object sender, EventArgs e)
        {
            if (dataGridViewOwners.CurrentRow == null)
                return;

            var selectedOwner = (Owner) dataGridViewOwners.CurrentRow.DataBoundItem;

            using (RepositoryContext db = new RepositoryContext("RepositoryContext"))
            {
                OwnerRepository ownerRepo = new OwnerRepository(db);

                var ovner = ownerRepo.GetById(selectedOwner.Id);
                ownerRepo.Delete(ovner);
                ownerRepo.SaveChanges();
            }

            GetData();
        }


        private void dataGridViewOwners_SelectionChanged(object sender, EventArgs e)
        {
            DataGridView dataGrid = (DataGridView) sender;

            if(dataGrid.CurrentRow == null)
                return;

            var selectedOwner = (Owner)dataGrid.CurrentRow.DataBoundItem;

            dataGridViewOwnerAnimals.DataSource = selectedOwner.Animals;
        }

        #endregion


        #region Animal

        private void buttonAddNewAnimal_Click(object sender, EventArgs e)
        {
            if (comboBoxOwnerList.SelectedItem == null)
                return;

            int ownerId = ((Owner) comboBoxOwnerList.SelectedItem).Id;

            Animal newAnimal = new Animal
            {
                Name = textBoxAnimalName.Text,
                Breed = textBoxAnimalBreed.Text,
                DateOfBirth = dateTimePickerAnimalDate.Value,
                OwnerId = ownerId
            };

            textBoxAnimalName.Text = "";
            textBoxAnimalBreed.Text = "";
            dateTimePickerAnimalDate.Text = "";

            using (RepositoryContext db = new RepositoryContext("RepositoryContext"))
            {
                OwnerRepository ownerRepo = new OwnerRepository(db);
                AnimalRepository animalRepo = new AnimalRepository(db);

                var owner = ownerRepo.GetById(ownerId);
                newAnimal.Owner = owner;

                var animal = animalRepo.Add(newAnimal);
                animalRepo.SaveChanges();
            }


            GetData();
        }

        private void buttonDeleteAnimal_Click(object sender, EventArgs e)
        {
            if (dataGridViewAnimals.CurrentRow == null)
                return;

            var selectedOwner = (Animal) dataGridViewAnimals.CurrentRow.DataBoundItem;

            using (RepositoryContext db = new RepositoryContext("RepositoryContext"))
            {
                AnimalRepository animalRepo = new AnimalRepository(db);

                var animal = animalRepo.GetById(selectedOwner.Id);
                animalRepo.Delete(animal);
                animalRepo.SaveChanges();
            }

            GetData();
        }


        #endregion


        #region Visit

        private void comboBoxOwnersFromVisit_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cm = (ComboBox) sender;

            if (cm.SelectedItem == null)
                return;

            var owner = (Owner) cm.SelectedItem;

            labelSelectedOwner.Text = owner.ToString();

            comboBoxAnimals.DataSource = owner.Animals;
        }

        private void buttonAddVisit_Click(object sender, EventArgs e)
        {
            if (comboBoxVets.SelectedItem == null
                || comboBoxOwnersFromVisit.SelectedItem == null
                || comboBoxAnimals.SelectedItem == null)
            {
                return;
            }


            int ownerId = ((Owner) comboBoxOwnersFromVisit.SelectedItem).Id;
            int vetId = ((Vet) comboBoxVets.SelectedItem).Id;
            int animalId = ((Animal) comboBoxAnimals.SelectedItem).Id;

            int cost = 0;
            try
            {
                cost = Int32.Parse(textBoxVisitCost.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Zły format ceny");
            }


            Visit newVisit = new Visit
            {
                Description = textBoxVisitDescription.Text,
                Cost = cost,
                Date = dateTimePickerAnimalDate.Value,
                OwnerId = ownerId,
                VetId = vetId,
                AnimalId = animalId
            };

            textBoxVisitDescription.Text = "";
            textBoxVisitCost.Text = "";
            dateTimePickerVisitData.Text = "";

            using (RepositoryContext db = new RepositoryContext("RepositoryContext"))
            {
                AnimalRepository animalRepo = new AnimalRepository(db);
                OwnerRepository ownerRepo = new OwnerRepository(db);
                VetRepository vetRepo = new VetRepository(db);
                VisitRepository visitRepo = new VisitRepository(db);

                var owner = ownerRepo.GetById(ownerId);
                var vet = vetRepo.GetById(vetId);
                var animal = animalRepo.GetById(animalId);

                newVisit.Owner = owner;
                newVisit.Vet = vet;
                newVisit.Animal = animal;

                var visit = visitRepo.Add(newVisit);
                visitRepo.SaveChanges();
            }


            GetData();
        }

        private void buttonDeleteVisit_Click(object sender, EventArgs e)
        {
            if (dataGridViewVisits.CurrentRow == null)
                return;

            var selectedVisit = (Visit)dataGridViewVisits.CurrentRow.DataBoundItem;

            using (RepositoryContext db = new RepositoryContext("RepositoryContext"))
            {
                VisitRepository visitRepo = new VisitRepository(db);

                var visit = visitRepo.GetById(selectedVisit.Id);
                visitRepo.Delete(visit);
                visitRepo.SaveChanges();
            }

            GetData();
        }


        #endregion

    }
}
