﻿using SecondProjectGuid.DTOs.Tags;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SecondProjectGuid.DTOs.Vendors
{
    public class VendorDTO
    {
        public VendorDTO()
        {
            Tags = new HashSet<TagDTO>();
        }
        [Required]
        [MaxLength(128)]
        public string Name { get; set; }
        [Required]
        [MaxLength(128)]
        public string Title { get; set; }
        [Required]
        public DateTime Date { get; set; }
        public ICollection<TagDTO> Tags { get; set; }

    }
}
