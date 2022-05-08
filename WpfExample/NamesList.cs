using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WpfExample
{
    public class NamesList : INotifyPropertyChanged
    {
        string _firstName = "";
        string _lastName = "";
        string _selectedName;
        
        AddCommand _addNameCommand = new AddCommand();
        RemoveCommand _removeNameCommand = new RemoveCommand();

        public NamesList()
        {
            Names = new ObservableCollection<string>();
        }
        public string FirstName
        {
            get { return _firstName; }
            set
            {
                if (_firstName != value)
                {
                    _firstName = value;
                    OnPropertyChanged();

                }
            }
        }
        public string LastName
        {
            get { return _lastName; }
            set
            {
                if (_lastName != value)
                {
                    _lastName = value;
                    OnPropertyChanged();
                }
            }
        }
        public string SelectedName
        {
            get { return _selectedName; }
            set
            {
                if (_selectedName != value)
                {
                    _selectedName = value;
                    OnPropertyChanged();
     //               _removeNameCommand.CanExecute(this);
                }
            }
        }

        private void _removeNameCommand_CanExecuteChanged(object? sender, EventArgs e)
        {

        }

        public ObservableCollection<string> Names { get; private set; }

        public AddCommand AddNameCommand
        {
            get { return _addNameCommand; }
        }

        public RemoveCommand RemoveNameCommand 
        { 
            get { return _removeNameCommand; } 
        }

        protected void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
