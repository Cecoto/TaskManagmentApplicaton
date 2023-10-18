namespace TaskManagment.Data
{
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using TaskManagment.Data.Models;

    public class Task
    {
        [Comment("Globaly unique identifier")]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(30)]
        [Comment("Title of the the task")]
        public string Title { get; set; } = null!;

        [Required]
        [MaxLength(200)]
        [Comment("Information about the task")]
        public string Description { get; set; } = null!;

        [ForeignKey(nameof(Type))]
        [Comment("Type of the task")]
        public int TaskTypeId { get; set; }
        public virtual TaskType Type { get; set; } = null!;

        [Comment("Property for soft delete.")]
        public bool? IsActive { get; set; }

        [Comment("Date and time user creted the task")]
        public DateTime CreatedOn { get; set; }

    }
}