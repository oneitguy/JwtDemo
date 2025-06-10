using Services;
using Xunit;
using Microsoft.Extensions.Configuration;
using Controllers;
using Microsoft.AspNetCore.Mvc;
using Data; // For LoginRequest

//If user enters correct username & password, it should:
//Call the TokenService
//Generate a JWT token
//Return an OkObjectResult (HTTP 200) with the token
public class AuthControllerTests
{
    [Fact]
    public void Login_ReturnsOkResult_WithToken_WhenCredentialsAreValid()
    {
        // Arrange
        var inMemorySettings = new Dictionary<string, string?>
        {
            { "JwtSettings:SecretKey", "your-secret-key12314522222222222387egewidwiydgqwivdkqwjbdwqkjbdew23" },
            { "JwtSettings:Issuer", "your-issuer" },
            { "JwtSettings:Audience", "your-audience" },
            { "JwtSettings:ExpiryMinutes", "60" }
        };

        var configuration = new ConfigurationBuilder()
            .AddInMemoryCollection(inMemorySettings)
            .Build();

        var tokenService = new TokenService(configuration);
        var controller = new AuthController(tokenService);

        var request = new Login
        {
            Username = "ansh",
            Password = "password123"
        };

        // Act
        var result = controller.Login(request);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.NotNull(okResult.Value);
    }
}
