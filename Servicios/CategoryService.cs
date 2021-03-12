using Microsoft.EntityFrameworkCore;
using Modelo;
using Persistence;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Servicios
{

    public interface ICategoryService
    {

        Task<List<Categoria>> ListarCategorias();

    }
    public class CategoryService : ICategoryService
    {
        private readonly Contexto _contexto;
        public CategoryService(Contexto contexto)
        {
            _contexto = contexto;
        }

        public async Task<List<Categoria>> ListarCategorias()
        {
            return await _contexto.Categoria.ToListAsync();
        }
    }
}
