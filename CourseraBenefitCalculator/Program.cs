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
        var students = dataGetter.students(parser);
        IDataWriter dataWriter = new ConsoleWriter();
        IDataFormatter dataFormatter = new PlainTextFormatter();

        foreach (string outType in parser.OutputTypes)
        {
            bool matched = true;
            switch (outType)
            {
                case "console":
                    dataWriter = new ConsoleWriter();
                    dataFormatter = new PlainTextFormatter();
                    break;
                default:
                    matched = false;
                    break;
            }
            if (matched) dataWriter.Write(dataFormatter.Format(students), parser.OutputPath);
        }
    }
}