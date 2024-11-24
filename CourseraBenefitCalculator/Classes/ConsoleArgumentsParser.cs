namespace CourseraBenefitCalculator.Classes;

public class ConsoleArgumentsParser
{
    public List<string> StudentPINs;
    public int MinimumCredits;
    public string StartDate;
    public string EndDate;
    public List<string> OutputTypes;
    public string OutputPath;
    public ConsoleArgumentsParser()
    {
        StudentPINs = new List<string>();
        OutputTypes = new List<string>();
        StartDate = "0-0-0";
        EndDate = "0-0-0";
        OutputPath = "";
    }

    public void Parse(string[] args)
    {
        for (int i = 0; i < args.Length; i++)
        {
            switch (args[i])
            {
                case "-PINs":
                    StudentPINs = args[i + 1].Split(",").ToList();
                    break;
                case "-mincredits":
                    MinimumCredits = int.Parse(args[i + 1]);
                    break;
                case "-begin":
                    StartDate = args[i + 1];
                    break;
                case "-end":
                    EndDate = args[i + 1];
                    break;
                case "-formats":
                    OutputTypes = args[i + 1].Split(",").ToList();
                    break;
                case "-path":
                    OutputPath = args[i + 1];
                    break;
                default:
                    break;
            }
        }
    }
    public override string ToString()
    {
        return string.Join(" ", this.StudentPINs) + "\n" +
            this.MinimumCredits + "\n" +
            this.StartDate + "\n" +
            this.EndDate + "\n" +
            string.Join(" ", this.OutputTypes) + "\n" +
            this.OutputPath;
    }
}
