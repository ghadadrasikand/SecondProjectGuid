using Microsoft.EntityFrameworkCore;
using SecondProjectGuid.Contexts;
using SecondProjectGuid.InferaStructure.IRepositories;
using SecondProjectGuid.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecondProjectGuid.InferaStructure.Repositories
{
    public class VendorRepository:IVendorRepository
    { 
        private readonly ProjectContext _db;

        public VendorRepository(ProjectContext db)
        {
            _db = db;
        }
        public async Task<Vendor> GetVendorById(string id)
        {
            return await _db.Vendor.Where(v => v.Id == id).Include(t => t.Tags).SingleOrDefaultAsync();
        }

        public async Task<Vendor> DeleteById(string id)
        {
            var vendor = await _db.Vendor.Where(x => x.Id == id).FirstOrDefaultAsync();      
            _db.Vendor.Remove(vendor);
            await _db.SaveChangesAsync();
            return vendor;
        }
        public async Task<int> Update(Vendor vendor, History history)
        {
            _db.Vendor.Update(vendor);
            _db.History.Add(history);
            return await _db.SaveChangesAsync();
        }
        public async Task<Vendor> Insert(Vendor vendor)
        {
            await _db.Vendor.AddAsync(vendor);
            await _db.SaveChangesAsync();
            return vendor;
        }
        public async Task<int> SaveChangeAsync()
        {
            return await _db.SaveChangesAsync();
        }
    }
}
