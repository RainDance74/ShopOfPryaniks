﻿using ShopOfPryaniks.Application.Common.Models;

namespace ShopOfPryaniks.Application.Common.Interfaces;

public interface IUserManager
{
    Task<(Result Result, string UserId)> CreateUserAsync(string userName, string password);

    Task<Result> DeleteUserAsync(string userId);
}