using CourseraBenefitCalculator.Interfaces;

namespace CourseraBenefitCalculator.Classes;

public class ConsoleWriter : IDataWriter
{
    public void Write(IList<string> lines, string Path)
    {
        foreach (var line in lines)
        {
            Console.WriteLine(line);
        }
    }
}
