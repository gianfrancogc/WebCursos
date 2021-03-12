using AutoMapper;
using Modelo;
using Modelo.ViewModels;

namespace WebCursos.Config
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            CreateMap<CursoCreateViewModel, Curso>();
            CreateMap<Curso, CursoEditViewModel>();
            CreateMap<CursoEditViewModel, Curso>();
        }
    }
}
