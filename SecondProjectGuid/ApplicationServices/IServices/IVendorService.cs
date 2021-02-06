using SecondProjectGuid.DTOs.Vendors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecondProjectGuid.ApplicationServices.IServices
{
    public interface IVendorService
    {
        Task<bool> DeleteVendorById(string id);
        Task<VendorDTO> GetVendorById(string id);
        Task<int> Update(VendorUpdateDTO DTO, string Id);
        Task<VendorInsertResponseDTO> Insert(VendorInsertDTO dto);
    }
}
