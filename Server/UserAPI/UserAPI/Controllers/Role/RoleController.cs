using MediatR;
using Microsoft.AspNetCore.Mvc;
using UserAPI.Application.CommandUseCase.Role;
using UserAPI.Application.QueryUseCase.Role;
using UserAPI.Controllers.Role.Extensions;
using UserAPI.Controllers.Role.ViewModel;

namespace UserAPI.Controllers.Role;


[ApiController]
[Route("/api/[controller]")]
public class RoleController : ControllerBase
{
    private readonly ILogger<RoleController> _logger;
    private readonly IMediator _Mediator;

    public RoleController(ILogger<RoleController> logger, IMediator mediator)
    {
        _logger = logger;
        _Mediator = mediator;
    }

    [HttpGet(Name = "GetAllRoles")]
    public async Task<List<RoleViewModel>> Get()
    {
        var roles = await _Mediator.Send(new InputAllRolesUseCase());

       return roles.ToViewModel();
    }

    [HttpPost(Name = "AddRole")]
    public async Task<bool> Post(RoleViewModel role)
    {
        var isAdded = await _Mediator.Send(new InputAddRoleUseCase(role.ToUseCase()));
        
        return isAdded;
    }

    [HttpDelete(Name = "DeleteRole")]
    public async Task<bool> Delete(RoleViewModel role)
    {
        var isDeleted = await _Mediator.Send(new InputDeleteRoleUseCase(role.ToUseCase()));

        return isDeleted;
    }

    [HttpPatch(Name = "UpdateRole")]
    public async Task<IActionResult> Patch(RoleViewModel role)
    {
        await _Mediator.Send(new InputUpdateRoleUseCase(role.ToUseCase()));

        return Ok();
    }
}