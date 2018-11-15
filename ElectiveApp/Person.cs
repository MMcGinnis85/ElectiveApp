using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectiveApp
{


    public abstract class Person
    {

        public string firstName { get; set; }
        public string surname { get; set; }
        public string Knumber { get; set; }
        public string ContactNumber { get; set; }

        protected Person()
        {
        }

        protected Person(string firstName, string surname, string knumber, string contactNumber)
        {
            this.firstName = firstName;
            this.surname = surname;
            this.Knumber = knumber;
            this.ContactNumber = contactNumber;
        }
        public void Persons()
        {
            firstName = "";
            surname = "";
            Knumber = "";
            ContactNumber = "";
        }

        public abstract void ShowDetails();

        public void Persons(string firstName, string surname, string Knumber, string ContactNumber)
        {
            this.firstName = firstName;
            this.surname = surname;
            this.Knumber = Knumber;
            this.ContactNumber = ContactNumber;
        }

        public virtual void UpdateStudent(string newfirstName, string newsurname, string newKnumber, string newContactNumber)
        {
            this.firstName = newfirstName;
            this.surname = newsurname;
            this.Knumber = newKnumber;
            this.ContactNumber = newContactNumber;
        }
    }
}

