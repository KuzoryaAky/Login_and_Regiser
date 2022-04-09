using Login_and_Regiser.PostgreSQLConnction;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using Login_and_Regiser.UsersFolder;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Login_and_Regiser
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }
        private void Reistration_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(@"C:\Firefox\Firefox\firefox.exe", "https://forum.new-sense.ru/register");
        }
        private void ForgotPass_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(@"C:\Firefox\Firefox\firefox.exe", "https://forum.new-sense.ru/lostpassword/");
        }
        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var users = await Task.Run(() => LoadUsersData());
                foreach (var user in users)
                    if (user.Name.Equals(TB_login.Text) && user.Password.Equals(PB_password.Password))
                        MessageBox.Show("Вы вошли");
            }
            
            SaveLoginPassInDB(TB_login.Text, PB_password.Password);
        }
        private List<User> LoadUsersData()
        {
            using (ApplicationContext db = new ApplicationContext())
                return db.users.ToList();
        }
        private void SaveLoginPassInDB(string log, string pas)
        {
            string login = log.Trim();
            string pass = pas.Trim();

            if (login.Length < 5)
            {
                BorderLogin.Background = Brushes.DarkRed;
                BorderPass.Background = Brushes.GhostWhite;
            }

            else if (pass.Length < 5)
            {
                BorderPass.Background = Brushes.DarkRed;
                BorderLogin.Background = Brushes.GhostWhite;
            }

            else
            {
                User user = new User()
                {
                    Name = login,
                    Password = pass
                };

                Users.users.Add(user);


                TB_login.ToolTip = "";
                BorderLogin.Background = Brushes.GhostWhite;
                PB_password.ToolTip = "";
                BorderPass.Background = Brushes.GhostWhite;

                CB_remember_Checked();

                MessageBox.Show("LogSave");
            }
        }
        private void TB_login_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e) => TB_login.Text = "";
        private void PB_password_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e) => PB_password.Password = ""; 
        private void CB_remember_Checked()
        {
            if (CB_remember.IsChecked == true)
            {
                using (ApplicationContext db = new())
                {
                    foreach (User u in Users.users)
                        db.users.Add(u);

                    db.SaveChanges();
                }
            }
        }
    }
}
