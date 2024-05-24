using System.ComponentModel.DataAnnotations;

namespace Central.Task.Models
{




    public class Registrations
    {
        public int Id { get; set; }


        [Required(ErrorMessage = "Please select a webinar topic.")]
        public string WebinarTopic { get; set; }

        [Required]

        [StringLength(50, ErrorMessage = "First name must not exceed 50 characters.")]
        public string FirstName { get; set; }

        [Required]

        [StringLength(50, ErrorMessage = "Last name must not exceed 50 characters.")]
        public string LastName { get; set; }

        [Required]

        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        public string Email { get; set; }

        [StringLength(50, ErrorMessage = "Company must not exceed 50 characters.")]
        public string Company { get; set; }

        [StringLength(50, ErrorMessage = "Title must not exceed 50 characters.")]
        public string Title { get; set; }

        [StringLength(150, ErrorMessage = "Questions must not exceed 150 characters.")]
        public string Questions { get; set; }
    }

}
