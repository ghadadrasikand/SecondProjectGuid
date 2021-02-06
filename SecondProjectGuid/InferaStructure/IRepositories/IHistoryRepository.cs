using SecondProjectGuid.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecondProjectGuid.InferaStructure.IRepositories
{
    public interface IHistoryRepository
    {
        Task<int> Insert(History history);
    }
}
