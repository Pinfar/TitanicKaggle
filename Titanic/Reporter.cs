using CsvHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Titanic
{
    public class Reporter
    {
        public List<RawPerson> Data { private get; set; }

        private int CountValid(Predicate<RawPerson> validator)
        {
            return Data.Where(x => validator(x)).Count();
        }

        private void AnalyzeColumn<T>(Func<RawPerson, T> selector, Predicate<T> validator, string propertyName)
        {
            int totalValid = CountValid(x => validator(selector(x)));
            Console.WriteLine($"{propertyName} {totalValid}");
        }

        private void Analyze<T>(Predicate<T> validator)
        {
            typeof(RawPerson)
                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(x => x.PropertyType == typeof(T))
                .ToList()
                .ForEach(x =>
                    AnalyzeColumn<T>(y => (T)x.GetValue(y), validator, x.Name)
                );
        }

        public void Analyze()
        {
            Predicate<string> isStringValid = s => !string.IsNullOrEmpty(s);
            Analyze(isStringValid);
            Predicate<int?> isIntValid = i => i != null;
            Analyze(isIntValid);


        }
    }
}
