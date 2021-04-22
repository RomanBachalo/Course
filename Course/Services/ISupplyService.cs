using Course.Models;
using Course.ViewModels;
using Course.ViewModels.CreateViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Course.Services
{
    public interface ISupplyService
    {
        SupplyInfo GetSupplyInfoById(int id);
        List<SupplyInfo> GetAllSupplyInfos();
        Supply GetSupplyById(int id);
        Task CreateSupply(SupplyViewModel model);
        Task UpdateSupply(SupplyViewModel model);
    }
}
