using FraudeOdonto.ML;

namespace fraude_odontologica.Domain.Ports;

public interface IFraudDetectionService
{
    FraudPrediction Predict(ConsultaData input);
}