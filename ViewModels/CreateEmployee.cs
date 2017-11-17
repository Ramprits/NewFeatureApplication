using System;
using System.ComponentModel.DataAnnotations;

namespace New_Application.ViewModels {
    public class CreateEmployee : EmployeeForManipulationDto {
        public override string FirstName {
            get {
                return base.FirstName;
            }

            set {
                base.FirstName = value;
            }
        }
    }
}