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
        public IActionResult GetDataByPropertyAndId([FromRoute] string property, [FromRoute] int id)
        {
            object result = _getDataService.GetDataByPropertyAndId(property, id);

            ViewBag.Info = result;
            ViewBag.Section = property;

            return View(StringConstants.DisplayView);
        }
    }
}
