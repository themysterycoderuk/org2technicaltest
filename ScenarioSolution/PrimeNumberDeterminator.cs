namespace ScenarioSolution
{
    public class PrimeNumberDeterminator : IPrimeNumberDeterminator
    {
        IEvenCalculator _evenCalc;

        public PrimeNumberDeterminator(IEvenCalculator evenCalc)
        {
            _evenCalc = evenCalc;
        }

        public bool IsPrimeNumber(int value)
        {
            return false;
        }
    }
}
