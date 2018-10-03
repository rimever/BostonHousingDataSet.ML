using Microsoft.ML.Runtime.Api;

namespace BostonHousingDataSet.Core.Models
{
    public class BostonHousingPrediction
    {
        [ColumnName("Score")]
        public float MEDV;
    }
}
