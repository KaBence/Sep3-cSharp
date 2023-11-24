﻿using Application.LogicInterfaces;
using Microsoft.AspNetCore.Mvc;
using Shared.DTOs;
using Shared.DTOs.Search;
using Shared.Models;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class FarmerController: ControllerBase

{
    private readonly IFarmerLogic farmerLogic;

    public FarmerController(IFarmerLogic farmerLogic)
    {
        this.farmerLogic = farmerLogic;
    }
    [HttpPost]
    public async Task<ActionResult<string>> CreateAsync(RegisterFarmerDto farmerDto)
    {
        try
        {
            string farmer = await farmerLogic.CreateAsync(farmerDto);
            return Ok(farmer);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Farmer>>> GetAsync( [FromQuery] bool? perticides,  [FromQuery] string? farmName,  [FromQuery] double? rating)
    {
        try
        {
            SearchFarmerDto parametersDto = new(perticides, farmName, rating);
            IEnumerable<Farmer> farmers = await farmerLogic.GetAsync(parametersDto);
            return Ok(farmers);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}