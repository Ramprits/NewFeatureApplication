using System;
using New_Application.Models;

namespace New_Application.ViewModels {
    public class EmployeeVm {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public Department Department { get; set; }
    }
}