using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SecondProjectGuid.Models
{
    public class Tag
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(128)]
        public string Name { get; set; }
        [Required]
        [StringLength(128)]
        public string Value { get; set; }
        [Required]
        [ForeignKey("VendorId")]
        public string VendorId { get; set; }
        public Vendor Vendor { get; set; }
    }
}
