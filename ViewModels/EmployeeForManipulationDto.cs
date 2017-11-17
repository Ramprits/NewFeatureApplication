using System;
using System.ComponentModel.DataAnnotations;

namespace New_Application.ViewModels {
    public abstract class EmployeeForManipulationDto {
        [Required (ErrorMessage = "You must enter first name")]
        [MaxLength (5, ErrorMessage = "The firstName shouldn't have more than 5 characters.")]
        public virtual string FirstName { get; set; }

        [Required (ErrorMessage = "You must enter last name"), MaxLength (25), MinLength (5)]
        public string LastName { get; set; }
        [Required (ErrorMessage = "You must enter email")]
        public string Email { get; set; }
        [Required (ErrorMessage = "You must enter mobile number")]
        public string Mobile { get; set; }
        public Guid DepartmentId { get; set; }
    }
}