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
    public class ProductionController : Controller
    {
        private readonly IProductionService _productionService;
        private readonly IGetDataService _getDataService;

        public ProductionController(IProductionService productionService, IGetDataService getDataService)
        {
            _productionService = productionService;
            _getDataService = getDataService;
        }

        public IActionResult Index()
        {
            var supplyInfos = _productionService.GetAllProductionsInfos();
            ViewBag.InfoList = supplyInfos;
            ViewBag.Columns = supplyInfos.GetType().GetProperties().Select(prop => prop.Name).Where(prop => !prop.Contains("Id")).ToList();
            ViewBag.Columns.Insert(0, "SupplyId");

            return View(StringConstants.ListView);
        }

        [HttpGet, Route("{id}")]
        public IActionResult GetProductionInfoById([FromRoute] int id)
        {
            var supplyInfo = _productionService.GetProductionInfoById(id);
            ViewBag.SupplyInfo = supplyInfo;

            return View(StringConstants.DisplayView);
        }
    }
}
