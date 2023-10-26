using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using KamilSafiullin320_RaAndNuby.DB;
using Microsoft.Win32;
using static System.Net.Mime.MediaTypeNames;

namespace KamilSafiullin320_RaAndNuby.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainMenuPage.xaml
    /// </summary>
    public partial class MainMenuPage : Page
    {
        public static DB.Pet pet = new DB.Pet();
        public MainMenuPage()
        {
            InitializeComponent();
            List<DB.Pet_name> pet_Names = new List<DB.Pet_name>(DbConnection.RaNuby_320_KamilEntities.Pet_name.ToList());
            PetNameCb.ItemsSource = pet_Names;
            PetNameCb.DisplayMemberPath = "Name";
        }

        private void AddPetPhotoBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Filter = "*.png|*.png|*.jpeg|*.jpeg|*.jpg|*.jpg"
            };
            if (openFileDialog.ShowDialog().GetValueOrDefault())
            {
                pet.Photo = File.ReadAllBytes(openFileDialog.FileName);
                PetImage.Source = new BitmapImage(new Uri(openFileDialog.FileName));
            }
        }

        private void AddPetBtn_Click(object sender, RoutedEventArgs e)
        {
            if (PetNameCb.SelectedItem == null || PetDescriptionTb.Text == String.Empty || PetImage.Source == null)
            {
                MessageBox.Show("Заполните все поля!");
            }
            else
            {
                var namePet = (DB.Pet_name)PetNameCb.SelectedItem;
                pet.Description = PetDescriptionTb.Text;
                pet.Id_pet_name = namePet.Id_pet_name;

                DbConnection.RaNuby_320_KamilEntities.Pet.Add(pet);
                DbConnection.RaNuby_320_KamilEntities.SaveChanges();

                MessageBox.Show("Информация загружена!");

                PetDescriptionTb.Text = null;
                PetNameCb.SelectedItem = null;
                PetImage.Source = null;
            }
        }

        private void ListBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AndreyInformationPage());
        }
    }
}
