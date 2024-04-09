using Microsoft.AspNetCore.Mvc;

namespace TodoList.Controllers;

[Route("[controller]")]
[ApiController]
public class UserController: ControllerBase
{
    private readonly ILogger<UserController> _ILogger;

    public UserController(ILogger<UserController> ILogger)
    {
        _ILogger = ILogger;
        
        _ILogger.LogInformation("这是 Info Log");
        _ILogger.LogError("这是 Error Log");
        _ILogger.LogWarning("这是 Warn Log");
        _ILogger.LogDebug("这是 Debug Log");
    }

    [HttpGet]
    public string GetUser()
    {
        return "user";
    }

}