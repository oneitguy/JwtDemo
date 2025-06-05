using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
[Authorize]  // Protect all actions in this controller
public class SecretController : ControllerBase
{
    [HttpGet]
    public IActionResult GetSecretData()
    {
        return Ok("This is secret data only for authenticated users!");
    }
}
