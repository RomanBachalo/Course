using Course.EntityFramework;
using Course.Models;
using Course.ViewModels;
using Course.ViewModels.CreateViewModels;
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

        public async Task CreateSupply(SupplyViewModel model)
        {
            var supply = new Supply
            {
                SupplierId = model.SupplierId,
                EmployeeId = model.EmployeeId,
                TotalSum = 0,
                EndDate = DateTime.Now.AddDays(2),
                CreateDate = DateTime.Now,
                UpdateDate = DateTime.Now
            };

            await _furnitureCompanyContext.Supplies.AddAsync(supply);
            await _furnitureCompanyContext.SaveChangesAsync();

            var suppliedMaterial = new SuppliedMaterial
            {
                SupplyId = supply.SupplyId,
                MaterialColorId = model.MaterialId,
                Amount = model.MaterialAmount,
                CreateDate = DateTime.Now,
                UpdateDate = DateTime.Now
            };

            suppliedMaterial.SupplierPrice = (from materialColor in _furnitureCompanyContext.MaterialColors
                                              join material in _furnitureCompanyContext.Materials on materialColor.MaterialId equals material.MaterialId
                                              where materialColor.MaterialColorId == model.MaterialId
                                              select material.Price).Sum() * model.MaterialAmount;


            supply.TotalSum = suppliedMaterial.SupplierPrice;

            _furnitureCompanyContext.Supplies.Update(supply);
            await _furnitureCompanyContext.SaveChangesAsync();
            await _furnitureCompanyContext.SuppliedMaterials.AddAsync(suppliedMaterial);
            await _furnitureCompanyContext.SaveChangesAsync();

            var supplyRealization = new SupplyRealization
            {
                SuppliedMaterialsId = suppliedMaterial.SuppliedMaterialsId,
                MaterialsAtFactoryId = _furnitureCompanyContext.MaterialsAtFactories.OrderBy(maf => maf.MaterialsAtFactoryId).LastOrDefault().MaterialsAtFactoryId,
                EmployeeId = supply.EmployeeId,
                Count = (short)(suppliedMaterial.Amount + _furnitureCompanyContext.MaterialsAtFactories.OrderBy(maf => maf.MaterialsAtFactoryId).LastOrDefault().Count),
                CreateDate = DateTime.Now,
                UpdateDate = DateTime.Now
            };

            await _furnitureCompanyContext.SupplyRealizations.AddAsync(supplyRealization);

            await _furnitureCompanyContext.SaveChangesAsync();
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

        public async Task UpdateSupply(SupplyViewModel model)
        {
            var supply = _furnitureCompanyContext.Supplies.Where(sup => sup.SupplyId == model.SupplyId).FirstOrDefault();

            supply.SupplierId = model.SupplierId;
            supply.EmployeeId = model.EmployeeId;

            var oldSuppliedMaterials = _furnitureCompanyContext.SuppliedMaterials.Where(supMaterial => supMaterial.SupplyId == model.SupplyId).ToList();

            foreach (var supplyMaterial in oldSuppliedMaterials)
            {
                var supplyRealizations = _furnitureCompanyContext.SupplyRealizations
                    .Where(real => real.SuppliedMaterialsId == supplyMaterial.SuppliedMaterialsId);

                if (supplyRealizations != null)
                {
                    _furnitureCompanyContext.SupplyRealizations.RemoveRange(supplyRealizations);
                }
            }

            _furnitureCompanyContext.SuppliedMaterials.RemoveRange(oldSuppliedMaterials);
            await _furnitureCompanyContext.SaveChangesAsync();

            var suppliedMaterial = new SuppliedMaterial
            {
                SupplyId = supply.SupplyId,
                MaterialColorId = model.MaterialId,
                Amount = model.MaterialAmount,
                CreateDate = DateTime.Now,
                UpdateDate = DateTime.Now
            };

            suppliedMaterial.SupplierPrice = (from materialColor in _furnitureCompanyContext.MaterialColors
                                              join material in _furnitureCompanyContext.Materials on materialColor.MaterialId equals material.MaterialId
                                              where materialColor.MaterialColorId == model.MaterialId
                                              select material.Price).Sum() * model.MaterialAmount;

            supply.TotalSum = _furnitureCompanyContext.SuppliedMaterials
                .Where(supMat => supMat.SupplyId == supply.SupplyId)
                .Sum(supMaterial => supMaterial.SupplierPrice);

            _furnitureCompanyContext.Supplies.Update(supply);
            await _furnitureCompanyContext.SuppliedMaterials.AddAsync(suppliedMaterial);
            await _furnitureCompanyContext.SaveChangesAsync();

            var supplyRealization = new SupplyRealization
            {
                SuppliedMaterialsId = suppliedMaterial.SuppliedMaterialsId,
                MaterialsAtFactoryId = _furnitureCompanyContext.MaterialsAtFactories.Last().MaterialsAtFactoryId,
                EmployeeId = supply.EmployeeId,
                Count = (short)(suppliedMaterial.Amount + _furnitureCompanyContext.MaterialsAtFactories.Last().Count),
                CreateDate = DateTime.Now,
                UpdateDate = DateTime.Now
            };

            await _furnitureCompanyContext.SupplyRealizations.AddAsync(supplyRealization);

            await _furnitureCompanyContext.SaveChangesAsync();
        }
    }
}
