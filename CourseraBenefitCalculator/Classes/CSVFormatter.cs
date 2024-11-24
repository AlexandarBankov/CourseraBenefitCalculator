using CourseraBenefitCalculator.Classes.Models;
using CourseraBenefitCalculator.Interfaces;
using System.Text;

namespace CourseraBenefitCalculator.Classes;

public class CSVFormatter : IDataFormatter
{
    public List<string> Format(IList<Student> Students)
    {
        List<string> result = new List<string>();

        foreach (Student student in Students)
        {
            result.Add(SeparateWithCommas(student, x => x.Name, x => x.Credits));
            foreach (Course course in student.Courses)
            {
                result.Add(SeparateWithCommas(course,
                    x => x.Name, x => x.Time, x => x.Credit, x => x.Instructor));
            }
        }

        return result;
    }

    private string SeparateWithCommas<T>(T item, params Func<T, object>[] selectors)
    {
        StringBuilder sb = new StringBuilder();

        for (int i = 0; i < selectors.Length; i++)
        {
            sb.Append(selectors[i](item));
            if (i < selectors.Length - 1) sb.Append(',');
        }

        return sb.ToString();
    }
}
