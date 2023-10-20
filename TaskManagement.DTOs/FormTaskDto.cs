namespace TaskManagement.DTOs
{
    using System.ComponentModel.DataAnnotations;

    public class FormTaskDto
    {
        [Required]
        [StringLength(30,MinimumLength =3,ErrorMessage = "Title must be at least 3 characters long.")]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(200, MinimumLength = 5, ErrorMessage = "Description must be at least 5 characters long.")]
        public string Description { get; set; } = null!;

        [Required]
        public int TaskTypeId { get; set; }
    }
}