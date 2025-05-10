using fraude_odontologica.Domain.Ports;
using FraudeOdonto.ML;
using Microsoft.ML;

namespace fraude_odontologica.Infrastructure.Services
{
    public class FraudDetectionService : IFraudDetectionService
    {
        private readonly PredictionEngine<ConsultaData, FraudPrediction> _predictionEngine;

        public FraudDetectionService()
        {
            var mlContext = new MLContext();
            
            var modelPath = Path.Combine(AppContext.BaseDirectory, "../ML/FraudeOdonto.ML/model.zip");
            if (!File.Exists(modelPath))
                throw new FileNotFoundException($"Modelo de ML não encontrado em '{modelPath}'", modelPath);

            ITransformer mlModel = mlContext.Model.Load(modelPath, out var inputSchema);
            
            _predictionEngine = mlContext.Model.CreatePredictionEngine<ConsultaData, FraudPrediction>(mlModel);
        }
        public FraudPrediction Predict(ConsultaData input)
        {
            if (input is null)
                throw new ArgumentNullException(nameof(input));

            return _predictionEngine.Predict(input);
        }
    }
}