using Lazar_Horatiu_Lab6_Master.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.ML;

namespace Lazar_Horatiu_Lab6_Master.Controllers
{
    public class MovieController : Controller
    {
        public IActionResult Recommend(float userId, float movieId)
        {
            MLContext mlContext = new MLContext();
            string mlModelPath = @"MovieRecommenderModel.mlnet";
            ITransformer mlModel = mlContext.Model.Load(mlModelPath, out _);
            PredictionEngine<MovieRatingData, MovieRatingPrediction> predictionEngine =
            mlContext.Model.CreatePredictionEngine<MovieRatingData,
            MovieRatingPrediction>(mlModel);
            MovieRatingData movieRatingData = new MovieRatingData()
            {
                UserId = userId,
                MovieId = movieId,
            };
            MovieRatingPrediction result = predictionEngine.Predict(movieRatingData);
            ViewBag.Score = result.Score.ToString().Equals("NaN") ? 0 : result.Score;
            ViewBag.MovieId = movieRatingData.MovieId;
            ViewBag.UserId = movieRatingData.UserId;
            return View(movieRatingData);
        }
    }
}
