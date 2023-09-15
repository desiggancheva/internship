using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Reflection.Metadata.Ecma335;

namespace classes2
{
    public class Person
    {
        protected string fullName;

        public Person(string fullName)
        {
            if (fullName == null)
            {
                throw new ArgumentNullException();
            }

            this.fullName = fullName;
        }

        public virtual void print() { }
    }

    public class Discipline
    {
        string name;
        uint numberOfLeactures;
        uint numberOfExercises;

        public Discipline(string name, uint numberOfLeactures, uint numberOfExercises)
        {
            if (name == null)
            {
                throw new ArgumentNullException();
            }

            this.name = name;
            this.numberOfLeactures = numberOfLeactures;
            this.numberOfExercises = numberOfExercises;
        }

        public void printDiscipline()
        {
            Console.WriteLine("{0} {1} {2}", name, numberOfLeactures, numberOfExercises);
        }
    }

    public class Student : Person
    {
        ObjectIDGenerator idGenerator = new ObjectIDGenerator();
        //static int prevId;
        static Random rand = new Random();
        int id = rand.Next();

        public Student(string fullName) : base(fullName)
        {
         
        }

        public override void print() 
        {
           // bool boolen = (count < 1);
            Console.WriteLine(id);
            Console.WriteLine(fullName);
        }

    }

    public class Teacher : Person
    {
        Discipline[] disciplines = null;

        public Teacher(string fullName) : base(fullName) { }
        public Teacher(string name, Discipline[] disciplines) : base(name)
        {
            this.disciplines = disciplines; 
        }

        public void addDiscipline(Discipline toAdd)
        {
            if (toAdd == null)
            {
                throw new ArgumentNullException("the discipline to be added was null\n");
            }

            disciplines.Append(toAdd);
        }

        public override void print()
        {
            Console.WriteLine(fullName);
            Console.WriteLine("Teaching:");
            {
                if (disciplines == null) 
                {
                    Console.WriteLine("Nothing");
                }

                for (int i =0; i< disciplines.Length; i++)
                {
                    disciplines[i].printDiscipline();
                }
            }
        }
    }
    public class SchoolClass
    {
        Teacher[] teachers = null;
        Student[] students = null;

        public SchoolClass(Teacher[] teachers, Student[] students)
        {
            if (teachers == null || students == null) 
            { 
                throw new ArgumentNullException(); 
            }

            this.teachers = teachers;
            this.students = students;
        }

        public void addStudent(Student student)
        {
            if (student == null)
            {
                throw new ArgumentNullException("the student to be added was null\n");
            }

            students.Append(student);
        }
        public void addTeacher(Teacher teacher)
        {
            if (teacher == null)
            {
                throw new ArgumentNullException("the teacher to be added was null\n");
            }

            teachers.Append(teacher);
        }

        public void printSchoolCLass()
        {
            Console.WriteLine("Teachers:");
            for (int i = 0; i < teachers.Length; i++)
            {
                teachers[i].print();
            }

            Console.WriteLine("Student:");
            for (int i = 0; i < students.Length; i++)
            {
                students[i].print();
            }
        }
 
    }
    public class School
    {
        private SchoolClass[] schoolClasses = null;

        public School(SchoolClass[] schoolClasses)
        {
            if (schoolClasses == null)
            {
                throw new ArgumentNullException("the school Classes to be added was null\n");
            }

            this.schoolClasses = schoolClasses;
        }

        public School()
        { }

        public void addSchoolClass(SchoolClass schoolClass)
        {
            if (schoolClass == null)
            {
                throw new ArgumentNullException("The school class to be aded was null");
            }

            schoolClasses.Append(schoolClass);
        }

        public void printSchool()
        {
            if (schoolClasses == null)
            {
                Console.WriteLine("No classes yet");
            }

            for (int i = 0; i < schoolClasses.Length; i++)
            {
                schoolClasses[i].printSchoolCLass();
            }
        }
    }

}
