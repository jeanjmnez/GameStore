using GameStore.Fontend.Models;

namespace GameStore.Fontend.Clients
{
    public class GenresClient(HttpClient httpClient)
    {
      

        public async Task<Genre[]> GetGenresAsync() => await httpClient.GetFromJsonAsync<Genre[]>("genres")
            ?? [];
    }

}
