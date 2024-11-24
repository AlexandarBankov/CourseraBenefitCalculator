using CourseraBenefitCalculator.Classes.Models;
using CourseraBenefitCalculator.Interfaces;
using System.Text;

namespace CourseraBenefitCalculator.Classes;

public class PlainTextFormatter : IDataFormatter
{
    public List<string> Format(IList<Student> Students)
    {
        List<string> result = new List<string>();
        result.Add("Student\tTotal Credit");
        result.Add("\t\tCourse Name\tTime\tCredit\tInstructor");
        foreach (var student in Students)
        {
            result.Add(string.Empty);
            result.Add(student.ToString());
            foreach (var course in student.Courses)
            {
                result.Add("\t\t" + course);
            }
            result.Add(string.Empty);
        }

        return result;
    }
}
