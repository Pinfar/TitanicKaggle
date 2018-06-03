using Accord.MachineLearning.DecisionTrees;
using Accord.MachineLearning.DecisionTrees.Learning;
//using Accord.Math;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Titanic
{
    public class Classifier
    {
        public Classifier(List<Person> data, int size)
        {
            var testSet = data.Take(size).ToList();
            var learnSet = data.Skip(size).ToList();
            double[][] inputs = learnSet.Select(x => new double[6] { x.Parch, x.Pclass, x.SibSp, x.Sex, x.Fare, x.Embarked }).ToArray();

            int[] outputs = learnSet.Select(x => x.Survived).ToArray();

            
            DecisionVariable[] variables =
            {
                new DecisionVariable("Parch", DecisionVariableKind.Discrete),
                new DecisionVariable("Pclass", DecisionVariableKind.Discrete),
                new DecisionVariable("SibSp", DecisionVariableKind.Discrete),
                new DecisionVariable("Sex", DecisionVariableKind.Discrete),
                new DecisionVariable("Fare", DecisionVariableKind.Continuous),
                new DecisionVariable("Embarked", DecisionVariableKind.Discrete)
            };
            
            var teacher = new RandomForestLearning()
            {
                NumberOfTrees = 10,
            };
            var tree = teacher.Learn(inputs, outputs);
            var result = tree.Decide(testSet.Select(x => new double[6] { x.Parch, x.Pclass, x.SibSp, x.Sex, x.Fare, x.Embarked }).ToArray());
            var good = 0f;
            for(int i=0;i<result.Count();++i)
            {
                if (result[i] == (testSet[i].Survived))
                    good++;
            }
            Console.WriteLine($"Good: {good/ size * 100}%");
        }
    }
}
