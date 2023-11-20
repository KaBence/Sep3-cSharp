﻿using System.Globalization;
using Shared.DTOs;
using Shared.Models;

namespace HttpClients.ClientInterfaces;

public interface IUserService
{
    Task Register(RegisterDto dto);

    Task EditUser(EditUserDto dto);

    Task<EditUserDto> GetByIdAsync(string phoneNumber);
}