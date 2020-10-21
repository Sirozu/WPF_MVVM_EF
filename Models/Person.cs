using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Patient.Models
{
    class Person : ViewModelBase
    {
        public Person()
        {
            this.FirstName = "";
            this.LastName = "";
            this.MiddleName = "";
            this.Sex = "";
            this.Birthday = "";
            this.HomeAdress = "";
            this.Phone = "";

            this.Visit = new VisitDoc("", "", "");
        }

        public Person(string firstName, string lastName,
string middleName, string sex, string birthday, string homeAdress, string phone)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.MiddleName = middleName;
            this.Sex = sex;
            this.Birthday = birthday;
            this.HomeAdress = homeAdress;
            this.Phone = phone;

            this.Visit = new VisitDoc("", "", "");
        }

        public Person(string firstName, string lastName,
string middleName, string sex, string birthday, string homeAdress, string phone, VisitDoc visit)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.MiddleName = middleName;
            this.Sex = sex;
            this.Birthday = birthday;
            this.HomeAdress = homeAdress;
            this.Phone = phone;

            this.Visit = visit;
        }

        public Person(Person selectedPerson)
        {
            this.FirstName = selectedPerson.FirstName;
            this.LastName = selectedPerson.LastName;
            this.MiddleName = selectedPerson.MiddleName;
            this.Sex = selectedPerson.Sex;
            this.Birthday = selectedPerson.Birthday;
            this.HomeAdress = selectedPerson.HomeAdress; 
            this.Phone = selectedPerson.Phone;
            this.Visit = new VisitDoc(selectedPerson.Visit.DateVisit,
                selectedPerson.Visit.TypeVisit,
                selectedPerson.Visit.Diagnosis);
        }

        private string _FirstName;
        private string _LastName;
        private string _MiddleName;
        private string _Sex;
        private string _Birthday;
        private string _HomeAdress;
        private string _Phone;
        private VisitDoc _Visit;

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

        [Key]
        public string Phone
        {
            get { return _Phone; }
            set
            {
                _Phone = value;
                RaisePropertyChanged("Phone");
            }
        }

        [ForeignKey("")]
        public VisitDoc Visit
        {
            get { return _Visit; }
            set
            {
                _Visit = value;
                RaisePropertyChanged("Visit");
            }
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName} " +
                $"{MiddleName} {Sex} {Birthday} " +
                $"{HomeAdress} {Phone} {Visit.DateVisit} " +
                $"{Visit.TypeVisit} {Visit.Diagnosis}";
        }

        public override bool Equals(object obj)
        {
            
            Person person = obj as Person;
            if (person == null) return false;

            return this.FirstName == person.FirstName &&
            this.LastName == person.LastName &&
            this.MiddleName == person.MiddleName &&
            this.Sex == person.Sex &&
            this.Birthday == person.Birthday &&
            this.HomeAdress == person.HomeAdress &&
            this.Phone == person.Phone &&
            this.Visit.DateVisit == person.Visit.DateVisit &&
            this.Visit.TypeVisit == person.Visit.TypeVisit &&
            this.Visit.Diagnosis == person.Visit.Diagnosis;
        }
    }
}
