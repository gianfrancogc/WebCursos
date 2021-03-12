using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Modelo.ViewModels
{
    public class CursoCreateViewModel
    {
        [Required(ErrorMessage = "Ingrese el nombre del curso"),StringLength(50, ErrorMessage = "Maximo 50 caracteres")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Ingrese una descripción"), StringLength(150, ErrorMessage = "Maximo 150 caracteres")]
        public string Descripcion { get; set; }
        public string Picture { get; set; }
        [Required(ErrorMessage = "Ingrese un precio")]
        public decimal Precio { get; set; }
        [Required(ErrorMessage = "Ingrese una categoria")]
        public int IdCategoria { get; set; }
    }


    public class CursoEditViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Ingrese el nombre del curso"), StringLength(50, ErrorMessage = "Maximo 50 caracteres")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Ingrese una descripción"), StringLength(150, ErrorMessage = "Maximo 150 caracteres")]
        public string Descripcion { get; set; }
        public string Picture { get; set; }
        [Required(ErrorMessage = "Ingrese un precio")]
        public decimal Precio { get; set; }
        [Required(ErrorMessage = "Ingrese una categoria")]
        public int IdCategoria { get; set; }
    }
}
