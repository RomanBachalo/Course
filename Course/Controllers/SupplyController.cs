using Course.Services;
using Course.Constants;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Course.Controllers
{
    [Route("[controller]")]
    public class SupplyController : Controller
    {
        private readonly ISupplyService _supplyService;
        private readonly IGetDataService _getDataService;

        public SupplyController(ISupplyService supplyService, IGetDataService getDataService)
        {
            _supplyService = supplyService;
            _getDataService = getDataService;
        }

        public IActionResult Index()
        {
            var supplyInfos = _supplyService.GetAllSupplyInfos();
            ViewBag.InfoList = supplyInfos;
            ViewBag.Columns = supplyInfos.FirstOrDefault()
                .GetType()
                .GetProperties()
                .Select(prop => prop.Name)
                .Where(prop => !prop.Contains("Id"))
                .ToList();

            ViewBag.Columns.Insert(0, "SupplyId");

            return View(StringConstants.ListView);
        }

        [HttpGet, Route("{id}")]
        public IActionResult GetSupplyInfoById([FromRoute] int id)
        {
            var supplyInfo = _supplyService.GetSupplyInfoById(id);
            ViewBag.Info = supplyInfo;
            ViewBag.Section = PropertyConstants.Supply;

            return View(StringConstants.DisplayView);
        }
    }
}
