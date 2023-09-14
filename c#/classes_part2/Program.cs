
using classes2;

Student stud1 = new Student("Desi");
Student stud2 = new Student("Tedi");
Discipline match = new Discipline("Math", 21, 15);

Discipline[] disciplines = new Discipline[] { match };

Teacher tech1 = new Teacher("Ilian", disciplines);

Student[] students = { stud1, stud2 };
Teacher[] teachers = { tech1 };

SchoolClass sc1 = new SchoolClass(teachers, students);

SchoolClass[] schoolClasses = { sc1 };

School school = new School(schoolClasses);

school.printSchool();

