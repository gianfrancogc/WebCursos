using System;

namespace Modelo
{
    public class Curso
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int IdCategoria { get; set; }

        public string Picture { get; set; }
        public Categoria Categoria { get; set; }

    }
}
