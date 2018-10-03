using System;
using System.IO;
using System.Threading.Tasks;
using BostonHousingDataSet.Core.Models;
using Microsoft.ML;
using Microsoft.ML.Data;
using Microsoft.ML.Models;
using Microsoft.ML.Trainers;
using Microsoft.ML.Transforms;

namespace BostonHousingDataSet.Core.Services
{
    /// <summary>
    /// 機械学習の処理を提供するクラスです。
    /// </summary>
    public class MachineLearningService
    {
        /// <summary>
        /// 生データのファイルパス
        /// </summary>
        public string ModelPath => Path.GetFullPath(Path.Combine(RootDirectoryPath, "Data", "Model.zip"));

        /// <summary>
        /// ルートディレクトリのパス
        /// </summary>
        public string RootDirectoryPath { get; } = @"..\..\..\..\BostonHousingDataSet.Core";

        /// <summary>
        /// 分析を実行します。
        /// </summary>
        public async Task Analyze()
        {
            DataCleaningService cleaningService = new DataCleaningService();
            cleaningService.Clean();
            var model = await TrainAsync(cleaningService.CleanedFilePath, ModelPath);
            Evaluate(model, cleaningService.CleanedFilePath);
        }

        /// <summary>
        /// モデルを評価します。
        /// </summary>
        /// <param name="model"></param>
        /// <param name="testDataPath"></param>
        private void Evaluate(PredictionModel<BostonHousingData, BostonHousingPrediction> model, string testDataPath)
        {
            var testData = new TextLoader(testDataPath).CreateFrom<BostonHousingData>(true, ',');
            var evaluator = new RegressionEvaluator();
            RegressionMetrics metrics = evaluator.Evaluate(model, testData);
            Console.WriteLine($"Rms = {metrics.Rms}");
            Console.WriteLine($"RSquared = {metrics.RSquared}");
        }

        /// <summary>
        /// モデルをトレーニングします。
        /// </summary>
        /// <param name="dataPath"></param>
        /// <param name="modelPath"></param>
        /// <returns></returns>
        private async Task<PredictionModel<BostonHousingData, BostonHousingPrediction>> TrainAsync(string dataPath,
            string modelPath)
        {
            var pipeline = new LearningPipeline
            {
                new TextLoader(dataPath).CreateFrom<BostonHousingData>(separator:','),
                new ColumnCopier((nameof(BostonHousingData.MEDV), "Label")),
                new ColumnConcatenator("Features",
                    nameof(BostonHousingData.CRIM),
                    nameof(BostonHousingData.ZIN),
                    nameof(BostonHousingData.INDUS),
                    nameof(BostonHousingData.CHAS),
                    nameof(BostonHousingData.NOX),
                    nameof(BostonHousingData.RM),
                    nameof(BostonHousingData.AGE),
                    nameof(BostonHousingData.DIS),
                    nameof(BostonHousingData.RAD),
                    nameof(BostonHousingData.TAX),
                    nameof(BostonHousingData.PTRATIO),
                    nameof(BostonHousingData.B),
                    nameof(BostonHousingData.LSTAT)
                ),
                new FastTreeRegressor()
            };
            var model = pipeline.Train<BostonHousingData, BostonHousingPrediction>();
            await model.WriteAsync(modelPath);
            return model;
        }
    }
}