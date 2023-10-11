using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classes2
{
    interface ISound
    {
        virtual public void makeSound() { }
    }

    public enum Gender
    {
        NotDeffined,
        Female,
        Male
    }

    public class Animal : ISound
    {
        protected string name;
        protected uint age;
        protected Gender gender;

        public Animal(string name, uint age, Gender gender)
        {
            if (name == null)
            {
                throw new ArgumentNullException("name is null");
            }

            this.name = name;
            this.age = age;
            this.gender = gender;
        }

        virtual public void makeSound()
        {
            Console.WriteLine("Not specifed");
        }

        public uint getAge()
        {
            return age;
        }

        public string getName()
        {
            return name;
        }
    }

    public class Cat : Animal
    {
        public Cat(string name, uint age, Gender gender) : base(name, age, gender) { }
        override public void makeSound()
        {
            Console.WriteLine("Meow-Meow");
        }
    }

    public class Kitten : Cat
    {
        public Kitten(string name, uint age) : base(name, age, Gender.Female)
        { }
    }

    public class Tomcat : Cat
    {
        public Tomcat(string name, uint age) : base(name, age, Gender.Male)
        { }
    }

    public class Frog : Animal
    {
        public Frog(string name, uint age, Gender gender) : base(name, age, gender) { }

        public override void makeSound()
        {
            Console.WriteLine("Kvak Kvak");
        }
    }

    public class Dog : Animal
    {
        public Dog(string name, uint age, Gender gender) : base(name, age, gender) { }

        public override void makeSound()
        {
            Console.WriteLine("Bau Bau");
        }
    }

    internal class AnimalHierachy
    {
        List<Animal> animals = new List<Animal>();

        public AnimalHierachy(List<Animal> animals)
        {
            if (animals == null)
            {
                throw new ArgumentNullException("The array was null");
            }

            this.animals = animals;
        }

        public void addAnimal(Animal toAdd)
        {
            if (toAdd == null)
            {
                throw new ArgumentNullException("The animal to be added was null");
            }

            animals.Append(toAdd);
        }

        public static void OrderBy(AnimalHierachy list)
        {
            IEnumerable<Animal> query = list.animals.OrderBy(Animal => Animal.getAge());

            foreach (Animal animal in query)
            {
                Console.WriteLine("{0}", animal.getName());
            }
        }
    }
}
