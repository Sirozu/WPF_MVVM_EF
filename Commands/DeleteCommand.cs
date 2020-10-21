using Patient.Models;
using Patient.ViewModels;
using System;
using System.Data.Entity;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace Patient.Commands
{
    class DeleteCommand : ICommand
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
                if (selected.SelectedPerson != null)
                {
                    Person tmpPerson = new Person(selected.SelectedPerson); 
                    selected.Persons.Remove(tmpPerson);

                    using (DataBase db = new DataBase())
                    {
                        bool elExInColection = true;
                        var users = db.Persons;
                        Console.WriteLine("Список объектов:");
                        foreach (var u in users)
                        {
                            //if (u.Equals(tmpPerson))
                            //{
                            //    elExInColection = false;
                            //    MessageBox.Show("Такого элемента не существует");
                            //    return;
                            //}
                        }

                        if (elExInColection)
                        {

                            bool oldValidateOnSaveEnabled = db.Configuration.ValidateOnSaveEnabled;

                            try
                            {
                                db.Configuration.ValidateOnSaveEnabled = false;

                                if (tmpPerson != null)
                                {
                                    var deletedCustomer = db.Persons.Where(c => c.Phone == tmpPerson.Phone).FirstOrDefault();
                                    db.Persons.Remove(deletedCustomer);
                                    db.SaveChanges();


                                }

                            }
                            finally
                            {
                                db.Configuration.ValidateOnSaveEnabled = oldValidateOnSaveEnabled;
                            }
                        }
                    }
                }
            }
        }

    }
}