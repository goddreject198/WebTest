using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAppLearning.Models
{
    public class Course
    {
        public int Id { get; set; }

        [Display(Name = "Course Title")]
        public string CourseTitle { get; set; }

        [Display(Name = "Course Content")]
        public string CourseContent { get; set; }

        [Display(Name = "Course Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime CourseDate{ get; set; }

        [Display(Name = "Course Duration")]
        public string CourseDuration{ get; set; }

        [Display(Name = "Course Image")]
        public string CourseImage{ get; set; }

        public int FieldId { get; set; }

        public virtual Field Field { get; set; }
    }
}