﻿using Final.BL.DTOs.AppUserDTOs;
using Final.BL.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace FinalPr.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthsController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthsController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(AppUserCreateDTO appUserCreateDto)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ModelState);
            }
            try
            {
                return StatusCode(StatusCodes.Status201Created, await _authService.RegisterAsync(appUserCreateDto));
            }
            catch (Exception e)
            {

                return StatusCode(StatusCodes.Status400BadRequest, e.Message);
            }
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(AppUserLoginDTO appUserLoginDto)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ModelState);
            }
            try
            {
                return StatusCode(StatusCodes.Status200OK, await _authService.LoginAsync(appUserLoginDto));
            }
            catch (Exception e)
            {

                return StatusCode(StatusCodes.Status400BadRequest, e.Message);
            }
        }
    }
}
