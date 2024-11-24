using CourseraBenefitCalculator.Classes.Models;
using CourseraBenefitCalculator.Interfaces;
using System.Text;

namespace CourseraBenefitCalculator.Classes;

public class HTMLTableFormatter : IDataFormatter
{
    public List<string> Format(IList<Student> Students)
    {
        List<string> result = new List<string>();
        result.Add("<table>");
        result.Add("<tr><th>Student</th><th>Total Credit</th><th></th><th></th><th></th></tr>");
        result.Add("<tr><th></th><th>Course Name</th><th>Time</th><th>Credit</th><th>Instructor</th></tr>");

        foreach (Student student in Students)
        {
            result.Add(CreateRow(student, x => x.Name, x => x.Credits,
                x => string.Empty, x => string.Empty, x => string.Empty));
            foreach (Course course in student.Courses)
            {
                result.Add(CreateRow(course, x => string.Empty,
                    x => x.Name, x => x.Time, x => x.Credit, x => x.Instructor));
            }
        }

        result.Add("</table>");
        return result;
    }

    private string CreateRow<T>(T item, params Func<T, object>[] selectors)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("<tr>");
        for (int i = 0; i < selectors.Length; i++)
        {
            sb.Append("<td>");
            sb.Append(selectors[i](item));
            sb.Append("</td>");
        }
        sb.Append("</tr>");
        return sb.ToString();
    }
}
