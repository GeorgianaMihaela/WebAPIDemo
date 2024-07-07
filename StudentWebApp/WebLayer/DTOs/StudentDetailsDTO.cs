using System.Text.Json.Serialization;

namespace StudentWebApp.WebLayer.DTOs
{
    public class StudentDetailsDTO
    {
        [JsonPropertyName("lastname")]
        public string LastName { get; set; }
        [JsonPropertyName("firstname")]
        public string FirstName { get; set; }

        [JsonPropertyName("enrollmentdate")]
        public string EnrollmentDate { get; set; }
    }
}
