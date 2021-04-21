using Course.Constants;
using Course.EntityFramework;
using Course.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Course.Controllers
{
    [Route("[controller]")]
    public class GetDataController : Controller
    {
        private readonly ISupplyService _supplyService;
        private readonly IProductionService _productionService;
        private readonly IOrderService _orderService;
        private readonly IGetDataService _getDataService;
        private readonly FurnitureCompanyContext _furnitureCompanyContext;

        public GetDataController(ISupplyService supplyService,
                                 IProductionService productionService,
                                 IOrderService orderService,
                                 IGetDataService getDataService,
                                 FurnitureCompanyContext furnitureCompanyContext)
        {
            _supplyService = supplyService;
            _productionService = productionService;
            _orderService = orderService;
            _getDataService = getDataService;
            _furnitureCompanyContext = furnitureCompanyContext;
        }

        [HttpGet, Route("{property}/{id}")]
        public IActionResult GetSupplyInfoById([FromRoute] string property, [FromRoute] int id)
        {
            object result = null;
            switch (property)
            {
                case PropertyConstants.City:
                    result = _furnitureCompanyContext.Cities.Where(model => model.CityId == id).FirstOrDefault();
                    break;
                case PropertyConstants.Color:
                    result = _furnitureCompanyContext.Colors.Where(model => model.ColorId == id).FirstOrDefault();
                    break;
                case PropertyConstants.Customer:
                    result = _furnitureCompanyContext.Customers.Where(model => model.CustomerId == id).FirstOrDefault();
                    break;
                case PropertyConstants.Employee:
                    result = _furnitureCompanyContext.Employees.Where(model => model.EmployeeId == id).FirstOrDefault();
                    break;
                case PropertyConstants.Factory:
                    result = _getDataService.GetFactoryInfoById(id);
                    break;
                case PropertyConstants.Furniture:
                    result = _getDataService.GetFurnitureInfoById(id);
                    break;
                case PropertyConstants.FurnitureSubtype:
                    result = _furnitureCompanyContext.FurnitureSubtypes.Where(model => model.FurnitureSubtypeId == id).FirstOrDefault();
                    break;
                case PropertyConstants.FurnitureType:
                    result = _furnitureCompanyContext.FurnitureTypes.Where(model => model.FurnitureTypeId == id).FirstOrDefault();
                    break;
                case PropertyConstants.Material:
                    result = _furnitureCompanyContext.Materials.Where(model => model.MaterialId == id).FirstOrDefault();
                    break;
                case PropertyConstants.MaterialType:
                    result = _furnitureCompanyContext.MaterialTypes.Where(model => model.MaterialTypeId == id).FirstOrDefault();
                    break;
                case PropertyConstants.Order:
                    result = _orderService.GetOrderInfoById(id);
                    break;
                case PropertyConstants.Position:
                    result = _furnitureCompanyContext.Positions.Where(model => model.PositionId == id).FirstOrDefault();
                    break;
                case PropertyConstants.Production:
                    result = _productionService.GetProductionInfoById(id);
                    break;
                case PropertyConstants.Region:
                    result = _furnitureCompanyContext.Regions.Where(model => model.RegionId == id).FirstOrDefault();
                    break;
                case PropertyConstants.Supplier:
                    result = _furnitureCompanyContext.Suppliers.Where(model => model.SupplierId == id).FirstOrDefault();
                    break;
                case PropertyConstants.Supply:
                    result = _supplyService.GetSupplyInfoById(id);
                    break;
            }

            if (result == null) throw new Exception($"{property} not found");

            ViewBag.Info = result;
            ViewBag.Section = property;

            return View(StringConstants.DisplayView);
        }
    }
}
