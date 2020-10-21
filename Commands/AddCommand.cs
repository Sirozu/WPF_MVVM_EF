using Patient.Models;
using Patient.ViewModels;
using System;
using System.Windows;
using System.Windows.Input;

namespace Patient.Commands
{
    class AddCommand : ICommand
    {
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            if (parameter != null)
            {
                MainViewModel selected = parameter as MainViewModel;


                Person tmpObjPers = new Person(selected.FirstName, selected.LastName,
                    selected.MiddleName, selected.Sex, selected.Birthday, selected.HomeAdress,
                    selected.Phone, new VisitDoc(selected.DateVisit, selected.TypeVisit, selected.Diagnosis));
                selected.Persons.Add(tmpObjPers);

                selected.FirstName = "";
                selected.LastName = "";
                selected.MiddleName = "";
                selected.Sex = "";
                selected.Birthday = "";
                selected.HomeAdress = "";
                selected.Phone = "";
                selected.DateVisit = "";
                selected.TypeVisit = "";
                selected.Diagnosis = "";

                using (DataBase db = new DataBase())
                {
                    bool elExInColection = false;
                    var users = db.Persons;
                    Console.WriteLine("Список объектов:");
                    foreach (var u in users)
                    {
                        if (u.Equals(tmpObjPers))
                        {
                            elExInColection = true;
                            MessageBox.Show("Такой элемент уже существует");
                            return;
                        }
                    }

                    if (!elExInColection)
                    {
                        db.Persons.Add(tmpObjPers);
                        db.SaveChanges();
                    }
                }

            }
        }
    }
}
