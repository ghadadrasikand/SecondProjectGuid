using SecondProjectGuid.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecondProjectGuid.InferaStructure.IRepositories
{
    public interface IVendorRepository
    {
        Task<Vendor> DeleteById(string id);
        Task<Vendor> GetVendorById(string id);
        Task<int> Update(Vendor vendor, History history);
        Task<Vendor> Insert(Vendor vendor);
        Task<int> SaveChangeAsync();
    }
}
