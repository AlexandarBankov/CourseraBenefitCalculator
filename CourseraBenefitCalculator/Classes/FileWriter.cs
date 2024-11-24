using CourseraBenefitCalculator.Interfaces;

namespace CourseraBenefitCalculator.Classes
{
    public class FileWriter : IDataWriter
    {
        private string fileName;
        public FileWriter(string FileName)
        {
            fileName = FileName;
        }
        public void Write(IList<string> lines, string Path)
        {
            try
            {
                File.WriteAllLines(System.IO.Path.Combine(Path, fileName), lines);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
