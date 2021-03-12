using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Modelo.ViewModels;
using Servicios;
using System;
using System.IO;
using System.Threading.Tasks;

namespace WebCursos.Controllers
{
    public class CursoController : Controller
    {
        private readonly ICursoService _cursoService;
        private readonly ICategoryService _categoriaService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public CursoController(ICursoService cursoService, ICategoryService categoriaService, IWebHostEnvironment webHostEnvironment)
        {
            _cursoService = cursoService;
            _webHostEnvironment = webHostEnvironment;
            _categoriaService = categoriaService;
        }

        public async Task<IActionResult> Listado()
        {
            return View(await _cursoService.ListarCursos());
        }


        public async Task<IActionResult> Create()
        {
            ViewBag.Categories = await _categoriaService.ListarCategorias();
            return View(new CursoCreateViewModel());
        }


        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.Categories = await _categoriaService.ListarCategorias();

            return View(await _cursoService.GetCurso(id));
        }

        public async Task<IActionResult> Remove(int id)
        {
            if (await _cursoService.RemoverCurso(id))
            {
                return RedirectToAction("Listado");
            }

            return RedirectToAction("Listado");
        }



        [HttpPost]
        public async Task<IActionResult> Create(CursoCreateViewModel model,IFormFile picture)
        {
            if (ModelState.IsValid)
            {
                if (picture!=null)
                {
                    /*
                    Implementar una validacion que no permita ingresar archivos que no sean imagenes 
                    */

                    string rutaCursoImagen = Path.Combine(_webHostEnvironment.WebRootPath, "upload/cursos");

                    string archivoUnico = $"{Guid.NewGuid().ToString()}-{Path.GetExtension(picture.FileName)}";

                    string rutaFinal = Path.Combine(rutaCursoImagen, archivoUnico);

                    using (var file = new FileStream(rutaFinal,FileMode.Create))
                    {
                        await picture.CopyToAsync(file);
                    }

                    model.Picture = $"upload/cursos/{archivoUnico}";

                }

                if ( await _cursoService.GuardarCurso(model))
                {
                    return RedirectToAction("Listado");
                }
            }
            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(CursoEditViewModel model, IFormFile picture)
        {
            if (ModelState.IsValid)
            {
                if (picture != null)
                {
                   

                    string rutaCursoImagen = Path.Combine(_webHostEnvironment.WebRootPath, "upload/cursos");

                    string archivoUnico = $"{Guid.NewGuid().ToString()}-{Path.GetExtension(picture.FileName)}";

                    string rutaFinal = Path.Combine(rutaCursoImagen, archivoUnico);

                    using (var file = new FileStream(rutaFinal, FileMode.Create))
                    {
                        await picture.CopyToAsync(file);
                    }

                    model.Picture = $"upload/cursos/{archivoUnico}";

                }

                if (await _cursoService.EditarCurso(model))
                {
                    return RedirectToAction("Listado");
                }
            }
            return View(model);
        }
    }
}
