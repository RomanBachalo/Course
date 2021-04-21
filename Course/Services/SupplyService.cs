using Course.EntityFramework;
using Course.Models;
using Course.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Course.Services
{
    public class SupplyService : ISupplyService
    {
        private readonly FurnitureCompanyContext _furnitureCompanyContext;

        public SupplyService(FurnitureCompanyContext furnitureCompanyContext)
        {
            _furnitureCompanyContext = furnitureCompanyContext;
        }

        public List<SupplyInfo> GetAllSupplyInfos()
        {
            var supplyInfos = from supply in _furnitureCompanyContext.Supplies
                             join supplier in _furnitureCompanyContext.Suppliers on supply.SupplierId equals supplier.SupplierId
                             join suppliedMaterials in _furnitureCompanyContext.SuppliedMaterials on supply.SupplyId equals suppliedMaterials.SupplyId
                             join materialColor in _furnitureCompanyContext.MaterialColors on suppliedMaterials.MaterialColorId equals materialColor.MaterialColorId
                             join material in _furnitureCompanyContext.Materials on materialColor.MaterialId equals material.MaterialId
                             join materialType in _furnitureCompanyContext.MaterialTypes on material.MaterialTypeId equals materialType.MaterialTypeId
                             join employee in _furnitureCompanyContext.Employees on supply.EmployeeId equals employee.EmployeeId
                             join factory in _furnitureCompanyContext.Factories on employee.FactoryId equals factory.FactoryId
                             orderby supply.SupplyId
                             select new SupplyInfo
                             {
                                 SupplyId = supply.SupplyId,
                                 EmployeeId = employee.EmployeeId,
                                 EmployeeName = employee.FullName,
                                 SupplierId = supplier.SupplierId,
                                 SupplierName = supplier.Name,
                                 FactoryId = factory.FactoryId,
                                 FactoryName = factory.Name,
                                 MaterialId = material.MaterialId,
                                 MaterialName = material.Name,
                                 MaterialTypeId = materialType.MaterialTypeId,
                                 MaterialTypeName = materialType.Name,
                                 MaterialAmount = suppliedMaterials.Amount,
                                 SupplierPrice = suppliedMaterials.SupplierPrice,
                                 TotalSum = supply.TotalSum,
                                 EndDate = supply.EndDate
                             };

            if (supplyInfos == null) throw new Exception("Supply Infos not found");

            return supplyInfos.ToList();
        }

        public Supply GetSupplyById(int id)
        {
            var supply = _furnitureCompanyContext.Supplies.Where(sup => sup.SupplyId == id).FirstOrDefault();

            if (supply == null) throw new Exception("Supply not found");

            return supply;
        }

        public SupplyInfo GetSupplyInfoById(int id)
        {
            var supplyInfo = GetAllSupplyInfos().Where(info => info.SupplyId == id).FirstOrDefault();

            if (supplyInfo == null) throw new Exception("Supply Info not found");

            return supplyInfo;
        }
    }
}
