using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SecondProjectGuid.Models
{
    public class Vendor
    {
        public Vendor()
        {

            Tags = new HashSet<Tag>();
            Histories = new HashSet<History>();
        }
        [Key]
        public string Id { get; set; }
        [Required]
        [StringLength(128)]
        public string Name { get; set; }
        [Required]
        [StringLength(128)]
        public string Title { get; set; }
        [Required]
        public DateTime Date { get; set; }
        public ICollection<Tag> Tags { get; set; }
        public ICollection<History> Histories { get; set; }
    }
}
