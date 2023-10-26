using System;
using System.Collections.Generic;
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

namespace KamilSafiullin320_RaAndNuby.Pages
{
    /// <summary>
    /// Логика взаимодействия для AndreyInformationPage.xaml
    /// </summary>
    public partial class AndreyInformationPage : Page
    {
        public static List<Pet> pets {  get; set; }
        public AndreyInformationPage()
        {
            InitializeComponent();

            List<DB.Pet_name> pet_Names = new List<DB.Pet_name>(DbConnection.RaNuby_320_KamilEntities.Pet_name.ToList());

            pets = new List<Pet>(DbConnection.RaNuby_320_KamilEntities.Pet.ToList());
            this.DataContext = this;

            PetInfoLv.ItemsSource = pets;
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainMenuPage());
        }
    }
}
