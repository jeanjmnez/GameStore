﻿using GameStore.Fontend.Models;

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
                Id = 2,
                Name = "Final Fantasy",
                Genre = "Roleplaying",
                Price = 69.9M,
                ReleaseDate = new DateOnly(2022, 9, 27)

            },
            new()
            {
                Id = 3,
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
            Genre genre = GetGenreById(game.GenreId);

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
            GameSummary? game = GetGameSummaryById(id);

            var genre = genres.Single(genre => string.Equals(
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

        public void UpdateGame(GameDetails updatedGame)
        {
            var genre = GetGenreById(updatedGame.GenreId);
            GameSummary existingGame = GetGameSummaryById(updatedGame.Id);

            existingGame.Name = updatedGame.Name;
            existingGame.Genre = genre.Name;
            existingGame.Price = updatedGame.Price;
            existingGame.ReleaseDate = updatedGame.ReleaseDate; 

        }

        private GameSummary GetGameSummaryById(int id)
        {
            var game = games.Find(game => game.Id == id);
            ArgumentNullException.ThrowIfNull(game);
            return game;
        }

        private Genre GetGenreById(string? id)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(id);
            var genre = genres.Single(genre => genre.Id == int.Parse(id));
            return genre;
        }
    }
}
