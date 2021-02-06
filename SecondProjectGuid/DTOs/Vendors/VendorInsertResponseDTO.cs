using SecondProjectGuid.DTOs.Histories;
using SecondProjectGuid.DTOs.Vendors;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SecondProjectGuid.DTOs.Vendors
{
    public class VendorInsertResponseDTO : VendorInsertDTO
    {
        public VendorInsertResponseDTO()
        {
            Histories = new List<HistoryDTO>();
        }
        [Required]
        public string Id { get; set; }
        public List<HistoryDTO> Histories { get; set; }
    }
}
