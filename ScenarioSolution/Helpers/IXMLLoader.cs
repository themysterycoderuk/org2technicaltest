namespace ScenarioSolution.Helpers
{
    public interface IXMLLoader
    {
        TRoot LoadDocumentFromFile<TRoot>(string pathandfilename);
    }
}