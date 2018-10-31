using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EntityFrameworkCore.Services.Interfaces;

namespace EntityFrameworkCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly IMachineService _machineService;

        public HomeController(IAccountService accountService, IMachineService machineService)
        {
            _accountService = accountService;
            _machineService = machineService;
        }

        public IActionResult Index()
        {
             return View();
        }
    }
}
