using System.Threading.Tasks;
using API.Error;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/basket")]
    public class BasketController:BaseApiController
    {
        private readonly IBasketRepository _basketRepository;

        public BasketController(IBasketRepository basketRepository)
        {
            _basketRepository = basketRepository;
        }

        [HttpGet()]
        public async Task<ActionResult<CustomerBasket>> GetBasket([FromQuery]string id)
        {
            var data = await _basketRepository.GetBasketAsync(id);

            return Ok(data ?? new CustomerBasket(id));
        }
        
        [HttpPost]
        public async Task<ActionResult<CustomerBasket>> UpdateBasket(CustomerBasket basket)
        {
            var updatedBasket = await _basketRepository.CreateOrUpdateBasketAsync(basket);
            return Ok(updatedBasket);
        }

        [HttpDelete()]
        public async Task<ActionResult> DeleteBasket([FromQuery]string id)
        {
          var result =  await _basketRepository.DeleteBasketAsync(id);

          return NoContent();
        }
    }
}