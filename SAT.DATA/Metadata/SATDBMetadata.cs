using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAT.DATA//.Metadata
{
    class SATDBMetadata
    {
        
        public partial class CourseMetadata
        {
            public int CourseID { get; set; }
            public string CourseName { get; set; }
            public string CourseDescription { get; set; }
            public byte CreditHours { get; set; }
            public string Curriculum { get; set; }
            public string Notes { get; set; }
            public bool IsActive { get; set; }
        }

        [MetadataType(typeof(CourseMetadata))]
        public partial class Course { }

        public partial class EnrollmentMetadata
        {
            public int EnrollmentID { get; set; }
            public int StudentID { get; set; }
            public int ScheduledClassID { get; set; }
            public System.DateTime EnrollmentDate { get; set; }
            public virtual ScheduledClass ScheduledClass { get; set; }
            public virtual Student Student { get; set; }
        }

        [MetadataType(typeof(EnrollmentMetadata))]
        public partial class Enrollment { }

        public partial class ScheduledClass
        {
            public int ScheduledClassID { get; set; }
            public int CourseID { get; set; }
            public System.DateTime StartDate { get; set; }
            public System.DateTime EndDate { get; set; }
            public string InstructorName { get; set; }
            public string Location { get; set; }
            public int SCSID { get; set; }
            public virtual Course Course { get; set; }
            public virtual ICollection<Enrollment> Enrollments { get; set; }
            public virtual ScheduledClassStatus ScheduledClassStatus { get; set; }
        }

        public partial class ScheduledClassStatusMetadata
        {
            public int SCSID { get; set; }
            public string SCSName { get; set; }
            public virtual ICollection<ScheduledClass> ScheduledClasses { get; set; }
        }

        [MetadataType(typeof(ScheduledClassStatusMetadata))]
        public partial class ScheduledClassStatus { }

        public partial class StudentMetadata
        {
            public int StudentID { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Major { get; set; }
            public string Address { get; set; }
            public string City { get; set; }
            public string State { get; set; }
            public string ZipCode { get; set; }
            public string Phone { get; set; }
            public string Email { get; set; }
            public string PhotoUrl { get; set; }
            public int SSID { get; set; }
            public virtual ICollection<Enrollment> Enrollments { get; set; }
            public virtual StudentStatus StudentStatus { get; set; }
        }

        [MetadataType(typeof(StudentMetadata))]
        public partial class Student { }

        public partial class StudentStatusMetadata
        {
            public int SSID { get; set; }
            public string SSName { get; set; }
            public string SSDescription { get; set; }
            public virtual ICollection<Student> Students { get; set; }
        }

        [MetadataType(typeof(StudentStatusMetadata))]
        public partial class StudentStatus { }



    }
}
