using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Windows;

namespace Patient.Models
{
    class DataBase : DbContext, IDisposable
    {
        public DataBase() : base(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Документы\Visual Studio 2019\Project\Patient\Patient\Data\UsersData.mdf;Integrated Security=True")
        {

        }

        public DbSet<Person> Persons { get; set; }

    }

    class DataBaseHandler
    {

        public static IEnumerable<Person> GetPersons()
        {
            List<Person> listPersonFromDB = new List<Person>();
            using (DataBase db = new DataBase())
            {
                
                var users = db.Persons;
                Console.WriteLine("Список объектов:");
                foreach (var u in users)
                {
                    listPersonFromDB.Add(
                        new Person(u.FirstName, u.LastName, u.MiddleName,
                        u.Sex, u.Birthday, u.HomeAdress, u.Phone, 
                        new VisitDoc(u.Visit.DateVisit, u.Visit.TypeVisit, u.Visit.Diagnosis)));

                }
               
            }

            return listPersonFromDB;

        }
    }
}
