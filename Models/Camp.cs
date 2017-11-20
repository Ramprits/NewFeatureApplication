using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace New_Application.Models {
    [Table ("Camp", Schema = "dbo")]
    public class Camp {
        [Key]
        public Guid CampId { get; set; }
        public string Name { get; set; }
        public DateTime EventDate { get; set; } = DateTime.MinValue;
        public int Length { get; set; }
        public string Description { get; set; }
        public Location Location { get; set; }
        public byte[] RowVersion { get; set; }
    }
}