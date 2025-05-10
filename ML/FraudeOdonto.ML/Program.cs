using Microsoft.ML;
using Microsoft.ML.Data;

namespace FraudeOdonto.ML
{
    public class ConsultaData
    {
        [LoadColumn(0)] public float Custo;
        [LoadColumn(1)] public float Duracao;
        [LoadColumn(2)] public bool Label;  
    }
    
    public class FraudPrediction
    {
        [ColumnName("PredictedLabel")] public bool PredictedLabel;
        public float Probability;
        public float Score;
    }

    class Program
    {
        static void Main(string[] args)
        {
            var mlContext = new MLContext();
            
            var data = mlContext.Data.LoadFromTextFile<ConsultaData>(
                path: "data/consultas.csv",
                hasHeader: true,
                separatorChar: ',');
            
            var split = mlContext.Data.TrainTestSplit(data, testFraction: 0.2);
            
            var pipeline = mlContext.Transforms
                .Concatenate("Features", nameof(ConsultaData.Custo), nameof(ConsultaData.Duracao))
                .Append(mlContext.BinaryClassification.Trainers.SdcaLogisticRegression());

            var model = pipeline.Fit(split.TrainSet);
            
            mlContext.Model.Save(model, data.Schema, "model.zip");
            Console.WriteLine("Modelo treinado e salvo em model.zip");
        }
    }
}