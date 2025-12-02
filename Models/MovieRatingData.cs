using Microsoft.ML.Data;

namespace Lazar_Horatiu_Lab6_Master.Models
{
    public class MovieRatingData
    {
        [LoadColumn(0)]
        [ColumnName("userId")]
        public float UserId;

        [LoadColumn(1)]
        [ColumnName("movieId")]
        public float MovieId;

        [LoadColumn(2)]
        [ColumnName("Label")]
        public float Label;
    }
}
