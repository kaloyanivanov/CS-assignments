using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ExpenseIt
{
    /// <summary>
    /// Interaction logic for ExpenseItHome.xaml
    /// </summary>
    public partial class ExpenseItHome : Window, INotifyPropertyChanged
    {
        public string MainCaptionText { get; set; }
        public List<Person> ExpenseDataSource { get; set; }

        public ObservableCollection<string> PersonsChecked
        { get; set; }

        private DateTime lastChecked;
        public DateTime LastChecked
        {
            get { return lastChecked; }
            set
            {
                lastChecked = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;


        public ExpenseItHome()
        {
            InitializeComponent();
            PersonsChecked = new ObservableCollection<string>();
            LastChecked = DateTime.Now;
            this.DataContext = this;
            MainCaptionText = "View Expense Report :";
            ExpenseDataSource = new List<Person>()
            {
                 new Person()
                 {
                 Name="Mike",
                 Department ="Legal",
                 Expenses = new List<Expense>()
                 {
                 new Expense() { ExpenseType="Lunch", ExpenseAmount =50 },
                 new Expense() { ExpenseType="Transportation", ExpenseAmount=50 }
                 }
                 },
                 new Person()
                 {
                 Name ="Lisa",
                 Department ="Marketing",
                 Expenses = new List<Expense>()
                 {
                 new Expense() { ExpenseType="Document printing", ExpenseAmount=50 },
                 new Expense() { ExpenseType="Gift", ExpenseAmount=125 }
                 }
                 },
                 new Person()
                 {
                 Name="John",
                 Department ="Engineering",
                 Expenses = new List<Expense>()
                 {
                 new Expense() { ExpenseType="Magazine subscription", ExpenseAmount=50 },
                 new Expense() { ExpenseType="New machine", ExpenseAmount=600 },
                 new Expense() { ExpenseType="Software", ExpenseAmount=500 }
                 }
                 },
                 new Person()
                 {
                 Name="Mary",
                 Department ="Finance",
                 Expenses = new List<Expense>()
                 {
                 new Expense() { ExpenseType="Dinner", ExpenseAmount=100 }
                 }
                 },
                 new Person()
                 {
                 Name="Theo",
                 Department ="Marketing",
                 Expenses = new List<Expense>()
                 {
                 new Expense() { ExpenseType="Dinner", ExpenseAmount=100 }
                 }
                 },
                 new Person()
                 {
                 Name="James",
                 Department ="Legal",
                 Expenses = new List<Expense>()
                 {
                 new Expense() { ExpenseType="Lunch", ExpenseAmount=100 }
                 }
                 },
                                  new Person()
                 {
                 Name="David",
                 Department ="Engineering",
                 Expenses = new List<Expense>()
                 {
                 new Expense() { ExpenseType="Document printing", ExpenseAmount=50 }
                 }
                 }
                 };

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ExpenseReport reportWindow = new ExpenseReport(peopleListBox.SelectedItem);
            reportWindow.Height = this.Height;
            reportWindow.Width = this.Width;
            reportWindow.ShowDialog();
        }

        private void peopleListBox_SelectionChanged_1(object sender,SelectionChangedEventArgs e)

        {
            LastChecked =DateTime.Now;
            Person selectedItem = (Person) peopleListBox.SelectedItem;
            PersonsChecked.Add(selectedItem.Name);
        }

        protected void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
