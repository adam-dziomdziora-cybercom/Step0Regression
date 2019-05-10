using Microsoft.ML.Data;

namespace Step0Regression.Models
{
    public class Prediction
    {
        [ColumnName("Score")]
        public float Price {get;set;}
    }
}