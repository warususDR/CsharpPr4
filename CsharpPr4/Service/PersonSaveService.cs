using CsharpPr4.Repository;
using PracticeDateHandling.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CsharpPr4.Service
{
    class PersonSaveService
    {
        private static PersonRepository Repository = new PersonRepository();

        public List<Person> getAllPersons()
        {
            var res = new List<Person>();

            foreach(var person in Repository.GetAll())
            {
                res.Add(new Person(person.Name, person.Surname, person.Email, person.Birthday));
            }

            return res;
        }

        public void AddUpdatePerson(Person p)
        {
            Repository.AddOrUpdate(p);
        }

        public void DeletePerson(string email)
        {
            try
            {
                Repository.Delete(email);
            }
            catch (FileNotFoundException)
            {
                throw new FileNotFoundException();
            }
        }
    }
}
