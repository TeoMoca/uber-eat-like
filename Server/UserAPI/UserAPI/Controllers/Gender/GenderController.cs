using MediatR;
using Microsoft.AspNetCore.Mvc;
using UserAPI.Application.CommandUseCase.Gender;
using UserAPI.Controllers.Gender.Extensions;
using UserAPI.Controllers.Gender.ViewModel;

namespace UserAPI.Controllers.Gender;

[ApiController]
[Route("/api/[controller]")]
public class GenderController : ControllerBase
{
    private readonly ILogger<GenderController> _logger;
    private readonly IMediator _Mediator;

    public GenderController(ILogger<GenderController> logger, IMediator mediator)
    {
        _logger = logger;
        _Mediator = mediator;
    }

    

    [HttpPost(Name = "AddGender")]
    public async Task<bool> Post(GenderViewModel genderViewModel)
    {
        var isAdded = await _Mediator.Send(new InputAddGenderUseCase(genderViewModel.ToUseCase()));
        
        return isAdded;
    }

    [HttpDelete(Name = "DeleteGender")]
    public async Task<bool> Delete(int genderId)
    {
        var isDeleted = await _Mediator.Send(new InputDeleteGenderUseCase(genderId));
    
        return isDeleted;
    }
    
    [HttpPatch(Name = "UpdateGender")]
    public async Task<IActionResult> Patch(GenderViewModel genderViewModel)
    {
        await _Mediator.Send(new InputUpdateGenderUseCase(genderViewModel.ToUseCase()));
    
        return Ok();
    }
}