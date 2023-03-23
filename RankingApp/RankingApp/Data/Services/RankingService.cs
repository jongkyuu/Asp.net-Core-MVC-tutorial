using RankingApp.Data.Models;

namespace RankingApp.Data.Services
{
    public class RankingService
    {
        private ApplicationDbContext _context;


        public RankingService(ApplicationDbContext context)
        {
            _context = context;
        }

        // CRUD : Create, Read, Update, Delete

        // Raed
        public Task<List<GameResult>> GetGameResultAsync()
        {
            List<GameResult> results = _context.GameResults
                .OrderByDescending(g => g.Score).ToList();


            return Task.FromResult(results);
        }

        public Task<GameResult> AddGameResultAsync(GameResult gameResult)
        {
            _context.GameResults.Add(gameResult);
            _context.SaveChanges();

            return Task.FromResult(gameResult);
        }
    }
}
