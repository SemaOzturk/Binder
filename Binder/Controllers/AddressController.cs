using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Binder.Application.Entities;
using Binder.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
namespace Binder.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class AddressController : Controller
    {
        private readonly IAdressService _adressService;
        private readonly IMapper _mapper;
        public AddressController(IAdressService adressService,IMapper mapper)
        {
            _adressService = adressService;
            _mapper = mapper;
        }

        [HttpGet("Countries")]
        [AllowAnonymous]
        public IActionResult FillCountries()
        {
             return Ok(_adressService.GetCountries());
           
        }
        //[HttpGet("character/{id}/change")]

        [HttpGet("States/{id}")]
        [AllowAnonymous]
        public IActionResult FillStates(int id)
        {
            return Ok(_adressService.GetStates(id));
        }
        
        [HttpGet("Cities/{id}")]
        [AllowAnonymous]
        public IActionResult FillCities(int id)
        {
            return Ok(_adressService.GetCities(id));
        }
    }
}
