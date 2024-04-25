using GameStore.Fontend.Models;

namespace GameStore.Fontend.Clients
{
    public class GamesClient
    {
        private readonly List<GameSummary> games =
        [
            new (){
                    Id= 1,
                    Name="Stret Fighter II",
                    Genre="Fighting",
                    Price = 19.9M,
                    ReleaseDate = new DateOnly(1992, 7,15)

                },
            new (){
                Id= 1,
                Name="Final Fantasy",
                Genre="Roleplaying",
                Price = 69.9M,
                ReleaseDate = new DateOnly(2022, 9,27)

            },
            new (){
                Id= 1,
                Name="Fifa 23",
                Genre="Sports",
                Price = 69.9M,
                ReleaseDate = new DateOnly(2022, 9,27)

            }
        ];


        public GameSummary[] GetGames() => [.. games];

    }
}
