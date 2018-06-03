using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Titanic
{
    public class Person
    {
        public int PassengerId { get; set; }
        public int Survived { get; set; }
        public int Pclass { get; set; }
        public string Name { get; set; }
        public int Sex { get; set; }
        public string Age { get; set; }
        public int SibSp { get; set; }
        public int Parch { get; set; }
        public string Ticket { get; set; }
        public double Fare { get; set; }
        public double Embarked { get; set; }

        public static explicit operator Person(RawPerson person)
        {
            return new Person
            {
                Age = person.Age,
                Embarked = person.Embarked == "C" ? 0 : (person.Embarked == "Q" ? 1 : 2),
                Fare = Convert.ToDouble(person.Fare.Replace('.', ',')),
                Name = person.Name,
                Parch = person.Parch.Value,
                PassengerId = person.PassengerId,
                Pclass = person.Pclass,
                Sex = person.Sex == "male" ? 1 : 0,
                SibSp = person.SibSp.Value,
                Survived = person.Survived,
                Ticket = person.Ticket
            };
        }
    }
}
