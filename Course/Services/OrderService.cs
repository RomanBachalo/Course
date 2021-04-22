using Course.EntityFramework;
using Course.Models;
using Course.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Course.Services
{
    public class OrderService : IOrderService
    {
        private readonly FurnitureCompanyContext _furnitureCompanyContext;
        public OrderService(FurnitureCompanyContext furnitureCompanyContext)
        {
            _furnitureCompanyContext = furnitureCompanyContext ?? throw new ArgumentNullException(nameof(furnitureCompanyContext));
        }

        public Task CreateOrder()
        {
            throw new NotImplementedException();
        }

        public List<OrderInfo> GetAllOrdersInfo()
        {
            var orderInfos = from order in _furnitureCompanyContext.Orders
                        join customer in _furnitureCompanyContext.Customers on order.CustomerId equals customer.CustomerId
                        join employee in _furnitureCompanyContext.Employees on order.EmployeeId equals employee.EmployeeId
                        join factory in _furnitureCompanyContext.Factories on employee.FactoryId equals factory.FactoryId
                        join orderedFurniture in _furnitureCompanyContext.OrderedFurnitures on order.OrderId equals orderedFurniture.OrderId
                        join furniture in _furnitureCompanyContext.Furnitures on orderedFurniture.FurnitureId equals furniture.FurnitureId
                        join orderedMaterials in _furnitureCompanyContext.OrderedMaterials on orderedFurniture.OrderedFurnitureId equals orderedMaterials.OrderedFurnitureId
                        join materialColor in _furnitureCompanyContext.MaterialColors on orderedMaterials.MaterialColorId equals materialColor.MaterialColorId
                        join material in _furnitureCompanyContext.Materials on materialColor.MaterialId equals material.MaterialId
                        orderby order.OrderId
                        select new OrderInfo
                        {
                            OrderId = order.OrderId,
                            CustomerId = customer.CustomerId,
                            CustomerName = customer.Name,
                            EmployeeId = employee.EmployeeId,
                            EmployeeName = employee.FullName,
                            FactoryId = factory.FactoryId,
                            FactoryName = factory.Name,
                            FurnitureId = furniture.FurnitureId,
                            FurnitureName = furniture.Name,
                            FurnitureHeight = orderedFurniture.Height,
                            FurnitureWidth = orderedFurniture.Width,
                            SizeSurchase = orderedFurniture.SizeSurchase,
                            FurnitureAmount = orderedFurniture.Amount,
                            MaterialId = material.MaterialId,
                            MaterialName = material.Name,
                            MaterialAmount = orderedMaterials.Amount,
                            TotalSum = order.TotalSum,
                            EndDate = order.EndDate
                        };

            if (orderInfos == null) throw new Exception("Order Infos not found");

            return orderInfos.ToList();
        }

        public Order GetOrderById(int id)
        {
            var order = _furnitureCompanyContext.Orders.Where(ord => ord.OrderId == id).FirstOrDefault();

            if (order == null) throw new Exception("Order not found");

            return order;
        }

        public OrderInfo GetOrderInfoById(int id)
        {
            var orderInfo = GetAllOrdersInfo().Where(info => info.OrderId == id).FirstOrDefault();

            if (orderInfo == null) throw new Exception("Order Info not found");

            return orderInfo;
        }

        public Task UpdateOrder()
        {
            throw new NotImplementedException();
        }
    }
}
