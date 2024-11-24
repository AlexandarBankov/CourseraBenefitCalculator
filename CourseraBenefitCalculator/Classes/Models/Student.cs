namespace CourseraBenefitCalculator.Classes.Models;

public class Student
{
    public string Name;
    public int Credits;
    public List<Course> Courses;

    public Student(string Name)
    {
        Credits = 0;
        Courses = new List<Course>();
        this.Name = Name;
    }

    public void CalculateCredits()
    {
        Credits = 0;
        for (int i = 0; i < Courses.Count; i++)
        {
            Credits += Courses[i].Credit;
        }
    }

    public override string ToString()
    {
        return Name + " " + Credits;
    }
}
