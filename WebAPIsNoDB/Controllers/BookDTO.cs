using System.Text;
using System.Text.Json.Serialization;

namespace WebAPIsNoDB.Controllers
{
    public class BookDTO
    {
        [JsonPropertyName("isbn")]
        public string ISBN { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("author")]
        public string Author { get; set; }

        [JsonPropertyName("publisheddate")]
        public string PublishedDate { get; set; }

        [JsonPropertyName("reviewscore")]
        public string ReviewScore { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(Title);
            sb.Append(" ");
            sb.Append(Author);
            sb.Append(" ");
            sb.Append(PublishedDate);
            sb.Append(" ");
            sb.Append(ReviewScore);
            sb.Append(" ");

            return sb.ToString();
        }
    }
}