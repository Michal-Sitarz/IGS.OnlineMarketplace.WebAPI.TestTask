using AutoMapper;
using IGS.OnlineMarketplace.Dtos;
using IGS.OnlineMarketplace.Models;

namespace IGS.OnlineMarketplace.MappingProfiles
{
    public class ProductsProfile : Profile
    {
        public ProductsProfile()
        {
            CreateMap<Product, ProductReadDto>();
            
            CreateMap<ProductCreateDto, Product>();

            CreateMap<ProductUpdateDto, Product>();
        }
    }
}