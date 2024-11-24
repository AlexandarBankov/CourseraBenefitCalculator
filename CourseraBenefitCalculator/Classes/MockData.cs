using CourseraBenefitCalculator.Classes.Models;
using CourseraBenefitCalculator.Interfaces;

namespace CourseraBenefitCalculator.Classes;

public class MockData : IDataGetter
{
    public List<Student> students(ConsoleArgumentsParser Parser)
    {
        List<Student> result = new List<Student>();
        Student student = new Student("John Smith");
        student.Courses.Add(new Course("Ray tracing", 1, 1, "Jack Smith"));

        result.Add(student);

        return result;
    }
}

