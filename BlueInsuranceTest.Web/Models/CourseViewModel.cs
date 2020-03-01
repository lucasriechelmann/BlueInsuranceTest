using System;
using System.ComponentModel.DataAnnotations;

namespace BlueInsuranceTest.Web.Models
{
    public class CourseViewModel
    {
        public long Id { get; set; }
        [Required]
        [Display(Name = "Course Code")]
        [StringLength(20, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        public string Code { get; set; }
        [Required]
        [Display(Name = "Course Name")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Teacher Name")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        public string TeacherName { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }
        [Required]
        [Display(Name = "Limit Student")]
        public int StudentLimit { get; set; }
    }
}
