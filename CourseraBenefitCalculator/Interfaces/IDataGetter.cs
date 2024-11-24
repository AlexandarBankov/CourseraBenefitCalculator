using CourseraBenefitCalculator.Classes;
using CourseraBenefitCalculator.Classes.Models;

namespace CourseraBenefitCalculator.Interfaces
{
    interface IDataGetter
    {
        public List<Student> students(ConsoleArgumentsParser Parser);
    }
}
