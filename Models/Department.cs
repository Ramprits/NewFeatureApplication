using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using New_Application.Infrastructure;

namespace New_Application.Models {
    [Table ("Department", Schema = "MST")]
    public class Department : ClientChangeTracker {
        [Key]
        public Guid DepartmentId { get; set; }
        public string Name { get; set; }
    }
}