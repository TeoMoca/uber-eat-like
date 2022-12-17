using UserAPI.Application.CommandUseCase.User;
using UserAPI.Controllers.User.Extensions;
using UserAPI.Controllers.User.ViewModel;

namespace UserAPI.Controllers;

    using Application.QueryUseCase.User;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    

    [ApiController]
    [Route("/api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IMediator _Mediator;
            
        public UserController(ILogger<UserController> logger, IMediator mediator)
        {
            _logger = logger;
            _Mediator = mediator;
        }

        [HttpGet(Name = "GetAllUsers")] public async Task<List<UserViewModel>> Get() {
            var users = await _Mediator.Send(new InputAllUsersUseCase());

            return users.ToViewModel();
        }

        [HttpPost(Name = "AddUser")] public async Task<IActionResult> Post(UserViewModel userViewModel) {
            
            var isAdded = await _Mediator.Send(new InputAddUserUseCase(userViewModel.ToUseCase()));
            
            return CreatedAtAction(nameof(Get), new { id = userViewModel.Id }, userViewModel);
        }

        [HttpPatch(Name = "UpdateUser")]
        public async Task<bool> Patch(UserViewModel userViewModel)
        {
            var isUpdated = await _Mediator.Send(new InputUpdateUserUseCase(userViewModel.ToUseCase()));
            
            return isUpdated;
        }

        [HttpDelete("{id}")]
        public async Task<bool> Delete(Guid userId)
        {
            var isDeleted = await _Mediator.Send(new InputDeleteUserUseCase(userId));

            return isDeleted;
        }
        
    }
