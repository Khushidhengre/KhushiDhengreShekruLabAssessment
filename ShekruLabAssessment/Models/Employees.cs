using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ShekruLabAssessment.Models
{
    public class Employees
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="FirstName Required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "LastName Required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "EmailID Required")]
        [EmailAddress]
        public string EmailAddess { get; set; }
        public string PhoneNumber { get; set; }
        public int DesignationIdRef { get; set; }
        public int GradeIdRef { get; set; }
    }
    public class Display
    {
        public int Id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string EmailAddess { get; set; }
        public string PhoneNumber { get; set; }
        public string DesignationName { get; set; }
        public string GradeName { get; set; }
    }



    public class Designation
    {
        [Key]
        public int Id { get; set; }
        public string DesignationName { get; set; }

       

    }
    public class DesignationGrade
    {
        [Key]
        public int Id { get; set; }
        public string GradeName { get; set; }
        public int DesignationIdRef { get; set; }

 

    }



}
