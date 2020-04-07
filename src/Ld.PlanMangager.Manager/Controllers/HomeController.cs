using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Ld.PlanMangager.Manager.Models;
using Ld.PlanMangager.Application.Dto.Plan;
using Ld.PlanMangager.Repository.Interface.Plan;
using Ld.PlanMangager.Application.Plan;

namespace Ld.PlanMangager.Manager.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            PlanTypeDto planTypeDto = new PlanTypeDto();
            planTypeDto.Name = "test1";
            planTypeDto.Level = 1;
            planTypeDto.Description = "test";

            new PlanTypeApplication().Delete(planTypeDto);

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
