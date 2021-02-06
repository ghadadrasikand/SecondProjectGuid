using SecondProjectGuid.Contexts;
using SecondProjectGuid.InferaStructure.IRepositories;
using SecondProjectGuid.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecondProjectGuid.InferaStructure.Repositories
{
    public class HistoryRepository:IHistoryRepository
    {
        private readonly ProjectContext _db;

        public HistoryRepository(ProjectContext db)
        {
            _db = db;
        }

        public async Task<int> Insert(History history)
        {
            await _db.History.AddAsync(history);
            return await _db.SaveChangesAsync();
        }
    }
}
