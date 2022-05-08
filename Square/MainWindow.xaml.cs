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

namespace Square
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public string Color { get; set; }
       // public string Warning { get; set; }
      //  public int Angle {
      //      get { return _angle; }
      //      set { _angle = value; } 
      //  }

        private int _angle;

        public event PropertyChangedEventHandler? PropertyChanged = delegate { };

        public MainWindow()
        {
            
            InitializeComponent();
            this.DataContext = this;
            Box.Width = this.Width/4;
            Color = "white";
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (int.TryParse(Box.Text, out _angle))
            {
                Angle.Angle = _angle;
                Warning.Content = String.Empty;
                Warning.Foreground = System.Windows.Media.Brushes.Red;
                Color = "black";
            }
            else
            {
                Box.BorderBrush = System.Windows.Media.Brushes.Red;
                Warning.Content = "Невалиден ъгъл";
                Color = "red";

            }
            RaisePropertyChanged("Color");
        }

        private void RaisePropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
