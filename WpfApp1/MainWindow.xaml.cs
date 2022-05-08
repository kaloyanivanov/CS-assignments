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
using System.Data;
using System.Data.SqlClient;

namespace StudentInfoSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Student student {
            get { return student; }
            set { student = value;
                PrintOutStudent();

            }
        }
        public List<string> StudStatusChoices { get; set; }
        public MainWindow()
        {
            StudStatusChoices = new List<string>();
            FillStudStatusChoices();
            if (TestStudentsIfEmpty()) CopyTestStudents();
            this.DataContext = this;
            InitializeComponent();
        }


        private void PrintOutStudent()
        {
            if(student == null)
            {
                CleanAll();
                BlockControls();
            }
            else
            {
                ActivateControls();
                PrintStudent(student);
            }
        }

        private void CleanAll()
        {
            Name.Text = "";
            Surname.Text = "";
            Family.Text = "";
            Faculty.Text = "";
            Speciality.Text = "";
            Degree.Text = "";
            FacNum.Text = "";
            Course.Text = "";
            Stream.Text = "";
            Course.Text = "";
        }

        public void PrintStudent(Student student)
        {
            Name.Text = student.Name;
            Surname.Text = student.Surname;
            Family.Text = student.Family;
            Faculty.Text = student.Faculty;
            Speciality.Text = student.Speciality;
            Degree.Text = student.Degree;
            FacNum.Text = student.FacNum;
            Course.Text = student.Course.ToString();
            Stream.Text = student.Stream.ToString();
            Course.Text = student.Course.ToString();
            Group.Text = student.Group.ToString();
        }


        private void BlockControls()
        {
            Name.IsEnabled=false;
            Surname.IsEnabled = false;
            Family.IsEnabled = false;
            Faculty.IsEnabled = false;
            Speciality.IsEnabled = false;
            Degree.IsEnabled = false;
            Status.IsEnabled = false;
            FacNum.IsEnabled = false;
            Course.IsEnabled = false;
            Stream.IsEnabled = false;
            Course.IsEnabled = false;
        }

        private void ActivateControls()
        {
            Name.IsEnabled = true;
            Surname.IsEnabled = true;
            Family.IsEnabled = true;
            Faculty.IsEnabled = true;
            Speciality.IsEnabled = true;
            Degree.IsEnabled = true;
            Status.IsEnabled = true;
            FacNum.IsEnabled = true;
            Course.IsEnabled = true;
            Stream.IsEnabled = true;
            Course.IsEnabled = true;
        }

        private void TestClick(object sender, RoutedEventArgs e)
        {
            StudentData studentData = new StudentData();
            PrintStudent(studentData.TestStudents[0]);
        }

        public void HideButton()
        {
            TestButton.Visibility = Visibility.Collapsed;
        }

        private void FillStudStatusChoices()
        {
            using (IDbConnection connection = new SqlConnection(Properties.Settings.Default.DbConnect))
            {
                string sqlquery =
                @"SELECT StatusDescr FROM StudStatus";
                IDbCommand command = new SqlCommand();
                command.Connection = connection;
                connection.Open();
                command.CommandText = sqlquery;
                IDataReader reader = command.ExecuteReader();
                bool notEndOfResult;
                notEndOfResult = reader.Read();
                while (notEndOfResult)

                {
                    string s = reader.GetString(0);
                    StudStatusChoices.Add(s);
                    notEndOfResult = reader.Read();
                }
            }
        }

        private bool TestStudentsIfEmpty()
        {
            StudentInfoContext context = new StudentInfoContext();
            IEnumerable<Student> queryStudents = context.Students;
            int countStudents = queryStudents.Count();
            MessageBox.Show(countStudents.ToString());
            if(countStudents != 0) return false;
            return true;
        }

        private void CopyTestStudents()
        {
            StudentInfoContext context = new StudentInfoContext();
            StudentData studentData = new StudentData();
            foreach (Student st in studentData.TestStudents)
            {
                context.Students.Add(st);
            }
            context.SaveChanges();
        }
    }
}
