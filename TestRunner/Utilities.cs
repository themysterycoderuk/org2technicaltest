using NUnit.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace TestRunner
{
    public class Utilities : IUtilities, ITestEventListener
    {
        
        private string _assemblyPath = "./bin/Debug/netcoreapp2.2/UnitTests.dll";

        public Utilities(bool isProduction)
        {
            if (isProduction)
            {
                _assemblyPath = "./UnitTests.dll";
            }
        }

        public IList<string> FindTests()
        {
            var runner = getRunner();
            var builder = new TestFilterBuilder();
            var filter = builder.GetFilter();
            var explore = runner.Explore(filter);
            var testNodes = explore.SelectNodes(@"//test-case");
            return testNodes.Cast<XmlNode>().Select(s => s.Attributes["name"].Value).ToList();
        }

        public string RunTest(string testName)
        {
            var runner = getRunner();
            var builder = new TestFilterBuilder();
            builder.SelectWhere($"method==\"{testName}\"");
            var filter = builder.GetFilter();
            var results = runner.Run(this, filter);
            var testNodes = results.SelectNodes(@"//test-case");
            return testNodes.Cast<XmlNode>().Select(s => s.Attributes["result"].Value).First();
        }

        public void RunTests()
        {


            //XmlNode result = runner.Run(this, TestFilter.Empty);
        }

        public void OnTestEvent(string report)
        {
            var x = report;
        }

        private ITestRunner getRunner()
        {
            var engine = TestEngineActivator.CreateInstance();
            var package = new TestPackage(_assemblyPath);
            return engine.GetRunner(package);
        }
    }
}
