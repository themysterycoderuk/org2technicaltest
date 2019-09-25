using System.Collections.Generic;

namespace TestRunner
{
    public interface IUtilities
    {
        IList<string> FindTests();
        void RunTests();
        string RunTest(string testName);
    }
}