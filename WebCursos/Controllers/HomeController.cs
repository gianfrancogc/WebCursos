using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Servicios;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebCursos.Models;

namespace WebCursos.Controllers
{
    public class HomeController : Controller
    {

        private readonly ICategoryService _categoryService;
        public HomeController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }


        public async Task<IActionResult> Index()
        {
            return View(await _categoryService.ListarCategorias());
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
