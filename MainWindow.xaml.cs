using System.Diagnostics;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

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
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string login = TB_login.Text.Trim();
            string pass = PB_password.Password.Trim();

            if (login.Length < 5)
            {
                BorderLogin.Background = Brushes.DarkRed;
            }
            else if (pass.Length < 5)
            {
                BorderPass.Background = Brushes.DarkRed;
                BorderLogin.Background = Brushes.GhostWhite;
            }
            else
            {
                TB_login.ToolTip = "";
                BorderLogin.Background = Brushes.GhostWhite;
                PB_password.ToolTip = "";
                BorderPass.Background = Brushes.GhostWhite;

                MessageBox.Show("Ok");
            }

        }
        private void TB_login_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e) => TB_login.Text = "";
        private void PB_password_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e) => PB_password.Password = ""; 
    }
}
