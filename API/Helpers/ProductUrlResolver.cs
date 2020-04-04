using API.Dtos;
using AutoMapper;
using Core.Entities;
using Microsoft.AspNetCore.Http;

namespace API.Helpers
{
    public class ProductUrlResolver : IValueResolver<Product, ProductToReturnDto, string>
    {
        private readonly IHttpContextAccessor _httpContext;
        public ProductUrlResolver(IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;

        }
        public string Resolve(Product source, ProductToReturnDto destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.PictureUrl))
            {
                return $"{_httpContext.HttpContext.Request.Scheme}://{_httpContext.HttpContext.Request.Host}/{source.PictureUrl}";
            }
            return null;
        }
    }
}