using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectiveApp
{
 
    class Program
    {
        static void Main(string[] args)
        {
         
            Console.BackgroundColor = ConsoleColor.White;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Black;
            List<Person> StudentData = new List<Person>();
            List<Elective> ElectiveData = new List<Elective>();
            

            int option = 0;
            do
            {
                MenuHeader();
                option = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                switch (option)
                {          //MENU OPTION
                    case 1://ADD STUDENT OPTION
                        AddStudent(StudentData, ElectiveData);
                        break;
                    case 2: //DISPLAY OPTION             
                        DisplayStudents(StudentData);
                        break;
                    case 3: // Display list of Knumber’s per elective.
                        DisplayElectives(ElectiveData);
                        break;
                    case 4: //UPDATE BOOK DETAILS
                        AddElective(ElectiveData);
                        break;
                    case 5: //DELETE BOOK DETAILS
                        UpdateElective(StudentData);
                        break;
                    case 6: //SORT BY ISBN OPTION
                        KElectives(StudentData, ElectiveData);
                        break;
                    case 7: //EXIT
                        break;
                    default:
                        {
                            Console.WriteLine("Option not implemented");
                            break;
                        }
                }
            } while (option != 7);


        }
        private static void MenuHeader()
        {
            Console.WriteLine("");
            Console.WriteLine("{0,80}", "//////The Book Application Menu ////////");
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. List of students");
            Console.WriteLine("3. Display Electives");
            Console.WriteLine("4. Add Electives");
            Console.WriteLine("5. Update Electives");
            Console.WriteLine("6. Sort by ISBN ");
            Console.WriteLine("7. Exit");
         
        }

        public static void DisplayStudents(List<Person> StudentData)
        {
            {

                foreach (Person a in StudentData)
                {
                    a.ShowDetails();

                }
            }
        }

        public static void DisplayElectives(List<Elective> ElectiveData)
        {
            {

                foreach (Elective a in ElectiveData)
                {
                    a.ShowElectives();
                    
                }
            }
        }
        public static void AddStudent(List<Person> StudentData, List<Elective> ElectiveData)
        {
            //Takes in data from User
            Console.WriteLine("Enter first name ");
            string firstName = Console.ReadLine();
            Console.WriteLine("Enter a surname : ");
            string surname = Console.ReadLine();
            Console.WriteLine("Enter K-Number: ");
            string Knumber = (Console.ReadLine());
            Console.WriteLine("Enter contact number: ");
            string ContactNumber = (Console.ReadLine());
            Console.Clear();
            DisplayElectives(ElectiveData);
            Console.WriteLine("Enter Elective choice 1");
            string elective1 = (Console.ReadLine());
            Console.WriteLine("Enter Elective choice 2: ");
            string elective2 = (Console.ReadLine());
            Console.WriteLine("Enter the year of Reg: ");
            string yearReg = (Console.ReadLine());
            if (ElectiveData.Exists(x => x.nameCourse.Contains(elective1)) && ElectiveData.Exists(x => x.nameCourse.Contains(elective2)))
            {
                Student st1 = new Student(firstName, surname, Knumber, ContactNumber, elective1, elective2, yearReg);
                StudentData.Add(st1);

            }
            else if (!ElectiveData.Exists(x => x.nameCourse.Contains(elective1)))
            {
                Console.WriteLine("{0}" + " DOES NOT EXIST", elective1);
                AddStudent(StudentData, ElectiveData);
            }

            else
            {
                Console.WriteLine("{0}" + " ELECTIVE DOES NOT EXIST", elective2);
                AddStudent(StudentData, ElectiveData);
            }
        }

        public static void AddElective(List<Elective> ElectiveData)
        {

            Console.WriteLine("Enter course code ");
            string code = Console.ReadLine();
            Console.WriteLine("Enter a description of course : ");
            string description = Console.ReadLine();
            Console.WriteLine("Enter the min number of places: ");
            int minNum = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Max Number of places: ");
            int maxNum = Convert.ToInt32(Console.ReadLine());
   

            Elective el1 = new Elective(code, description,minNum,maxNum);
            ElectiveData.Add(el1);


        }

        public static Person SearchKnum(List<Person> StudentData, string Knum)
        {
            {
                Person x = null;
                foreach (Person a in StudentData)
                {
                    if (a.Knumber.Equals(Knum))
                    {
                        return a;
                    }

                }
                return x;
            }

        }
        public static void KElectives(List<Person> StudentData, List<Elective> ElectiveData)
        {
            
            var commons = StudentData.Select(s => s.elective1).ToList().Intersect(ElectiveData.Select(s2 => s2.nameCourse).ToList()).ToList();


        }

        public static void UpdateElective(List<Person> StudentData)
        {
            Console.WriteLine("Enter k-number to search :");
            string Knum = Console.ReadLine();
            Person st = SearchKnum(StudentData, Knum);
            Student x1 = (Student)st;
            if (st != null )
            {
                st.ShowDetails();
                Console.WriteLine("Enter new Elective Choice 1: ");
                string newElective1 = (Console.ReadLine());
                Console.WriteLine("Enter new Elective Choice 2: ");
                string newElective2 = (Console.ReadLine());
                x1.UpdateElectives(newElective1, newElective2);
            }




        }

       
    }
}


