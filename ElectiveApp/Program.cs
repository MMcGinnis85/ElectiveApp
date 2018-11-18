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
            //Hardcoded Data!

            Elective el = new Elective("ID", "Internet Development", 1, 25);
            ElectiveData.Add(el);
            Elective el1 = new Elective("SD", "Software Development", 10, 25);
            ElectiveData.Add(el1);
            Elective el2 = new Elective("IS", "Internet Systems", 10, 45);
            ElectiveData.Add(el2);
            Elective el3 = new Elective("IT", "Information Technology", 15, 55);
            ElectiveData.Add(el3);
            Student st1 = new Student("Tom","Williams","150150","08911111","IT","IS","2018");
            StudentData.Add(st1);
            Student st2 = new Student("Andy", "Mallow", "150151", "08711111", "IT", "ID", "2018");
            StudentData.Add(st2);
            Student st3 = new Student("Sarah", "Hardy", "150152", "08611111", "SD", "ID", "2018");
            StudentData.Add(st3);
           
            // --End of hardcoded data

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
                    case 2: //DISPLAY STUDENT OPTION             
                        DisplayStudents(StudentData);
                        break;
                    case 3: // DISPLAY K-NUMBERS BY ELECTIVE CHOICE
                        KElectivesChoice(StudentData, ElectiveData);
                        break;
                    case 4: //UPDATE ELECTIVE DETAILS FOR STUDENT
                        UpdateElective(StudentData);
                        break;
                    case 5: //ADD ELECTIVE
                       AddElective(ElectiveData);
                        break;
                    case 6: //MANAGEMENT MENU
                        DisplayElectivePop(StudentData, ElectiveData);
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
            Console.WriteLine("3. Display K-Numbers per Elective");
            Console.WriteLine("4. Update Electives");
            Console.WriteLine("5. Add an Elective.");
            Console.WriteLine("6. Management Menu ");
            Console.WriteLine("7. Exit");
         
        }

        private static void ManagerHeader()
        {
            Console.WriteLine("");
            Console.WriteLine("{0,80}", "//////The Manager Menu ////////");
            Console.WriteLine("1. Display Electives in Order of Popularity");
            Console.WriteLine("2. Combination of Electives selected by Students");
            Console.WriteLine("3. Students that have selected either elective");
            Console.WriteLine("4. Electives that failed to meet min places");
            Console.WriteLine("5. Electives that exceed Max number of places.");
            Console.WriteLine("6. Most popular elective combination");
            Console.WriteLine("7. Back to Main Menu ");
            Console.WriteLine("8. Exit");

        }

        private static void ManagerMenu(List<Person> StudentData, List<Elective> ElectiveData)
        {

            int option = 0;
            do
            {
                ManagerHeader();
                option = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                switch (option)
                {          //MENU OPTION
                    case 1://ADD STUDENT OPTION
                        AddStudent(StudentData, ElectiveData);
                        break;
                    case 2: //DISPLAY STUDENT OPTION             
                        DisplayStudents(StudentData);
                        break;
                    case 3: // DISPLAY K-NUMBERS BY ELECTIVE CHOICE
                        KElectives(StudentData, ElectiveData);
                        break;
                    case 4: //UPDATE ELECTIVE DETAILS FOR STUDENT
                        UpdateElective(StudentData);
                        break;
                    case 5: //ADD ELECTIVE
                        AddElective(ElectiveData);
                        break;
                    case 6: //MANAGEMENT MENU
                        DisplayElectivePop(StudentData, ElectiveData);
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

        public static void DisplayElectivePop(List<Person> StudentData, List<Elective> ElectiveData)
        {
            Dictionary<string, HashSet<string>> StudentElectives = new Dictionary<string, HashSet<string>>();
        

            foreach (Elective E in ElectiveData)

            {
                HashSet<string> tempSet = new HashSet<string>();
                StudentElectives.Add(E.nameCourse, tempSet);
            }

            foreach (Student s in StudentData)
            {

                StudentElectives[s.elective1].Add(s.Knumber);
                StudentElectives[s.elective2].Add(s.Knumber);
            }

            foreach (KeyValuePair<string, HashSet<string>> kvp in StudentElectives)
            {

                Console.WriteLine("Elective = {0}", kvp.Key);
                countSet(kvp.Value); 
            }

          
        }

        public static void countSet(HashSet<string> set)
        {
            Console.WriteLine(set.Count);
        }

        public static void ManagerData(List<Person> StudentData, List<Elective> ElectiveData)
        {

            Dictionary<string, HashSet<string>> StudentElectives = new Dictionary<string, HashSet<string>>();
            HashSet<string> Knumbers = new HashSet<string>();

            foreach (Elective E in ElectiveData)

            {
                HashSet<string> tempSet = new HashSet<string>();
                StudentElectives.Add(E.nameCourse, tempSet);


            }

            foreach (Student s in StudentData)
            {

                StudentElectives[s.elective1].Add(s.Knumber);
                StudentElectives[s.elective2].Add(s.Knumber);

            }

            
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
            if (ElectiveData.Exists(x => x.nameCourse.Contains(elective1)) && ElectiveData.Exists(x => x.nameCourse.Contains(elective2)) && elective1 != elective2)
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

            Dictionary<string, HashSet<string>> StudentElectives = new Dictionary<string, HashSet<string>>();
            HashSet<string> Knumbers = new HashSet<string>();

            foreach (Elective E in ElectiveData)

            {
                HashSet<string> tempSet = new HashSet<string>();
                StudentElectives.Add(E.nameCourse, tempSet);
            }

            foreach (Student s in StudentData)
            {
                StudentElectives[s.elective1].Add(s.Knumber);
                StudentElectives[s.elective2].Add(s.Knumber);
            }

            foreach (KeyValuePair<string, HashSet<string>> kvp in StudentElectives)
            {
                Console.WriteLine("Elective = {0}", kvp.Key);
                displaySet(StudentElectives[kvp.Key]);
            }
        }
        public static void KElectivesChoice(List<Person> StudentData, List<Elective> ElectiveData)
        {
            Dictionary<string, HashSet<string>> StudentElectives = new Dictionary<string, HashSet<string>>();

            Console.WriteLine(" Input an elective 1: ");
            string choice1 = Console.ReadLine();
            Console.WriteLine(" Input an elective 2: ");
            string choice2 = Console.ReadLine();

            foreach (Elective E in ElectiveData)

            {
                HashSet<string> tempSet = new HashSet<string>();
                StudentElectives.Add(E.nameCourse, tempSet);
            }

            foreach (Student s in StudentData)
            {
                if (StudentElectives[choice1].Contains(s.elective1) && StudentElectives[choice2].Contains(s.elective2))
                {
                    StudentElectives[s.elective1].Add(s.Knumber);
                    StudentElectives[s.elective2].Add(s.Knumber);
                }
            }

            foreach (KeyValuePair<string, HashSet<string>> kvp in StudentElectives)
            {
                Console.WriteLine("Elective = {0}", kvp.Key);
                displaySet(StudentElectives[kvp.Key]);
            }

        }

        public static void displaySet(HashSet<string> set)
        {
            Console.Write("{");
            foreach (string i in set)
                Console.Write(" {0}", i);

            Console.WriteLine(" }");
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


