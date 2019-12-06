using AutoMapper;
using DataAccessLayer;
using DataAccessLayer.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebServiceLayer.Models;

namespace WebServiceLayer.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private IConfiguration _configuration;
        private IAppUserService _appUserService;
        private IMapper _mapper;
        public UsersController(IConfiguration configuration, IAppUserService appUserService, IMapper mapper)
        {
            _appUserService = appUserService;
            _configuration = configuration;
            _mapper = mapper;
        }
        [HttpPost]
        public ActionResult CreateUser([FromBody] UserForCreationDto dto)
        {
            if (_appUserService.GetUserByEmail(dto.Email) != null)
            {
                return BadRequest();
            }

            int.TryParse(
                _configuration.GetSection("Auth:PwdSize").Value,
                out var size);

            if (size == 0)
            {
                throw new ArgumentException();
            }

            var salt = PasswordService.GenerateSalt(size);

            var pwd = PasswordService.HashPassword(dto.Password, salt, size);

            _appUserService.CreateUser(dto.Name, dto.Email, pwd, salt);

            return CreatedAtRoute(null, "Hello," + dto.Name + "!");
        }
        [Authorize]
        [HttpDelete]
        public ActionResult DeleteUser()
        {
            var userEmail = HttpContext.User.Identity.Name;
            if (_appUserService.DeleteUserByEmail(userEmail))
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }

        }
        [Authorize]
        [HttpPut]
        public ActionResult UpdateUser(AppUser appUser)
        {
            var email = HttpContext.User.Identity.Name;
            if (_appUserService.GetUserByEmail(appUser.Email) == null)
            {
                return BadRequest();
            }

            if (email != appUser.Email)
            {
                return BadRequest();
            }
            int.TryParse(
                _configuration.GetSection("Auth:PwdSize").Value,
                out var size);

            if (size == 0)
            {
                throw new ArgumentException();
            }

            var salt = PasswordService.GenerateSalt(size);
            var pwd = PasswordService.HashPassword(appUser.Password, salt, size);
            var updatedUser = new AppUser { Email = appUser.Email, Password = pwd, Salt = salt, Name = appUser.Name };
            _appUserService.UpdateUser(updatedUser);
            return Ok(CreateAppUserDto(updatedUser));
        }
        private UserForUpdateDto CreateAppUserDto(AppUser user)
        {
            var dto = _mapper.Map<UserForUpdateDto>(user);
            return dto;
        }
    }
}
