using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;

namespace Patient.Models
{
    class VisitDoc : ViewModelBase
    {
        private string _DateVisit;
        private string _TypeVisit;
        private string _Diagnosis;

        public VisitDoc()
        {
            this.DateVisit = "";
            this.TypeVisit = "";
            this.Diagnosis = "";
        }

        public VisitDoc(string dateVisit, string typeVisit, string diagnosis)
        {
            this.DateVisit = dateVisit;
            this.TypeVisit = typeVisit;
            this.Diagnosis = diagnosis;
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

    }
}
