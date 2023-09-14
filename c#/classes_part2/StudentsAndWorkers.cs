using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace classes2
{
    //static double EPSILON = 0.0001;
    public class Human
    {
        protected string firstName;
        protected string lastName;

        public Human(string firstName, string lastName)
        {
            if (firstName == null || lastName == null)
            {
                throw new ArgumentNullException("Names can not be null");
            }

            this.firstName=firstName;
            this.lastName=lastName;
        }

        public static void OrderBy(List<Human> list)
        {
            IEnumerable<Human> query = list.OrderBy(Human => Human.firstName);

            foreach (Human human in query)
            {
                Console.WriteLine("{0} - {1}", human.firstName, human.lastName);
            }
        }

    }

    public class Student2 : Human
    {
        double grade;

        public Student2(string firstName, string lastName, double grade) : base(firstName, lastName) 
        {
            if (grade - 2 < 0.00001 || grade - 6 > 0.00001)
            {
                throw new ArgumentOutOfRangeException("Grade shoud be between 2 and 6 ");
            }

            this.grade = grade;
        }
        public static void OrderBy(List<Student2> list)
        {
            IEnumerable<Student2> query = list.OrderBy(Student2 => Student2.grade);

            foreach (Student2 student in query)
            {
                Console.WriteLine("{0} - {1}", student.firstName, student.lastName);
            }
        }
    }

    public class Worker : Human
    {
        double weekSalary;
        uint workHouresPerDay;

        public Worker(string firstName, string lastName, double weekSalary, uint workHouresPerDay) : base(firstName, lastName)
        {
            if (weekSalary < 0) 
            {
                throw new ArgumentOutOfRangeException("The salary should be positive number");
            }

            this.weekSalary = weekSalary;
            this.workHouresPerDay = workHouresPerDay;
        }

        public double moneyPerHour()
        {
            return weekSalary / workHouresPerDay;
        }
        public static void OrderBy(List<Worker> list)
        {
            IEnumerable<Worker> query = list.OrderBy(Worker => Worker.moneyPerHour());

            foreach (Worker worker in query)
            {
                Console.WriteLine("{0} - {1}", worker.firstName, worker.lastName);
            }
        }
    }

}
