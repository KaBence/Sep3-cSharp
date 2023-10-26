﻿
using Application.LogicInterfaces;
using GrpcDemo;
using Shared.DTOs;
using Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class AliensController : ControllerBase
{
    private readonly IAlienLogic alienLogic;

    private readonly Client _client;

    public AliensController(IAlienLogic alienLogic)
    {
        this.alienLogic = alienLogic;
    }

    [HttpPost]
    public async Task<ActionResult<Alien>> CreateAsync(AlienCreationDto dto)
    {
        try
        {
            Alien alien = await alienLogic.CreateAsync(dto);
            return Created($"/aliens/{alien.Id}", alien);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Alien>>> GetAsync([FromQuery] string? name)
    {
        try
        {
            SearchAlienParametersDto parameters = new(name);
            IEnumerable<Alien> aliens = await alienLogic.GetAsync(parameters);
            return Ok(aliens);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
}