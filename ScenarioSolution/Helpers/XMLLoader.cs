using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace ScenarioSolution.Helpers
{
    public class XMLLoader : IXMLLoader
    {
        public TRoot LoadDocumentFromFile<TRoot>(string pathandfilename)
        {
            var ser = new XmlSerializer(typeof(TRoot));
            var fs = new FileStream(pathandfilename, FileMode.Open);
            return ((TRoot)ser.Deserialize(fs));
        }
    }
}
