using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectiveApp
{
    class Student: Person
    {
        public string elective1 { get; set; }
        public string elective2 { get; set; }
        public string yearReg {get; set;}

        public Student() : base()
        {
            elective1 = "";
            elective2 = "";
            yearReg = "";
        }

        public Student(string firstName, string surname, string Knumber, string ContactNumber, string elective1, string elective2, string yearReg) : base(firstName, surname, Knumber, ContactNumber)
        {
            this.elective1 = elective1;
            this.elective2 = elective2;
            this.yearReg = yearReg;

        }
        public override void ShowDetails()

        {
            Console.WriteLine("{0,10} {1,10} {2,10} {3,10} {4,10} {5,10} {6,10} ", "FIRSTNAME", "SURNAME", "KNUMBER", "CONTACTNO", "CHOICE 1", "CHOICE 2", "YEAR OF REG");
            Console.WriteLine("{0,10} {1,10} {2,10} {3,10} {4,10} {5,10} {6,10} ", firstName, surname, Knumber, ContactNumber, elective1, elective2, yearReg);

        }

        public virtual void UpdateStudent(string firstName, string surname, string Knumber, string ContactNumber, string elective1, string elective2, string yearReg)
        {
            base.UpdateStudent(firstName, surname, Knumber, ContactNumber);
            this.elective1 = elective1;
            this.elective2 = elective2;
            this.yearReg = yearReg;
        }

        public void UpdateElectives(string newElective1, string newElective2)
        {
            this.elective1 = newElective1;
            this.elective2 = newElective2;
        }
    }
}
