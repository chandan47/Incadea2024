using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace MYSchool.Models
{
    public class Students
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string Fname { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string Lname { get; set; }

        [Required]
        [Display(Name = "Roll Number")]
        public  string RollNumber {get; set;}
        
        [Required]
        [Display(Name = "Class")]
        
        public string Class {get; set;}

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required]
        [MaxLength(10)]
        [Display(Name = "Phone")]
        public string Phone { get; set; }

        [Required]
        [MaxLength (100)]
        [Display(Name = "Address")]
        public string Address { get; set; }
    }



}
