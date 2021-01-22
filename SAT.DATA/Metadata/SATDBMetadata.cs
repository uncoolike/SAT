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
        [Display(Name = "Course ID")]
        public int CourseID { get; set; }
        [Display(Name ="Course Name")]
        public string CourseName { get; set; }
        [Display(Name ="Description")]
        public string CourseDescription { get; set; }
        [Display(Name ="Credit Hours")]
        public byte CreditHours { get; set; }
        [Display(Name ="Required Materials")]
        public string Curriculum { get; set; }
        public string Notes { get; set; }
        [Display(Name ="Active")]
        public bool IsActive { get; set; }
    }

    [MetadataType(typeof(CourseMetadata))]
    public partial class Course { }

    public partial class EnrollmentMetadata
    {
        [Display(Name ="Enrollment ID")]
        public int EnrollmentID { get; set; }
        [Display(Name ="Student ID")]
        public int StudentID { get; set; }
        [Display(Name ="Scheduled Class ID")]
        public int ScheduledClassID { get; set; }
        [Display(Name ="Enrollment Date")]
        public System.DateTime EnrollmentDate { get; set; }
    }

    [MetadataType(typeof(EnrollmentMetadata))]
    public partial class Enrollment { }

    public class ScheduledClassMetadata
    {
        [Display(Name = "Scheduled Class ID")]
        public int ScheduledClassID { get; set; }
        [Display(Name = "Course ID")]
        public int CourseID { get; set; }
        [Display(Name ="Start Date")]
        public System.DateTime StartDate { get; set; }
        [Display(Name ="End Date")]
        public System.DateTime EndDate { get; set; }
        [Display(Name ="Instructor")]
        public string InstructorName { get; set; }
        public string Location { get; set; }
        public int SCSID { get; set; }
    }
    [MetadataType(typeof(ScheduledClassMetadata))]
    public partial class ScheduledClass { }

    public partial class ScheduledClassStatusMetadata
    {
        public int SCSID { get; set; }
        [Display(Name ="Status")]
        public string SCSName { get; set; }
    }

    [MetadataType(typeof(ScheduledClassStatusMetadata))]
    public partial class ScheduledClassStatus { }

    public partial class StudentMetadata
    {
        [Display(Name ="Student ID")]
        public int StudentID { get; set; }
        [Display(Name ="First Name")]
        public string FirstName { get; set; }
        [Display(Name ="Last Name")]
        public string LastName { get; set; }
        public string Major { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        [Display(Name ="Photo")]
        public string PhotoUrl { get; set; }
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
        public int SSID { get; set; }
        [Display(Name ="Status")]
        public string SSName { get; set; }
        [Display(Name ="Description")]
        public string SSDescription { get; set; }
    }

    [MetadataType(typeof(StudentStatusMetadata))]
    public partial class StudentStatus { }




}
