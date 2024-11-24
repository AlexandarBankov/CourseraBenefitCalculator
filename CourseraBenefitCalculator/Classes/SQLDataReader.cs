using CourseraBenefitCalculator.Interfaces;
using Microsoft.Data.SqlClient;
using CourseraBenefitCalculator.Classes.Models;

namespace CourseraBenefitCalculator.Classes;

public class SQLDataReader : IDataGetter
{

    public List<Student> students(ConsoleArgumentsParser Parser)
    {
        using (SqlConnection connection = new SqlConnection("Server=localhost;Database=coursera;Trusted_Connection=True;TrustServerCertificate=True;"))
        {
            Dictionary<string, Student> students = new Dictionary<string, Student>();
            HashSet<string> pins = new HashSet<string>(Parser.StudentPINs);
            string sql = @$"
SELECT 
    s.pin,
    s.first_name + ' ' + s.last_name as student_name,
    c.name,
    c.total_time,
    c.credit,
    i.first_name + ' ' + i.last_name as instructor
FROM students_courses_xref scx
JOIN students s ON scx.student_pin = s.pin 
JOIN courses c ON scx.course_id = c.id 
JOIN instructors i ON i.id = c.instructor_id
WHERE 
    scx.completion_date >= @begin 
    AND scx.completion_date <= @end
    {(Parser.StudentPINs.Any() ? $"AND s.PIN IN ({string.Join(',', Parser.StudentPINs)})" : string.Empty)}";

            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@begin", Parser.StartDate);
                command.Parameters.AddWithValue("@end", Parser.EndDate);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string PIN = reader.GetString(0);

                        if (!students.ContainsKey(PIN))
                        {
                            students.Add(PIN, new Student(reader.GetString(1)));
                        }
                        students[PIN].Courses.Add(new Course(reader.GetString(2), reader.GetByte(3), reader.GetByte(4), reader.GetString(5)));
                    }
                }
            }
            List<Student> result = new List<Student>();
            foreach (var item in students.Values)
            {
                item.CalculateCredits();
                if (item.Credits >= Parser.MinimumCredits)
                {
                    result.Add(item);
                }
            }
            return result;
        }
    }
}
