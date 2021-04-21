using Course.Constants;
using Course.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Course.Controllers
{
    [Route("[controller]")]
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IGetDataService _getDataService;

        public OrderController(IOrderService orderService, IGetDataService getDataService)
        {
            _orderService = orderService;
            _getDataService = getDataService;
        }

        public IActionResult Index()
        {
            var orderInfos = _orderService.GetAllOrdersInfo();
            ViewBag.InfoList = orderInfos;
            ViewBag.Columns = orderInfos.GetType().GetProperties().Select(prop => prop.Name).Where(prop => !prop.Contains("Id")).ToList();
            ViewBag.Columns.Insert(0, "OrderId");

            return View(StringConstants.ListView);
        }

        [HttpGet, Route("{id}")]
        public IActionResult GetOrderInfoById([FromRoute] int id)
        {
            var orderInfo = _orderService.GetOrderInfoById(id);
            ViewBag.Info = orderInfo;

            return View(StringConstants.DisplayView);
        }
    }
}
