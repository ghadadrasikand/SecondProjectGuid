﻿using SecondProjectGuid.DTOs.Vendors;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SecondProjectGuid.DTOs.Vendors
{
    public class VendorHistoryDTO:VendorInsertDTO
    {
        [Required]
        public string Id { get; set; }
    }
}
