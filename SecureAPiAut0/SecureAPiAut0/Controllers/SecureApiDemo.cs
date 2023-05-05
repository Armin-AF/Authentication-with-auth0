using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SecureAPiAut0.Controllers;

[Route("api")]
[ApiController]
public class SecureApiDemo: ControllerBase
{
    const string PUBLIC = "No authentication needed";
    const string PRIVATE = "Authentication needed";
    const string READ_SCOPE = "Authentication and read:messages needed";
    
    [HttpGet("public")]
    public IActionResult Public() =>
        Ok(new { Message = PUBLIC });
    
    [HttpGet("private")]
    [Authorize]
    public IActionResult Private() =>
        Ok(new { Message = PRIVATE });
    
    [HttpGet("private-scoped")]
    [Authorize("read:messages")]
    public IActionResult Scoped() =>
        Ok(new { Message = READ_SCOPE });
    
    // This is a helper action. It allows you to easily view all the claims of the token.
    
    [HttpGet("claims")]
    public IActionResult Claims()
    {
        return Ok(
            User.Claims.Select(c => new { c.Type, c.Value })
        ); }
}