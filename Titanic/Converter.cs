using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Titanic
{
    public class Converter
    {
        public List<Person> Convert(List<RawPerson> data)
        {
            return data
                .Where(x => !string.IsNullOrEmpty(x.Fare))
                .Where(x => !string.IsNullOrEmpty(x.Embarked))
                .Select(x => (Person)x)
                .ToList();
        }
    }
}
