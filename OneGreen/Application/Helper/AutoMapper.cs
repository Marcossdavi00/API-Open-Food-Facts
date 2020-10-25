using Application.Model;
using AutoMapper;
using Domain.Entity;

namespace Application.Helper
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<DetailsServer, DetailsModelOutPut>()
                .ForMember(dest => dest.UltimaAtualizacao, opt => opt.MapFrom(from => from.UltimaAtualizacao.ToString("dd/MM/yyyy HH:mm:ss")));
            CreateMap<Products, ProductsModelOutPut>()
                .ForMember(dest => dest.Imported_t, opt => opt.MapFrom(from => from.Imported_t.ToString("dd/MM/yyyy HH:mm:ss")))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(from => from.Status.Value));
        }
    }
}
