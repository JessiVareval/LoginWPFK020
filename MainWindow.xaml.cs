using LoginWPFK020.Negocio;
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

namespace LoginWPFK020
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private LoginService login = new LoginService();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void loginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = usernameTexbox.Text;
            string password = passwordTextbox.Password;

            if(login.CheckContraBaseDatos(username, password) )
            {
                //salidaLabel.Content = "Usuario Logeado";
                //MessageBox.Show("Exito!", "Usuario Logeado");
                
                VentanaPrincipal ventanaPrincipal = new VentanaPrincipal();
                ventanaPrincipal.Show();
                this.Close();

                //this.Hide(); //ocultar

            }
            else
            {
                MessageBox.Show("Error de Login", "Usuario o Password Incorrecto");
                //salidaLabel.Content = "Usuario o Password Incorrectos";
            }

        }
    }
}
