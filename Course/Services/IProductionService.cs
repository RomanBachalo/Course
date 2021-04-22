using Course.Models;
using Course.ViewModels;
using Course.ViewModels.CreateViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Course.Services
{
    public interface IProductionService
    {
        ProductionInfo GetProductionInfoById(int id);
        List<ProductionInfo> GetAllProductionsInfos();
        Production GetProductionById(int id);
        Task CreateProduction(ProductionViewModel model);
        Task UpdateProduction(ProductionViewModel model);
    }
}
