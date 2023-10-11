using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace classes
{
    enum University
    {
        DefaultUniversity,
        SU,
        TU,
        NBU,
        NSA
    }

    enum Specialties
    {
        DefaultSpecialites,
        IS,
        Teacher,
        SI,
        Architecture
    }

    enum Faculties
    {
        DefaultFaculties,
        Phisic,
        Math
    }

    internal class Student : ICloneable
    {
        private string firstName = "";
        private string middleName = "";
        private string lastName = "";
        private string socialSecurityNumber = "";
        private string mobileNumber = "";
        private string email = "";

        University university = University.DefaultUniversity;
        Specialties specialties = Specialties.DefaultSpecialites;
        Faculties faculties = Faculties.DefaultFaculties;

        public Student(string firstName, string middleName, string lastName, string socialSecurityNumber, string mobileNumber, string email,
            University university, Specialties specialties, Faculties faculties)
        {
            this.firstName = firstName;
            this.middleName = middleName;
            this.lastName = lastName;
            this.socialSecurityNumber = socialSecurityNumber;
            this.mobileNumber = mobileNumber;
            this.email = email;
            this.university = university;
            this.specialties = specialties;
            this.faculties = faculties;
        }

        public Student(string firstName, string middleName, string lastName, string socialSecurityNumber)
        {
            this.firstName = firstName;
            this.middleName = middleName;
            this.lastName = lastName;
            this.socialSecurityNumber = socialSecurityNumber;
        }

        public Student(Student other)
        {

        }

        public override string ToString()
        {
            string result = firstName + " " + middleName + " " + lastName + " " + socialSecurityNumber + Environment.NewLine;

            return result;
        }

        public override int GetHashCode()
        {
            return socialSecurityNumber.GetHashCode();
        }

        public override bool Equals(object? obj)
        {
            return GetHashCode() == obj.GetHashCode();
        }

        public virtual object Cloning()
        {
            return new Student(this);
        }

        object ICloneable.Clone()
        {
            return Cloning();
        }
    }
    public class InvalidRangeException<T> : Exception
    {
        T start;
        T end;

        public InvalidRangeException(T start, T end) : base("Invalid rage exception occured")
        {
            this.start = start;
            this.end = end;
        }

        public T getStart()
        {
            return start;
        }

        public T getEnd()
        {
            return end;
        }
    }

    public class Person
    {
        private string name = "";
        private int? age = null;

        public Person(string name)
        {
            this.name = name;
        }

        public Person(string name, int age)
        {
            if (age < 0 || name == null)
            {
                throw new ArgumentException("Invalid input");
            }

            this.name = name;
            this.age = age;
        }

        public override string ToString()
        {
            string result = name + " ";

            if (age == null)
            {
                result += "unspecified age \n";
            }
            else
            {
                result += age.ToString();
            }

            return result;
        }
    }

    public class NodeOfInt
    {
        public int value;
        public NodeOfInt left = null;
        public NodeOfInt right = null;

        public NodeOfInt(int value)
        {
            this.value = value;
        }

        public void add(int newValue)
        {
            if (newValue.CompareTo(value) < 0)
            {
                if (left == null)
                {
                    left = new NodeOfInt(newValue);
                }
                else
                {
                    left.add(newValue);
                }
            }
            else
            {
                if (right == null)
                {
                    right = new NodeOfInt(newValue);
                }
                else
                {
                    right.add(newValue);
                }
            }
        }

        public class BinaryTree
        {
            public NodeOfInt root { get; private set; } = null!;

            public void Add(int value)
            {
                if (root == null)
                {
                    root = new NodeOfInt(value);
                }
                else
                {
                    root.add(value);
                }
            }
            public NodeOfInt Find(int value)
            {
                return this.Find(value, this.root);
            }
            private NodeOfInt Find(int value, NodeOfInt parent)
            {
                NodeOfInt toReturn = null;

                if (parent != null)
                {
                    if (value == parent.value)
                    {
                        toReturn = parent;
                    }

                    if (value < parent.value)
                    {
                        toReturn = Find(value, parent.left);
                    }
                    else
                    {
                        toReturn = Find(value, parent.right);
                    }
                }

                return toReturn;
            }


            public void Remove(int value)
            {
                this.root = Remove(this.root, value);
            }

            private NodeOfInt Remove(NodeOfInt parent, int key)
            {
                if (parent == null)
                {
                    return parent;
                }

                if (key < parent.value)
                {
                    parent.left = Remove(parent.left, key);
                }
                else if (key > parent.value)
                {
                    parent.right = Remove(parent.right, key);
                }
                else
                {
                    if (parent.left == null)
                    {
                        return parent.right;
                    }
                    else if (parent.right == null)
                    {
                        return parent.left;
                    }

                    parent.value = MinValue(parent.right);

                    parent.right = Remove(parent.right, parent.value);
                }

                return parent;
            }
            private int MinValue(NodeOfInt node)
            {
                int minv = node.value;

                while (node.left != null)
                {
                    minv = node.left.value;
                    node = node.left;
                }

                return minv;
            }

            private string toSting(NodeOfInt root)
            {
                if (root == null)
                {
                    return "";
                }

                toSting(root.left);
                toSting(root.right);

                return root.value.ToString();
            }

            public override string ToString()
            {
                return toSting(root);
            }
        }
    }

    static void Main(string[] args)
    {
        InvalidRangeException<int> intInvalidRAngeException = new InvalidRangeException<int>(0, 5);
        int a = 7;

        try
        {
            if (a < intInvalidRAngeException.getStart() || a > intInvalidRAngeException.getEnd())
            {
                throw intInvalidRAngeException;
            }

        }
        catch (InvalidRangeException<int> ex)
        {
            Console.WriteLine(ex.Message);
        }

        InvalidRangeException<DateTime> DateInvalidRAngeException = new InvalidRangeException<DateTime>(new DateTime(2023, 4, 24), new DateTime(2023, 4, 26));
        DateTime d = new DateTime(2023, 5, 24);

        try
        {
            if (d < DateInvalidRAngeException.getStart() || d > DateInvalidRAngeException.getEnd())
            {
                throw DateInvalidRAngeException;
            }

        }
        catch (InvalidRangeException<DateTime> ex)
        {
            Console.WriteLine(ex.Message);
            Console.WriteLine("date");
        }
    }
}