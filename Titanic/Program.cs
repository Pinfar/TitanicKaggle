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
    class Program
    {
        static void Main(string[] args)
        {
            Accord.Math.Random.Generator.Seed = 1;
            using (var reader = new StreamReader(".\\train.csv"))
            {
                var csv = new CsvReader(reader);
                var records = csv.GetRecords<RawPerson>().ToList();
                /*new Reporter
                {
                    Data = records
                }.Analyze();*/
                var data = new Converter().Convert(records);
                var classifier1 = new Classifier(data,200);
                //var classifier2 = new Classifier(data, 300);
                var classifier3 = new Classifier(data, 400);
            }
        }
    }
}
