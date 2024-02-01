using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Crud_Assessment.Models
{
    public class Batch
    {

        [Required]
        [Remote("UniqueIDValue", "Batch", HttpMethod = "Post", ErrorMessage = "Student Id already exists.")]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        [RegularExpression(@"^[a-zA-Z ]+$")]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        [DateOfBirthValidator]
        public DateTime Dob { get; set; }

        [StringLength(50)]
        public string? Address { get; set; }

        [Required]
        [RegularExpression(@"^B\d{3}$")]
        public string batch { get; set; }
    }
}
