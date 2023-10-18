//namespace TaskManagment.Data.Models
//{
//    using Microsoft.AspNet.Identity.EntityFramework;
//    using Microsoft.EntityFrameworkCore;
//    using System;
//    using System.Collections.Generic;
//    using System.ComponentModel.DataAnnotations;
//    using System.Linq;
//    using System.Text;
//    using System.Threading.Tasks;
//    using TaskManagment.Data.Models.Enums;

//    public class ApplicationUser : IdentityUser
//    {
//        public ApplicationUser()
//        {
//            this.Tasks = new HashSet<Task>();
//        }

//        [Required]
//        [Comment("User firstname")]
//        [MaxLength(30)]
//        public string FirstName { get; set; } = null!;

//        [Required]
//        [Comment("User lastname")]
//        [MaxLength(30)]
//        public string LastName { get; set; } = null!;

//        [Comment("User age")]
//        public int Age { get; set; }

//        [Comment("User gender")]
//        public Gender Gender { get; set; }

//        [Comment("Collect of user tasks")]
//        public virtual ICollection<Task> Tasks { get; set; }
//    }
//}
