using CourseraBenefitCalculator.Interfaces;
using CourseraBenefitCalculator.Classes;

namespace CourseraBenefitCalculator;

class Program
{   
    static void Main(string[] args)
    {
        ConsoleArgumentsParser parser = new ConsoleArgumentsParser();
        try
        {
            parser.Parse(args);
        }
        catch (Exception e)
        {
            Console.WriteLine("invalid arguments: " + e.Message);
        }

        IDataGetter dataGetter = new SQLDataReader();
        IDataWriter dataWriter = new ConsoleWriter();

        foreach (string outType in parser.OutputTypes)
        {
            bool matched = true;
            switch (outType)
            {
                case "console":
                    dataWriter = new ConsoleWriter();
                    break;
                default:
                    matched = false;
                    break;
            }
            if (matched) dataWriter.Write(dataGetter.students(parser), parser.OutputPath);
        }
    }
}