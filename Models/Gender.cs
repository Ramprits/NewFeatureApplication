using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using New_Application.Infrastructure;

namespace New_Application.Models {
    [Table ("Gender", Schema = "MST")]
    public class Gender : ClientChangeTracker {
        [Key]
        public Guid GenderId { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public ICollection<Employee> Employees { get; set; }
    }
}