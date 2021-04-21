using Course.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Course.Controllers
{
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

            return View(supplyInfos);
        }

        public IActionResult GetSupplyInfoById([FromRoute] int id)
        {
            var supplyInfo = _supplyService.GetSupplyInfoById(id);

            return View("", supplyInfo);
        }
    }
}
