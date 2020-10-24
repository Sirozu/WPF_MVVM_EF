using DevExpress.Mvvm;
using Patient.Commands;
using Patient.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Patient.ViewModels
{
    class MainViewModel : ViewModelBase
    {

        public ObservableCollection<Person> Persons { get; set; }
        public Person SelectedPerson { get; set; }
        public Person Person { get; set; }

        public ICommand DeleteCommand { get; set; }
        public ICommand AddCommand { get; set; }

        public MainViewModel()
        {
            Persons = new ObservableCollection<Person>(DataBaseHandler.GetPersons());
            this.DeleteCommand = new DeleteCommand();
            this.AddCommand = new AddCommand();
            Person = new Person();
        }

    }
}
