using System.Collections.Generic;

namespace TestRunner
{
    public interface IUtilities
    {
        IDictionary<string, IList<string>> FindTests();
        string RunTest(string testName);
    }
}