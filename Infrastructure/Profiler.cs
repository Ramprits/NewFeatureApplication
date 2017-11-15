using AutoMapper;
using New_Application.Models;
using New_Application.ViewModels;

namespace New_Application.Infrastructure {
    public class Profiler : Profile {
        public Profiler () {
            CreateMap<Employee, EmployeeVm> ().ReverseMap ();
        }
    }
}