using CourseraBenefitCalculator.Classes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseraBenefitCalculator.Interfaces
{
    public interface IDataFormatter
    {
        public List<string> Format(IList<Student> Students);
    }
}
