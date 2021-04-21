using Course.Models;
using Course.ViewModels;
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
    }
}
