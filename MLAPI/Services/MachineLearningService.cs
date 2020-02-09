namespace MLAPI.Services
{
    using Data.Models;
    using Microsoft.Data.SqlClient;
    using Microsoft.Extensions.Configuration;
    using Microsoft.ML;
    using Microsoft.ML.Data;

    public class MachineLearningService : IMachineLearningService
    {
        private readonly MLContext _mlContext;
        private readonly IConfiguration _configuration;
        
        public MachineLearningService(IConfiguration configuration)
        {
           _mlContext = new MLContext();
           _configuration = configuration;
        }

        private IDataView EnsureDataLoaded()
        {
            var loader = _mlContext.Data.CreateDatabaseLoader<ModelInput>();
            var dbSource = new DatabaseSource(SqlClientFactory.Instance, _configuration.GetConnectionString("DefaultConnectionString"), "SELECT * FROM ModelInputs");
            return loader.Load(dbSource);
        }

        private PredictionEngine<ModelInput, ModelOutput> CreatePredictionEngine()
        {
            var data = EnsureDataLoaded();
            var textEstimator  = _mlContext.Transforms.Text.FeaturizeText("SentimentText");
            var textTransformer = textEstimator.Fit(data);
            return _mlContext.Model.CreatePredictionEngine<ModelInput, ModelOutput>(textTransformer);
        }

        public ModelOutput AnalyzeText(ModelInput input)
        {
            var predEngine = CreatePredictionEngine();
            return predEngine.Predict(input);
        }
    }
}