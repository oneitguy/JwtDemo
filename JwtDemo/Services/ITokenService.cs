﻿namespace JwtDemo.Services
{
    public interface ITokenService
    {
        string GenerateToken(string username);
    }
}
