using Newtonsoft.Json;

namespace MovieCup.Infra.Integration.Filmes.Response
{
    public class FilmesResponse
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("titulo")]
        public string Title { get; set; }

        [JsonProperty("ano")]
        public int Year { get; set; }

        [JsonProperty("nota")]
        public double Score { get; set; }
    }
}
