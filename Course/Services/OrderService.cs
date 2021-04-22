﻿using Course.EntityFramework;
using Course.Models;
using Course.ViewModels;
using Course.ViewModels.CreateViewModels;
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

        public async Task CreateOrder(OrderViewModel model)
        {
            var order = new Order
            {
                CustomerId = model.CustomerId,
                EmployeeId = model.EmployeeId,
                TotalSum = 0,
                EndDate = DateTime.Now.AddDays(2),
                CreateDate = DateTime.Now,
                UpdateDate = DateTime.Now
            };

            await _furnitureCompanyContext.Orders.AddAsync(order);

            var orderedFurnitures = new List<OrderedFurniture>();
            var orderedMaterials = new List<OrderedMaterial>();

            for (int i = 0; i < model.OrderedFurniture.Count && i < model.OrderedMaterials.Count; ++i)
            //foreach (var pair in model.OrderedFurniture)
            {
                var orderedFurniture = new OrderedFurniture
                {
                    FurnitureId = model.OrderedFurniture.ElementAt(i).Key,
                    Amount = model.OrderedFurniture.ElementAt(i).Value,
                    OrderId = order.OrderId,
                    Height = 2,
                    Width = 1,
                    SizeSurchase = _furnitureCompanyContext.Furnitures.Where(fur => fur.FurnitureId == model.OrderedFurniture.ElementAt(i).Key).FirstOrDefault().BasePrice / 20,
                    CreateDate = DateTime.Now,
                    UpdateDate = DateTime.Now
                };

                orderedFurnitures.Add(orderedFurniture);

                await _furnitureCompanyContext.OrderedFurnitures.AddAsync(orderedFurniture);

                var orderedMaterial = new OrderedMaterial
                {
                    OrderedFurnitureId = orderedFurniture.OrderedFurnitureId,
                    MaterialColorId = model.OrderedMaterials.ElementAt(i).Key,
                    Amount = model.OrderedMaterials.ElementAt(i).Value,
                    CreateDate = DateTime.Now,
                    UpdateDate = DateTime.Now
                };

                orderedMaterials.Add(orderedMaterial);

                await _furnitureCompanyContext.OrderedMaterials.AddAsync(orderedMaterial);
            }

            decimal orderedFurnituresSum = orderedFurnitures
                .Sum(orFur => orFur.Amount * _furnitureCompanyContext.Furnitures
                    .Where(fur => fur.FurnitureId == orFur.FurnitureId)
                    .FirstOrDefault().BasePrice + orFur.SizeSurchase);

            decimal orderedMaterialsSum = (from orderedMaterial in _furnitureCompanyContext.OrderedMaterials
                                           join materialColor in _furnitureCompanyContext.MaterialColors on orderedMaterial.MaterialColorId equals materialColor.MaterialColorId
                                           join material in _furnitureCompanyContext.Materials on materialColor.MaterialId equals material.MaterialId
                                           where orderedMaterials.Select(mat => mat.MaterialColorId).Contains(orderedMaterial.MaterialColorId)
                                           group material by orderedMaterial.MaterialColorId into mGroup
                                           select mGroup.Sum(mater => mater.Price)).Sum();

            order.TotalSum = orderedFurnituresSum + orderedMaterialsSum;

            _furnitureCompanyContext.Orders.Update(order);
            await _furnitureCompanyContext.SaveChangesAsync();
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

        public async Task UpdateOrder(OrderViewModel model)
        {
            var order = _furnitureCompanyContext.Orders.Where(ord => ord.OrderId == model.OrderId).FirstOrDefault();

            order.CustomerId = model.CustomerId;
            order.EmployeeId = model.EmployeeId;
            order.EndDate = DateTime.Now.AddDays(2);
            order.UpdateDate = DateTime.Now;

            _furnitureCompanyContext.Orders.Update(order);

            var orderedFurnitures = new List<OrderedFurniture>();
            var orderedMaterials = new List<OrderedMaterial>();

            var oldOrderedFurnitures = _furnitureCompanyContext.OrderedFurnitures
                .Where(orFur => orFur.OrderId == model.OrderId)
                .ToList();

            var oldOrderedMaterials = _furnitureCompanyContext.OrderedMaterials
                .Where(orMat => oldOrderedFurnitures
                    .Select(orFur => orFur.OrderedFurnitureId)
                    .ToList()
                    .Contains((int)orMat.OrderedFurnitureId))
                .ToList();

            _furnitureCompanyContext.OrderedMaterials.RemoveRange(oldOrderedMaterials);
            _furnitureCompanyContext.OrderedFurnitures.RemoveRange(oldOrderedFurnitures);

            for (int i = 0; i < model.OrderedFurniture.Count && i < model.OrderedMaterials.Count; ++i)
            //foreach (var pair in model.OrderedFurniture)
            {
                var orderedFurniture = new OrderedFurniture
                {
                    FurnitureId = model.OrderedFurniture.ElementAt(i).Key,
                    Amount = model.OrderedFurniture.ElementAt(i).Value,
                    OrderId = order.OrderId,
                    Height = 2,
                    Width = 1,
                    SizeSurchase = _furnitureCompanyContext.Furnitures.Where(fur => fur.FurnitureId == model.OrderedFurniture.ElementAt(i).Key).FirstOrDefault().BasePrice / 20,
                    CreateDate = DateTime.Now,
                    UpdateDate = DateTime.Now
                };

                orderedFurnitures.Add(orderedFurniture);

                await _furnitureCompanyContext.OrderedFurnitures.AddAsync(orderedFurniture);

                var orderedMaterial = new OrderedMaterial
                {
                    OrderedFurnitureId = orderedFurniture.OrderedFurnitureId,
                    MaterialColorId = model.OrderedMaterials.ElementAt(i).Key,
                    Amount = model.OrderedMaterials.ElementAt(i).Value,
                    CreateDate = DateTime.Now,
                    UpdateDate = DateTime.Now
                };

                orderedMaterials.Add(orderedMaterial);

                await _furnitureCompanyContext.OrderedMaterials.AddAsync(orderedMaterial);
            }

            decimal orderedFurnituresSum = orderedFurnitures
                .Sum(orFur => orFur.Amount * _furnitureCompanyContext.Furnitures
                    .Where(fur => fur.FurnitureId == orFur.FurnitureId)
                    .FirstOrDefault().BasePrice + orFur.SizeSurchase);

            decimal orderedMaterialsSum = (from orderedMaterial in _furnitureCompanyContext.OrderedMaterials
                                           join materialColor in _furnitureCompanyContext.MaterialColors on orderedMaterial.MaterialColorId equals materialColor.MaterialColorId
                                           join material in _furnitureCompanyContext.Materials on materialColor.MaterialId equals material.MaterialId
                                           where orderedMaterials.Select(mat => mat.MaterialColorId).Contains(orderedMaterial.MaterialColorId)
                                           group material by orderedMaterial.MaterialColorId into mGroup
                                           select mGroup.Sum(mater => mater.Price)).Sum();

            order.TotalSum = orderedFurnituresSum + orderedMaterialsSum;

            _furnitureCompanyContext.Orders.Update(order);
            await _furnitureCompanyContext.SaveChangesAsync();
        }
    }
}
