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

namespace PasswordMeter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Input velden: userNameTextBox en passwordTextBox
        /// Output veld: resultTextBlock
        /// </summary>

        public MainWindow()
        {
            InitializeComponent();
        }

        private void passwordMeterButton_Click(object sender, RoutedEventArgs e)
        {

            int passwordStrenght = 4;
            StringBuilder error = new StringBuilder();

            string password = passwordTextBox.Text.Trim();
            string userName = userNameTextBox.Text.Trim();

            if (string.IsNullOrWhiteSpace(userName) ||
                string.IsNullOrWhiteSpace(password))
            {
                resultTextBlock.Text = "Username or password is empty";
                return;
            }
            else
            {
                if (password.Length < 10)
                {
                    //error.AppendLine("Password length is smaller then 10 characters");
                    passwordStrenght--;
                }

                bool hasUpper = false;
                bool hasLower = false;
                bool hasNumber = false;

                foreach (char c in password.ToCharArray())
                {
                    if (char.IsNumber(c))
                        hasNumber = true;
                    if (char.IsLower(c))
                        hasLower = true;
                    if (char.IsUpper(c))
                        hasUpper = true;
                }

                if (!hasUpper)
                {
                    //error.AppendLine("password has no uppercase");
                    passwordStrenght--;
                }
                if (!hasLower)
                {
                    //error.AppendLine("password has no lowercase");
                    passwordStrenght--;
                }
                if (!hasNumber)
                {
                    //error.AppendLine("password has no number");
                    passwordStrenght--;
                }

                switch (passwordStrenght)
                {
                    case 5:
                        resultTextBlock.Text = "Sterk password";
                        break;
                    case 4:
                        resultTextBlock.Text = "Goed password";
                        break;
                    default:
                        resultTextBlock.Text = "Zwak password";
                        break;
                }

                //resultTextBlock.Text = "Succesfull logged in";

            }



        }
    }
}
