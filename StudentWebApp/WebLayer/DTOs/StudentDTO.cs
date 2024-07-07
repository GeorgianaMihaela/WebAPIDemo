using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace StudentWebApp.WebLayer.DTOs
{
    public class StudentDTO
    {
        [JsonPropertyName("lastname")]
        [Required]
        [MinLength(3, ErrorMessage = "Last name must have at least 3 characters")]
        [RegularExpression(@"/^([^0-9]*)$/")]
        public string LastName { get; set; }


        [JsonPropertyName("firstname")]
        [Required]
        [MinLength(3, ErrorMessage = "First name must have at least 3 characters")]
        [RegularExpression(@"/^([^0-9]*)$/")]
        public string FirstName { get; set; }
    }
}
