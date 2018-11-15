using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectiveApp 
{
    class Elective
    {
  

        public string nameCourse { get; set; }
        public string descriptionCourse { get; set; }
        public int minNum{ get; set; }
        public int maxNum { get; set; }

        public Elective()
        {
            nameCourse = "";
            descriptionCourse = "";
            minNum = 0;
            maxNum = 0;

        }

        public Elective (string Name, string Description ,int MinNum, int MaxNum)
            {
            this.nameCourse = Name;
            this.descriptionCourse = Description;
            this.minNum = MinNum;
            this.maxNum = MaxNum;
        }

        public void ShowElectives()

        {
            Console.WriteLine("{0,10} {1,30} {2,10} {3,10} ", "COURSE CODE", "DESCRIPTION", "MIN PLACES", "MAX PLACES");
            Console.WriteLine("{0,10} {1,30} {2,10} {3,10}", nameCourse, descriptionCourse, minNum, maxNum);

        }

       

    }
}
