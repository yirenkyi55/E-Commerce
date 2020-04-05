using Core.Entities;

namespace Core.Specifications
{
    public class ProductsWithTypesAndBrandsSpecification : BaseSpecification<Product>
    {
      /// <summary>
      /// Should be used only for returning a list of products with sorting and filtering
      /// </summary>
      /// <param name="productSpecParams">Sort by priceAsc, priceDesc and default by name, filter by brandId and typeId and also performs pagination</param>
    public ProductsWithTypesAndBrandsSpecification(ProductSpecParams productSpecParams)
            :base(p=>(string.IsNullOrEmpty(productSpecParams.Search) || p.Name.ToLower().Contains(productSpecParams.Search))
                &&(!productSpecParams.BrandId.HasValue || p.ProductBrandId == productSpecParams.BrandId) 
                     && (!productSpecParams.TypeId.HasValue || p.ProductTypeId == productSpecParams.TypeId))
        {
            //if we do have a typeId then !typeId.HasValue = false, and hence we execute the or || part of the code
            AddInclude(p => p.ProductBrand);
            AddInclude(p => p.ProductType);
            AddOderBy(p=>p.Name);
            AddPaging(productSpecParams.PageSize * (productSpecParams.PageIndex - 1),productSpecParams.PageSize);

            if (!string.IsNullOrEmpty(productSpecParams.Sort))
            {
                switch (productSpecParams.Sort.ToLower())
                {
                    case "priceasc":
                        AddOderBy(p=>p.Price);
                        break;
                    case  "pricedesc":
                        AddOderByDescending(p=>p.Price);
                        break;
                    default:
                        AddOderBy(p=>p.Name);
                        break;
                }
            }
        }

        /// <summary>
        /// A constructor for getting a single product by id
        /// </summary>
        /// <param name="id">The id of the product</param>
        public ProductsWithTypesAndBrandsSpecification(int id) : base(p => p.Id == id)
        {
            AddInclude(p => p.ProductBrand);
            AddInclude(p => p.ProductType);
        }
    }
}