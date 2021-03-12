using System;
using System.Collections.Generic;

namespace Modelo
{
    public class Categoria
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public List<Curso> Cursos { get; set; }
    }
}
