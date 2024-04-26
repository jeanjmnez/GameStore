using GameStore.Fontend.Models;

namespace GameStore.Fontend.Clients
{
    public class GamesClient
    {
        private readonly List<GameSummary> games =
        [
            new()
            {
                Id = 1,
                Name = "Stret Fighter II",
                Genre = "Fighting",
                Price = 19.9M,
                ReleaseDate = new DateOnly(1992, 7, 15)

            },
            new()
            {
                Id = 1,
                Name = "Final Fantasy",
                Genre = "Roleplaying",
                Price = 69.9M,
                ReleaseDate = new DateOnly(2022, 9, 27)

            },
            new()
            {
                Id = 1,
                Name = "Fifa 23",
                Genre = "Sports",
                Price = 69.9M,
                ReleaseDate = new DateOnly(2022, 9, 27)

            }
        ];


        private readonly Genre[] genres = new GenresClient().GetGenres();


        public GameSummary[] GetGames() => [.. games];

        public void AddGame(GameDetails game)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(game.GenreId); 
            var genre = genres.Single(genre =>genre.Id == int.Parse(game.GenreId));

            var gameSummary = new GameSummary
            {
                Id = games.Count + 1,
                Name = game.Name,
                Genre = genre.Name,
                Price = game.Price,
                ReleaseDate = game.ReleaseDate
            };

            games.Add(gameSummary);
        }


        public GameDetails getGame(int id)
        {
            var game = games.Find(game => game.Id == id);
            ArgumentNullException.ThrowIfNull(game);

            var genre = genres.Single(genre=>string.Equals(
                genre.Name,
                game.Genre,
                StringComparison.OrdinalIgnoreCase));

            return new GameDetails
            {
                Id = game.Id,
                Name = game.Name,
                GenreId = genre.Id.ToString(),
                Price = game.Price,
                ReleaseDate = game.ReleaseDate
            };

        }
    }
}
