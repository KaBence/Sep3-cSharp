﻿using Application.LogicInterfaces;
using Microsoft.AspNetCore.Mvc;
using Shared.DTOs.Create;
using Shared.DTOs.Update;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]

public class OrderController : ControllerBase
{
    private readonly IOrderLogic orderLogic;

    public OrderController(IOrderLogic orderLogic)
    {
        this.orderLogic = orderLogic;
    }

    [HttpPost]
    public async Task<ActionResult<string>> CreateAsync(OrderCreateDto dto)
    {
        try
        {
            string order = await orderLogic.CreateAsync(dto);
            return Ok(order);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
    
    [HttpPatch]
    public async Task<ActionResult<string>> acceptOrder(AcceptOrder order)
    {
        try
        {
            string update = await orderLogic.UpdateAsync(order);
            return Ok(update);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}