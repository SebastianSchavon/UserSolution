namespace User_ASP.Controllers;

using AutoMapper;

using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using User_ASP.Authorization;
using User_ASP.Entities;
using User_ASP.Helpers;
using User_ASP.Models.Users;
using User_ASP.Services;


[ApiController]
[Route("[controller]")]
[Authorize]
public class UsersController : ControllerBase
{
    private IUserService _userService;
    private IMapper _mapper;
    private readonly AppSettings _appSettings;

    public UsersController(IUserService userService, IMapper mapper, IOptions<AppSettings> appSettings)
    {
        _userService = userService;
        _mapper = mapper;
        _appSettings = appSettings.Value;

    }

    [AllowAnonymous]
    [HttpPost("authenticate")]
    public IActionResult Authenticate(AuthenticateRequest request)
    {
        var response = _userService.Authenticate(request);

        return Ok(response);
    }

    [AllowAnonymous]
    [HttpPost("register")]
    public IActionResult Register(RegisterRequest request)
    {
        _userService.Register(request);
        return Ok(new { message = "Welcome aboard!" });
    }

    [HttpGet("all")]
    public IActionResult GetAll()
        => Ok(_userService.GetAll());

    [HttpGet("user")]
    public User GetAuthenticatedUser()
        => (User)HttpContext.Items["User"];

    [HttpGet("userId")]
    public int GetAuthenticatedUserId()
        => ((GetAuthenticatedUser())!).Id;


}
