using Microsoft.AspNetCore.Mvc;

namespace ReactNET.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieRecommender : ControllerBase
    {
        private static readonly string[] Movies = new[]
        {
            "Interstellar", "Fight Club", "Parasite", "WALL·E", "Oppenheimer", "Up", "Blade Runner 2049", "Monsters, Inc.", "Notebook", "Forrest Gump"
        };

        private readonly ILogger<MovieRecommender> _logger;

        public MovieRecommender(ILogger<MovieRecommender> logger)
        {
            _logger = logger;
        }

        
        [HttpGet(Name = "GetMovieRecommendation")]
        public IEnumerable<MovieRecommendAnalyze> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new MovieRecommendAnalyze
            {
                RandomSelect = Random.Shared.Next(0, 9),
                MovieSelect = Movies[Random.Shared.Next(Movies.Length)]
            })
            .ToArray();
        }
    }
}
