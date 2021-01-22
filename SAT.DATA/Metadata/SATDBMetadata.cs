using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAT.DATA//.Metadata
{
    
    public partial class CourseMetadata
    {
        //[Required(ErrorMessage ="* Course ID is required")]
        //[Display(Name = "Course ID")]
        //public int CourseID { get; set; }
        [Required(ErrorMessage = "* Course Name is required")]
        [Display(Name ="Course Name")]
        public string CourseName { get; set; }
        [Required(ErrorMessage = "* Course Description is required")]
        [Display(Name ="Description")]
        public string CourseDescription { get; set; }
        [Required(ErrorMessage = "* Credit Hours are required")]
        [Display(Name ="Credit Hours")]
        public byte CreditHours { get; set; }
        [Display(Name ="Required Materials")]
        public string Curriculum { get; set; }
        public string Notes { get; set; }
        [Required(ErrorMessage = "* Active status is required")]
        [Display(Name ="Active")]
        public bool IsActive { get; set; }
    }

    [MetadataType(typeof(CourseMetadata))]
    public partial class Course { }

    public partial class EnrollmentMetadata
    {
        //[Required(ErrorMessage = "* Enrollment ID is required")]
        //[Display(Name ="Enrollment ID")]
        //public int EnrollmentID { get; set; }
        [Required(ErrorMessage = "* Student ID is required")]
        [Display(Name ="Student ID")]
        public int StudentID { get; set; }
        [Required(ErrorMessage = "* Scheduled Class ID is required")]
        [Display(Name ="Scheduled Class ID")]
        public int ScheduledClassID { get; set; }
        [Required(ErrorMessage = "* Enrollment Date is required")]
        [Display(Name ="Enrollment Date")]
        public System.DateTime EnrollmentDate { get; set; }
    }

    [MetadataType(typeof(EnrollmentMetadata))]
    public partial class Enrollment { }

    public class ScheduledClassMetadata
    {
        //[Required(ErrorMessage = "* Scheduled Class ID is required")]
        //[Display(Name = "Scheduled Class ID")]
        //public int ScheduledClassID { get; set; }
        [Required(ErrorMessage = "* Course ID is required")]
        [Display(Name = "Course ID")]
        public int CourseID { get; set; }
        [Required(ErrorMessage = "* Start Date is required")]
        [Display(Name ="Start Date")]
        public System.DateTime StartDate { get; set; }
        [Required(ErrorMessage = "* End Date is required")]
        [Display(Name ="End Date")]
        public System.DateTime EndDate { get; set; }
        [Required(ErrorMessage = "* Instructor is required")]
        [Display(Name ="Instructor")]
        public string InstructorName { get; set; }
        [Required(ErrorMessage = "* Location is required")]
        public string Location { get; set; }
        [Required(ErrorMessage = "* Scheduled Class Status ID is required")]
        public int SCSID { get; set; }
    }
    [MetadataType(typeof(ScheduledClassMetadata))]
    public partial class ScheduledClass { }

    public partial class ScheduledClassStatusMetadata
    {
        //[Required(ErrorMessage = "* Scheduled Class Status ID is required")]
        //public int SCSID { get; set; }
        [Required(ErrorMessage = "* Status Class Status is required")]
        [Display(Name ="Status")]
        public string SCSName { get; set; }
    }

    [MetadataType(typeof(ScheduledClassStatusMetadata))]
    public partial class ScheduledClassStatus { }

    public partial class StudentMetadata
    {
        //[Required(ErrorMessage = "* Student ID is required")]
        //[Display(Name ="Student ID")]
        //public int StudentID { get; set; }
        [Required(ErrorMessage = "* Student First Name is required")]
        [Display(Name ="First Name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "* Student Last Name is required")]
        [Display(Name ="Last Name")]
        public string LastName { get; set; }
        public string Major { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Phone { get; set; }
        [Required(ErrorMessage = "* Student Email is required")]
        public string Email { get; set; }
        [Display(Name ="Photo")]
        public string PhotoUrl { get; set; }
        [Required(ErrorMessage = "* Student Status ID is required")]
        public int SSID { get; set; }
    }

    [MetadataType(typeof(StudentMetadata))]
    public partial class Student
    {
        [Display(Name = "Student Name")]
        public string FullName
        {
            get { return $"{FirstName} {LastName}"; }
        }
    }

    public partial class StudentStatusMetadata
    {
        //public int SSID { get; set; }
        [Required(ErrorMessage = "* Student Status is required")]
        [Display(Name ="Status")]
        public string SSName { get; set; }
        [Display(Name ="Description")]
        public string SSDescription { get; set; }
    }

    [MetadataType(typeof(StudentStatusMetadata))]
    public partial class StudentStatus { }




}
