
using classes2;

/*Student stud1 = new Student("Desi");
Student stud2 = new Student("Tedi");
Discipline match = new Discipline("Math", 21, 15);

Discipline[] disciplines = new Discipline[] { match };

Teacher tech1 = new Teacher("Ilian", disciplines);

Student[] students = { stud1, stud2 };
Teacher[] teachers = { tech1 };

SchoolClass sc1 = new SchoolClass(teachers, students);

SchoolClass[] schoolClasses = { sc1 };

School school = new School(schoolClasses);

school.printSchool();*/

/*Student2 student2 = new Student2("Ivan", "Ivanov", 5.5);
Student2 student3 = new Student2("Ivan", "Petrov", 4.5);
Student2 student4 = new Student2("Georgi", "Petrov", 3.5);
List<Student2> list1 = new List<Student2>();

list1.Add(student2);
list1.Add(student3);
list1.Add(student4);

Student2.OrderBy(list1);


Worker worker1 = new Worker("Ivan", "georgiev", 152.30, 48);
Worker worker2 = new Worker("Petar", "ivanov", 252.34, 48);
Worker worker3 = new Worker("georgi", "hfsio", 352.34, 48);

List<Worker> list2 = new List<Worker>();
list2.Add(worker1);
list2.Add(worker2);
list2.Add(worker3);

Worker.OrderBy(list2);

List<Human> list3 = new List<Human>();

list3.AddRange(list1);
list3.AddRange(list2);

Human.OrderBy(list3);
*/

Triangle tr1 = new Triangle(15, 2);
Rectangle r1 = new Rectangle(20, 40);
Square s1 = new Square(20);

Shape[] shapes = { tr1, r1, s1 };

for (int i = 0; i < shapes.Length; i++)
{
    Console.WriteLine(shapes[i].calculateSurface());
}


