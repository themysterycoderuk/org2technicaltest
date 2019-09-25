using System;

namespace ScenarioSolution
{
    public class EvenCalculator : IEvenCalculator
    {
        public bool IsEven(int value)
        {
            return value % 2 == 0;
        }
    }
}
