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
    /// Логика взаимодействия для AuthorizationPage.xaml
    /// </summary>
    public partial class AuthorizationPage : Page
    {
        public static List<User> users { get; set; }
        public AuthorizationPage()
        {
            InitializeComponent();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            string login = loginTb.Text.Trim();
            string password = passwordPb.Password.Trim();

            users = new List<User>(DbConnection.RaNuby_320_KamilEntities.User.ToList());
            User currentUser = users.FirstOrDefault(i => i.Login == login && i.Password == password);
            if (currentUser != null && currentUser.Id_user == 1)
            {
                MessageBox.Show($"Успешно, {currentUser.Name}!");
                NavigationService.Navigate(new MainMenuPage());
            }
            else if (currentUser != null && currentUser.Id_user == 2)
            {
                MessageBox.Show($"Успешно, {currentUser.Name}!");
                NavigationService.Navigate(new MainMenuPage());
            }
            else
            {
                MessageBox.Show("Повторите попытку!");
                loginTb.Text = string.Empty;
                passwordPb.Password = string.Empty;
            }
        }
    }
}
