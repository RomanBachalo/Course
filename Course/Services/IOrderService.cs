using Course.Models;
using Course.ViewModels;
using Course.ViewModels.CreateViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Course.Services
{
    public interface IOrderService
    {
        OrderInfo GetOrderInfoById(int id);
        List<OrderInfo> GetAllOrdersInfo();
        Order GetOrderById(int id);
        Task CreateOrder(OrderViewModel model);
        Task UpdateOrder(OrderViewModel model);
    }
}
