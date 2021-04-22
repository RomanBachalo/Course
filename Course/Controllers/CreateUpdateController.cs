using Course.Constants;
using Course.EntityFramework;
using Course.Models;
using Course.Services;
using Course.ViewModels.CreateViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Course.Controllers
{
    public class CreateUpdateController : Controller
    {
        private readonly FurnitureCompanyContext _furnitureCompanyContext;
        private readonly ISupplyService _supplyService;
        private readonly IOrderService _orderService;
        private readonly IProductionService _productionService;

        public CreateUpdateController(FurnitureCompanyContext furnitureCompanyContext,
                                      ISupplyService supplyService,
                                      IOrderService orderService,
                                      IProductionService productionService)
        {
            _furnitureCompanyContext = furnitureCompanyContext;
            _supplyService = supplyService;
            _orderService = orderService;
            _productionService = productionService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] object model)
        {
            switch (model.GetType().Name.Replace(StringConstants.ViewModel, ""))
            {
                case PropertyConstants.City:
                    var cityModel = model as CityViewModel;

                    var city = new City
                    {
                        Name = cityModel.CityName,
                        RegionId = cityModel.RegionId,
                        CreateDate = DateTime.Now,
                        UpdateDate = DateTime.Now
                    };

                    await _furnitureCompanyContext.Cities.AddAsync(city);
                    await _furnitureCompanyContext.SaveChangesAsync();

                    break;
                case PropertyConstants.Color:
                    var colorModel = model as ColorViewModel;

                    var color = new Color
                    {
                        Name = colorModel.ColorName,
                        CreateDate = DateTime.Now,
                        UpdateDate = DateTime.Now
                    };

                    await _furnitureCompanyContext.Colors.AddAsync(color);
                    await _furnitureCompanyContext.SaveChangesAsync();

                    break;
                case PropertyConstants.Customer:
                    var customerModel = model as CustomerViewModel;

                    var customer = new Customer
                    {
                        Name = customerModel.CustomerName,
                        PhoneNumber = customerModel.PhoneNumber,
                        CreateDate = DateTime.Now,
                        UpdateDate = DateTime.Now
                    };

                    await _furnitureCompanyContext.Customers.AddAsync(customer);
                    await _furnitureCompanyContext.SaveChangesAsync();

                    break;
                case PropertyConstants.Employee:
                    var employeeModel = model as EmployeeViewModel;

                    var employee = new Employee
                    {
                        FullName = employeeModel.EmployeeName,
                        FactoryId = employeeModel.FactoryId,
                        PositionId = employeeModel.PositionId,
                        Email = employeeModel.Email,
                        PhoneNumber = employeeModel.PhoneNumber,
                        CreateDate = DateTime.Now,
                        UpdateDate = DateTime.Now
                    };

                    await _furnitureCompanyContext.Employees.AddAsync(employee);
                    await _furnitureCompanyContext.SaveChangesAsync();

                    break;
                case PropertyConstants.Factory:
                    var factoryModel = model as FactoryViewModel;

                    var factory = new Factory
                    {
                        Name = factoryModel.FactoryName,
                        CityId = factoryModel.CityId,
                        Address = factoryModel.Address,
                        CreateDate = DateTime.Now,
                        UpdateDate = DateTime.Now
                    };

                    await _furnitureCompanyContext.Factories.AddAsync(factory);
                    await _furnitureCompanyContext.SaveChangesAsync();

                    break;
                case PropertyConstants.Furniture:
                    var furnitureModel = model as FurnitureViewModel;

                    var furniture = new Furniture
                    {
                        Name = furnitureModel.FurnitureName,
                        FurnitureSubtypeId = furnitureModel.FurnitureSubtypeId,
                        BasePrice = furnitureModel.BasePrice,
                        Description = furnitureModel.Description,
                        CreateDate = DateTime.Now,
                        UpdateDate = DateTime.Now
                    };

                    await _furnitureCompanyContext.Furnitures.AddAsync(furniture);
                    await _furnitureCompanyContext.SaveChangesAsync();

                    break;
                case PropertyConstants.FurnitureSubtype:
                    var furnitureSubtypeModel = model as FurnitureSubtypeViewModel;

                    var furnitureSubtype = new FurnitureSubtype
                    {
                        Name = furnitureSubtypeModel.FurnitureSubtypeName,
                        FurnitureTypeId = furnitureSubtypeModel.FurnitureTypeId,
                        CreateDate = DateTime.Now,
                        UpdateDate = DateTime.Now
                    };

                    await _furnitureCompanyContext.FurnitureSubtypes.AddAsync(furnitureSubtype);
                    await _furnitureCompanyContext.SaveChangesAsync();

                    break;
                case PropertyConstants.FurnitureType:
                    var furnitureTypeModel = model as FurnitureTypeViewModel;

                    var furnitureType = new FurnitureType
                    {
                        Name = furnitureTypeModel.FurnitureTypeName,
                        CreateDate = DateTime.Now,
                        UpdateDate = DateTime.Now
                    };

                    await _furnitureCompanyContext.FurnitureTypes.AddAsync(furnitureType);
                    await _furnitureCompanyContext.SaveChangesAsync();

                    break;
                case PropertyConstants.Material:
                    var materialModel = model as MaterialViewModel;

                    var material = new Material
                    {
                        Name = materialModel.MaterialName,
                        MaterialTypeId = materialModel.MaterialTypeId,
                        Description = materialModel.Description,
                        Price = materialModel.Price,
                        CreateDate = DateTime.Now,
                        UpdateDate = DateTime.Now
                    };

                    await _furnitureCompanyContext.Materials.AddAsync(material);

                    var materialColor = new MaterialColor
                    {
                        MaterialId = material.MaterialId,
                        ColorId = materialModel.ColorId,
                        CreateDate = DateTime.Now,
                        UpdateDate = DateTime.Now
                    };

                    await _furnitureCompanyContext.MaterialColors.AddAsync(materialColor);

                    await _furnitureCompanyContext.SaveChangesAsync();

                    break;
                case PropertyConstants.MaterialType:
                    var materialTypeModel = model as MaterialTypeViewModel;

                    var materilalType = new MaterialType
                    {
                        Name = materialTypeModel.MaterialTypeName,
                        CreateDate = DateTime.Now,
                        UpdateDate = DateTime.Now
                    };

                    await _furnitureCompanyContext.MaterialTypes.AddAsync(materilalType);
                    await _furnitureCompanyContext.SaveChangesAsync();

                    break;
                case PropertyConstants.Order:
                    var orderModel = model as OrderViewModel;

                    await _orderService.CreateOrder();

                    break;
                case PropertyConstants.Production:
                    var productionModel = model as ProductionViewModel;

                    await _productionService.CreateProduction();

                    break;
                case PropertyConstants.Position:
                    var positionModel = model as PositionViewModel;

                    var position = new Position
                    {
                        Name = positionModel.PositionName,
                        CreateDate = DateTime.Now,
                        UpdateDate = DateTime.Now
                    };

                    await _furnitureCompanyContext.Positions.AddAsync(position);
                    await _furnitureCompanyContext.SaveChangesAsync();

                    break;
                case PropertyConstants.Region:
                    var regionModel = model as RegionViewModel;

                    var region = new Region
                    {
                        Name = regionModel.RegionName,
                        CreateDate = DateTime.Now,
                        UpdateDate = DateTime.Now
                    };

                    await _furnitureCompanyContext.Regions.AddAsync(region);
                    await _furnitureCompanyContext.SaveChangesAsync();

                    break;
                case PropertyConstants.Supplier:
                    var supplierModel = model as SupplierViewModel;

                    var supplier = new Supplier
                    {
                        Name = supplierModel.SupplierName,
                        CityId = supplierModel.CityId,
                        Email = supplierModel.Email,
                        PhoneNumber = supplierModel.PhoneNumber,
                        Address = supplierModel.Address,
                        CreateDate = DateTime.Now,
                        UpdateDate = DateTime.Now
                    };

                    await _furnitureCompanyContext.Suppliers.AddAsync(supplier);
                    await _furnitureCompanyContext.SaveChangesAsync();

                    break;
                case PropertyConstants.Supply:
                    var supplyModel = model as SupplyViewModel;

                    await _supplyService.CreateSupply();

                    break;
            }

            return null;
        }
    }
}
