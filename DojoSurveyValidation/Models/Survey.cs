using System.ComponentModel.DataAnnotations;

namespace DojoSurveyValidation.Models
{
    public class Survey
    {
        [Required]
        [MinLength(2)]
        public string Name { get; set; }

        [Required]
        public string Location { get; set; }

        [Required]
        public string Language { get; set; }

        [MinLength(20)]
        public string Comments { get; set; }
    }
}