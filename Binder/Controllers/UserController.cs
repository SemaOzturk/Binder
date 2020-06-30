using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Binder.Application.Entities;
using Binder.Application.Services;
using Binder.Shared.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
namespace Binder.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public UserController(IUserService userService,IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }
        [HttpPost]
      
        public IActionResult CreateUser([FromBody]UserCreateModel userCreate)
        {
            var user = _mapper.Map<User>(userCreate);
           user= _userService.CreateUser(user,userCreate.Password);
            var userReadModels = _mapper.Map<UserReadModel>(user);
            return Ok(userReadModels);
        }
        [HttpGet("Gender")]
        public IActionResult TakeGender()
        {
            return Ok(_userService.GetGender());
        }

        [HttpGet("Around/{id}")]
        [AllowAnonymous]
        public IActionResult ShowAround(int id)
        {
            return Ok(_userService.ShowAround(id));
        }
    

    }
}
