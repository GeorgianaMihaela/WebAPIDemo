using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace StudentWebApp.WebLayer.DTOs
{
    public class StudentUpdatedDTO
    {
        [JsonPropertyName("lastname")]
        [MinLength(3, ErrorMessage = "Last name must have at least 3 characters")]
        [Required]
        public string LastName { get; set; }


        //[JsonPropertyName("enrollmentdate")]
        //[Required(ErrorMessage = "Enrollment Date is required")]
        //public string EnrollmentDate { get; set; }

        [Required(ErrorMessage = "Student ID is required")]
        [JsonPropertyName("id")]
        public int StudentId { get; set; }
    }
}
