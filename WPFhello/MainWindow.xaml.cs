using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace WPFhello
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ListBoxItem james = new ListBoxItem();
            james.Content = "James";
            james.FontSize = 18;
            peopleListBox.Items.Add(james);
            ListBoxItem david= new ListBoxItem();
            david.Content = "David";
            david.FontSize = 18;
            peopleListBox.Items.Add(david);
            peopleListBox.SelectedItem = james;
        }

        private void btnHello_Click(object sender, RoutedEventArgs e)
        {
            if(txtName.Text.Length >= 2&& txtName1.Text.Length >= 2&& txtName2.Text.Length >= 2)
            {
                string names = new("");
                foreach (var item in MainGrid.Children)
                {
                    if (item is TextBox)
                    {
                        names = names + ((TextBox)item).Text + ' ';
                    }
                }
                names = names.TrimEnd();
                MessageBox.Show("Здравейте " + names + "!!! Това е вашата първа програма на VisualStudio 2012!");
            }
            else
            {
                MessageBox.Show("Дължината и на трите имена тябва да е поне два символа.\n Опитайте отново!");
            }
        }

        private void btnFactorial_Click(object sender, RoutedEventArgs e)
        {
            ulong num;
            if(ulong.TryParse(n.Text,out num))
            {
                blockResult.Text= multiplyNumbers(num).ToString();
            }
            else
            {
                MessageBox.Show("Моля въведете валидна стойност за N!");
            }
        }

        private void btnDegree_Click(object sender, RoutedEventArgs e)
        {
            double num,pow;
            if (double.TryParse(n.Text, out num))
            {
                if (double.TryParse(y.Text, out pow))
                {
                    blockResult.Text = Math.Pow(num,pow).ToString();
                }
                else
                {
                    MessageBox.Show("Моля въведете валидна стойност за Y!");
                }
            }
            else
            {
                MessageBox.Show("Моля въведете валидна стойност за N!");
            }
        }


        private ulong multiplyNumbers(ulong n)
        {
            if (n >= 1)
                return n * multiplyNumbers(n - 1);
            else
                return 1;
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            string msg = "Сигурни ли сте, че искате да затворите приложението?";
            MessageBoxResult result =
              MessageBox.Show(
                msg,
                "Приложение",
                MessageBoxButton.YesNo,
                MessageBoxImage.Warning);
            if (result == MessageBoxResult.No)
            {
                e.Cancel = true;
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MyMessage anotherWindow = new MyMessage();
            anotherWindow.Show();
        }

        private void Button_Greeting(object sender, RoutedEventArgs e)
        {
            string greetingMsg;
            greetingMsg = (peopleListBox.SelectedItem as ListBoxItem).Content.ToString();
            MessageBox.Show("Hi " + greetingMsg);
        }
    }
}
