using Course.EntityFramework;
using Course.Models;
using Course.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Course.Services
{
    public class ProductionService : IProductionService
    {
        private readonly FurnitureCompanyContext _furnitureCompanyContext;

        public ProductionService(FurnitureCompanyContext furnitureCompanyContext)
        {
            _furnitureCompanyContext = furnitureCompanyContext;
        }

        public Task CreateProduction()
        {
            throw new NotImplementedException();
        }

        public List<ProductionInfo> GetAllProductionsInfos()
        {
            var productionInfos = from production in _furnitureCompanyContext.Productions
                              join orderedFurniture in _furnitureCompanyContext.OrderedFurnitures on production.OrderedFurnitureId equals orderedFurniture.OrderedFurnitureId
                              join furniture in _furnitureCompanyContext.Furnitures on orderedFurniture.FurnitureId equals furniture.FurnitureId
                              join production_Employee in _furnitureCompanyContext.ProductionEmployees on production.ProductionId equals production_Employee.ProductionId
                              join employee in _furnitureCompanyContext.Employees on production_Employee.EmployeeId equals employee.EmployeeId
                              join factory in _furnitureCompanyContext.Factories on employee.FactoryId equals factory.FactoryId
                              join materialsInProduction in _furnitureCompanyContext.MaterialsInProductions on production.ProductionId equals materialsInProduction.ProductionId
                              join materialsAtFactory in _furnitureCompanyContext.MaterialsAtFactories on materialsInProduction.MaterialsAtFactoryId equals materialsAtFactory.MaterialsAtFactoryId
                              join materialColor in _furnitureCompanyContext.MaterialColors on materialsAtFactory.MaterialColorId equals materialColor.MaterialColorId
                              join material in _furnitureCompanyContext.Materials on materialColor.MaterialId equals material.MaterialId
                              orderby production.ProductionId
                              select new ProductionInfo
                              {
                                  ProductionId = production.ProductionId,
                                  EmployeeId = employee.EmployeeId,
                                  EmployeeName = employee.FullName,
                                  FactoryId = factory.FactoryId,
                                  FactoryName = factory.Name,
                                  FurnitureId = furniture.FurnitureId,
                                  FurnitureName = furniture.Name,
                                  FurnitureAmount = orderedFurniture.Amount,
                                  MaterialId = material.MaterialId,
                                  MaterialName = material.Name,
                                  MaterialAmount = materialsInProduction.Count,
                                  StartDate = production.StartDate,
                                  EndDate = production.EndDate
                              };

            if (productionInfos == null) throw new Exception("Production Infos not found");

            return productionInfos.ToList();
        }

        public Production GetProductionById(int id)
        {
            var production = _furnitureCompanyContext.Productions.Where(prod => prod.ProductionId == id).FirstOrDefault();

            if (production == null) throw new Exception("Production not found");

            return production;
        }

        public ProductionInfo GetProductionInfoById(int id)
        {
            var productionInfo = GetAllProductionsInfos().Where(info => info.ProductionId == id).FirstOrDefault();

            if (productionInfo == null) throw new Exception("Production Info not found");

            return productionInfo;
        }

        public Task UpdateProduction()
        {
            throw new NotImplementedException();
        }
    }
}
