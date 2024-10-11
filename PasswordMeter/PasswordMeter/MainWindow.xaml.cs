using Microsoft.VisualBasic;
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


                //create passWord deel 2

                StringBuilder sb = new StringBuilder();
                Random rand = new Random();

                for (int i = 0; i < 5; i++)
                {
                    int startIndex = rand.Next(0, userName.Length - 1);

                    string letter = userName.Substring(startIndex, 1);
                    sb.Append(letter);

                }

                for (int i = 0; i < 5; i++)
                {
                    sb.Append(rand.Next(9).ToString());
                }

                for (int i = 0; i < 2; i++)
                {
                    var nRand = rand.Next(0, userName.Length - 1);
                    sb.Append(userName.Substring(nRand, 1).ToUpper());
                }

                for (int i = 0; i < rand.Next(0, 6); i++)
                {
                    sb.Append("!");
                }

                string wachtwoord = sb.ToString();
                //MessageBoxResult result = MessageBox.Show($"Zwak wachtwoord: {wachtwoord}", "Wilt je dit wachtwoord gebruiken", MessageBoxButton.YesNo, MessageBoxImage.Question);

                //if (result == MessageBoxResult.Yes)
                //{
                //    resultTextBlock.Text = wachtwoord;
                //}
                //else
                //{
                //    //resultTextBlock.Text = $"";
                //}

                string input = Interaction.InputBox("Reset wachtwoord", "Reset?", wachtwoord);

                if (!string.IsNullOrEmpty(input))
                {
                    password = input;
                    passwordTextBox.Text = password;
                }




            }



        }
    }
}
