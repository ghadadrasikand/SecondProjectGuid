using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SecondProjectGuid.Models
{
    public class History
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string VendorId { get; set; }
        public Vendor Vendor { get; set; }
        [Required]
        public string JsonResult { get; set; }
        [Required]
        [StringLength(128)]
        public string Operation { get; set; }
    }
}
