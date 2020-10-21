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

        public ICommand DeleteCommand { get; set; }
        public ICommand AddCommand { get; set; }

        public MainViewModel()
        {
            Persons = new ObservableCollection<Person>(DataBaseHandler.GetPersons());
            this.DeleteCommand = new DeleteCommand();
            this.AddCommand = new AddCommand();
        }

        #region addData

        private string _FirstName;
        private string _LastName;
        private string _MiddleName;
        private string _Sex;
        private string _Birthday;
        private string _HomeAdress;
        private string _Phone;
        private string _DateVisit;
        private string _TypeVisit;
        private string _Diagnosis;

        public string FirstName
        {
            get { return _FirstName; }
            set
            {
                _FirstName = value;
                RaisePropertyChanged("FirstName");
            }
        }
        public string LastName
        {
            get { return _LastName; }
            set
            {
                _LastName = value;
                RaisePropertyChanged("LastName");
            }
        }
        public string MiddleName
        {
            get { return _MiddleName; }
            set
            {
                _MiddleName = value;
                RaisePropertyChanged("MiddleName");
            }
        }
        public string Sex
        {
            get { return _Sex; }
            set
            {
                _Sex = value;
                RaisePropertyChanged("Sex");
            }
        }
        public string Birthday
        {
            get { return _Birthday; }
            set
            {
                _Birthday = value;
                RaisePropertyChanged("Birthday");
            }
        }
        public string HomeAdress
        {
            get { return _HomeAdress; }
            set
            {
                _HomeAdress = value;
                RaisePropertyChanged("HomeAdress");
            }
        }
        public string Phone
        {
            get { return _Phone; }
            set
            {
                _Phone = value;
                RaisePropertyChanged("Phone");
            }
        }

        public string DateVisit
        {
            get { return _DateVisit; }
            set
            {
                _DateVisit = value;
                RaisePropertyChanged("DateVisit");
            }
        }

        public string TypeVisit
        {
            get { return _TypeVisit; }
            set
            {
                _TypeVisit = value;
                RaisePropertyChanged("TypeVisit");
            }
        }

        public string Diagnosis
        {
            get { return _Diagnosis; }
            set
            {
                _Diagnosis = value;
                RaisePropertyChanged("Diagnosis");
            }
        }

        #endregion

    }
}
