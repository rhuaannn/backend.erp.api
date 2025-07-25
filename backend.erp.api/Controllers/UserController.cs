﻿using backend.erp.Application.Interfaces;
using backend.erp.Application.UsuarioDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend.erp.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUsers _usersService;

        public UserController(IUsers users)
        {
            _usersService = users;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _usersService.GetAllUsersAsync();
            if (users == null || !users.Any())
            {
                return NotFound("No users found.");
            }
            return Ok(users);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> AddUserAsync([FromBody] RequestUserDTO requestUserDto)
        {
            var user = await _usersService.CreateUserAsync(requestUserDto);
            return Created("post", user);
        }
    }
}
