namespace CourseraBenefitCalculator.Classes.Models;

public class Course
{
    public string Name;
    public int Time;
    public int Credit;
    public string Instructor;

    public Course(string Name, int Time, int Credit, string Instructor)
    {
        this.Name = Name;
        this.Time = Time;
        this.Credit = Credit;
        this.Instructor = Instructor;
    }

    public override string ToString()
    {
        return Name + " " + Time + " " + Credit + " " + Instructor;
    }
}
