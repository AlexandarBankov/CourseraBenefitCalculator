using CourseraBenefitCalculator.Classes.Models;

namespace CourseraBenefitCalculator.Interfaces
{
    interface IDataWriter
    {
        public void Write(List<Student> Students, string Path);
    }
}
