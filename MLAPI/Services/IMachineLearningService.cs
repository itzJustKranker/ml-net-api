namespace MLAPI.Services
{
    using Data.Models;

    public interface IMachineLearningService
    {
        ModelOutput AnalyzeText(ModelInput input);
    }
}