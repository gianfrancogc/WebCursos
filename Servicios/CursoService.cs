using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Modelo;
using Modelo.ViewModels;
using Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{

    public interface ICursoService
    {
        Task<List<Curso>> ListarCursos();
        Task<bool> GuardarCurso(CursoCreateViewModel model);
        Task<CursoEditViewModel> GetCurso(int id);
        Task<bool> EditarCurso(CursoEditViewModel model);
        Task<bool> RemoverCurso(int id);

    }
    public class CursoService : ICursoService
    {
        private readonly Contexto _contexto;
        private readonly IMapper _mapper;
        public CursoService(Contexto contexto, IMapper mapper)
        {
            _contexto = contexto;
            _mapper = mapper;
        }


        public async Task<CursoEditViewModel> GetCurso (int id)
        {
          return _mapper.Map<CursoEditViewModel>
                (
                 await _contexto.Curso.SingleOrDefaultAsync(x => x.Id == id)
                );
        }

        public async Task<bool> EditarCurso(CursoEditViewModel model)
        {
            try
            {
                var curso = _mapper.Map<Curso>(model);
                _contexto.Update(curso);
                await _contexto.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }


        public async Task<bool> RemoverCurso(int id)
        {
            try
            {
                var curso = await _contexto.Curso.SingleAsync(x => x.Id == id);
                _contexto.Remove(curso);
                await _contexto.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        public async Task<bool> GuardarCurso(CursoCreateViewModel model)
        {
            try
            {

                var curso = _mapper.Map<Curso>(model);
                _contexto.Add(curso);
                await _contexto.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }

        public async Task<List<Curso>> ListarCursos()
        {
            return await _contexto.Curso
                .Include(x => x.Categoria)
                .ToListAsync();
        }
    }
}
