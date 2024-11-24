using CourseraBenefitCalculator.Classes.Models;
using CourseraBenefitCalculator.Interfaces;

namespace CourseraBenefitCalculator.Classes;

public class ConsoleWriter : IDataWriter
{
    public void Write(List<Student> Students, string Path)
    {
        Console.WriteLine("Student\tTotal Credit");
        Console.WriteLine("\t\tCourse Name\tTime\tCredit\tInstructor");
        foreach (var student in Students)
        {
            Console.WriteLine();
            Console.WriteLine(student);
            foreach (var course in student.Courses)
            {
                Console.WriteLine("\t\t" + course);
            }
            Console.WriteLine();
        }

    }
}
