using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using classes2;

namespace Nunit
{
    [TestFixture]
    internal class Nunit
    {
        [TestCase]
        public void testConstructorAnimal()
        {
            string name = "bella";
            uint age = 2;

            Cat c = new Cat(name, age, Gender.male);

            Assert.AreEqual(c.name, name);
            Assert.AreEqual(c.age, age);
            Assert.AreEqual(c.gender, Gender.male); 
        }

        [TestCase]
        public void testConstructorKitten()
        {
            string name = "bella";
            uint age = 2;

            Kitten c = new Kitten(name, age);

            Assert.AreEqual(c.name, name);
            Assert.AreEqual(c.age, age);
            Assert.AreEqual(c.gender, Gender.female);
        }

        [TestCase]
        public void testCalculateSurfaceTriangle()
        {
            uint width = 2;
            uint height = 2;

            double surface = width * height / 2;

            Triangle tr = new Triangle(width, height);

            Assert.AreEqual(surface, tr.calculateSurface());
        }

        [TestCase]
        public void testCalculateSurfaceRectangle()
        {
            uint width = 2;
            uint height = 2;

            double surface = width * height;

            Rectangle r = new Rectangle(width, height);

            Assert.AreEqual(surface, r.calculateSurface());
        }

        [TestCase]
        public void testCalculateSurfaceSquere()
        {
            uint width = 2;
            
            double surface = width * width;

            Square s = new Square(width);

            Assert.AreEqual(surface, s.calculateSurface());
        }

        [TestCase]
        public void addAnimalTest()
        {
            Dog dog = new Dog("rex", 5, Gender.male);
            Cat cat = new Cat("Tom", 2, Gender.male);
            Kitten kitten = new Kitten("Bella", 1);

            List<Animal> animals = new List<Animal>();
            animals.Add(dog);
            animals.Add(cat);
            animals.Add(kitten);

           
            AnimalHierachy hierachy = new AnimalHierachy(animals);

            //AnimalHierachy.OrderBy(hierachy);
            
            Assert.AreEqual(dog, animals[0]);
            Assert.AreEqual(cat, animals[1]);
            Assert.AreEqual(kitten, animals[2]);            
        }

        [TestCase]
        public void testMoneyperHour()
        {
            Worker w = new Worker("Ivan", "Ivanov", 700, 10);

            double sum = w.weekSalary / w.workHouresPerDay / 7;

            Assert.AreEqual(w.moneyPerHour(), sum);
        }
    }
}
