using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using InventoryMGMT.Models;

namespace InventoryMGMT.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
       

        public IActionResult Error()
        {
            return View();
        }
    }
}
