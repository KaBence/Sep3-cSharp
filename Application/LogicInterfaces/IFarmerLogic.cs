﻿using Shared.DTOs;
using Shared.DTOs.Create;
using Shared.DTOs.Search;
using Shared.Models;

namespace Application.LogicInterfaces;

public interface IFarmerLogic
{
    Task<string> CreateAsync(RegisterFarmerDto farmerDto);
    
    Task<IEnumerable<Farmer>> GetAsync(SearchFarmerDto searchParameters);
    Task<Farmer?> GetByIdAsync(int id);

    

    Task UpdateAsync(Farmer dto);

}