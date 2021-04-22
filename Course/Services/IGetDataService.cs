using Course.Models;
using Course.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Course.Services
{
    public interface IGetDataService
    {
        FactoryInfo GetFactoryInfoById(int id);
        List<FactoryInfo> GetAllFactoryInfos();
        Factory GetFactoryById(int id);
        MaterialInfo GetMaterialInfoById(int id);
        List<MaterialInfo> GetAllMaterialInfos();
        Material GetMaterialById(int id);
        FurnitureInfo GetFurnitureInfoById(int id);
        List<FurnitureInfo> GetAllFurnitureInfos();
        Furniture GetFurnitureById(int id);
        object GetDataByPropertyAndId(string property, int id);
    }
}
