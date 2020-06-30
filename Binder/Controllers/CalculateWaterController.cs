using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Binder.Shared.CalculateDrinkwater;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Binder.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class CalculateWaterController : Controller
    {
        // GET: api/<controller>
        [HttpPost]
        [AllowAnonymous]
        public IActionResult CalculateWater([FromBody]DrinkWaterCreateModel drinkWater)
        {
            DrinkWaterReadModel drink = new DrinkWaterReadModel
            {
                Amount = drinkWater.Weight*0.033
            };
            return Ok(drink.Amount + " litre su içmelisiniz");
        }
    }
}
