
using Application.UseCases.Product.Commands.CreateProduct;
using Application.UseCases.Product.Commands.UpdateProduct;

namespace Application.DTO
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, GetProductDTO>().ReverseMap();
            CreateMap<Product, CreateProductCommand>().ReverseMap();
            CreateMap<Product, UpdateProductCommand>().ReverseMap();
        }            
    }
}
