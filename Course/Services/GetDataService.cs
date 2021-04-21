using Course.EntityFramework;
using Course.Models;
using Course.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Course.Services
{
    public class GetDataService : IGetDataService
    {
        private readonly FurnitureCompanyContext _furnitureCompanyContext;

        public GetDataService(FurnitureCompanyContext furnitureCompanyContext)
        {
            _furnitureCompanyContext = furnitureCompanyContext;
        }

        public List<FactoryInfo> GetAllFactoryInfos()
        {
            var materialInfos = from factory in _furnitureCompanyContext.Factories
                                join city in _furnitureCompanyContext.Cities on factory.CityId equals city.CityId
                                join region in _furnitureCompanyContext.Regions on city.RegionId equals region.RegionId
                                orderby factory.FactoryId
                                select new FactoryInfo
                                {
                                    FactoryId = factory.FactoryId,
                                    FactoryName = factory.Name,
                                    FactoryAddress = factory.Address,
                                    CityId = city.CityId,
                                    CityName = city.Name,
                                    RegionId = region.RegionId,
                                    RegionName = region.Name,
                                    Employees = _furnitureCompanyContext.Employees.Where(emp => emp.FactoryId == factory.FactoryId).ToList()
                                };

            if (materialInfos == null) throw new Exception("Factory Infos not found");

            return materialInfos.ToList();
        }

        public List<MaterialInfo> GetAllMaterialInfos()
        {
            var materialInfos = from material in _furnitureCompanyContext.Materials
                                join materialType in _furnitureCompanyContext.MaterialTypes on material.MaterialTypeId equals materialType.MaterialTypeId
                                join materialColor in _furnitureCompanyContext.MaterialColors on material.MaterialId equals materialColor.MaterialId
                                join color in _furnitureCompanyContext.Colors on materialColor.ColorId equals color.ColorId
                                orderby material.MaterialId
                                select new MaterialInfo
                                {
                                    MaterialId = material.MaterialId,
                                    MaterialName = material.Name,
                                    MaterialDescription = material.Description,
                                    MaterialTypeId = materialType.MaterialTypeId,
                                    MaterialTypeName = materialType.Name,
                                    MaterialPrice = material.Price,
                                    ColorId = color.ColorId,
                                    ColorName = color.Name
                                };

            if (materialInfos == null) throw new Exception("Material Infos not found");

            return materialInfos.ToList();
        }

        public Factory GetFactoryById(int id)
        {
            var factory = _furnitureCompanyContext.Factories.Where(ord => ord.FactoryId == id).FirstOrDefault();

            if (factory == null) throw new Exception("Factory not found");

            return factory;
        }

        public FactoryInfo GetFactoryInfoById(int id)
        {
            var factoryInfo = GetAllFactoryInfos().Where(info => info.FactoryId == id).FirstOrDefault();

            if (factoryInfo == null) throw new Exception("Factory Info not found");

            return factoryInfo;
        }

        public Furniture GetFurnitureById(int id)
        {
            var furniture = _furnitureCompanyContext.Furnitures.Where(ord => ord.FurnitureId == id).FirstOrDefault();

            if (furniture == null) throw new Exception("Furniture not found");

            return furniture;
        }

        public FurnitureInfo GetFurnitureInfoById(int id)
        {
            var furnitureInfo = GetAllFurnitureInfos().Where(info => info.FurnitureId == id).FirstOrDefault();

            if (furnitureInfo == null) throw new Exception("Furniture Info not found");

            return furnitureInfo;
        }

        public List<FurnitureInfo> GetAllFurnitureInfos()
        {
            var furnitureInfos = from furniture in _furnitureCompanyContext.Furnitures
                                 join furnitureSubtype in _furnitureCompanyContext.FurnitureSubtypes on furniture.FurnitureSubtypeId equals furnitureSubtype.FurnitureSubtypeId
                                 join furnitureType in _furnitureCompanyContext.FurnitureTypes on furnitureSubtype.FurnitureTypeId equals furnitureType.FurnitureTypeId
                                 join parameter_Furniture in _furnitureCompanyContext.FurnitureParameterFurnitures on furniture.FurnitureId equals parameter_Furniture.FurnitureId
                                 join parameterValue in _furnitureCompanyContext.FurnitureParameterValues on parameter_Furniture.FurnitureParameterValueId equals parameterValue.FurnitureParameterValueId
                                 join furnitureParameter in _furnitureCompanyContext.FurnitureParameters on parameterValue.FurnitureParameterId equals furnitureParameter.FurnitureParameterId
                                 orderby furniture.FurnitureId
                                 select new FurnitureInfo
                                 {
                                     FurnitureId = furniture.FurnitureId,
                                     FurnitureName = furniture.Name,
                                     FurnitureDescription = furniture.Description,
                                     FurnitureTypeId = furnitureType.FurnitureTypeId,
                                     FurnitureTypeName = furnitureType.Name,
                                     FurnitureSubtypeId = furnitureSubtype.FurnitureSubtypeId,
                                     FurnitureSubtypeName = furnitureSubtype.Name,
                                     FurnitureBasePrice = furniture.BasePrice,
                                     FurnitureParameterName = furnitureParameter.Name,
                                     FurnitureParameterValue = parameterValue.Value
                                 };

            if (furnitureInfos == null) throw new Exception("Furniture Infos not found");

            return furnitureInfos.ToList();
        }

        public Material GetMaterialById(int id)
        {
            var material = _furnitureCompanyContext.Materials.Where(ord => ord.MaterialId == id).FirstOrDefault();

            if (material == null) throw new Exception("Material not found");

            return material;
        }

        public MaterialInfo GetMaterialInfoById(int id)
        {
            var materialInfo = GetAllMaterialInfos().Where(info => info.MaterialId == id).FirstOrDefault();

            if (materialInfo == null) throw new Exception("Material Info not found");

            return materialInfo;
        }
    }
}
