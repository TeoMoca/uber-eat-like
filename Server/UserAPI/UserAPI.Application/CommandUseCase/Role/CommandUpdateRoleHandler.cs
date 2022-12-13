using MediatR;
using UserAPI.Application.CommandUseCase.User;
using UserAPI.Application.Interface;

namespace UserAPI.Application.CommandUseCase.Role;

public record InputUpdateRoleUseCase(Domain.Role role) : IRequest<bool>{}
public class CommandUpdateRoleHandler : IRequestHandler<InputUpdateRoleUseCase, bool>
{
    private readonly IRoleRepository _roleRepository;

    public CommandUpdateRoleHandler(IRoleRepository roleRepository)
    {
        _roleRepository = roleRepository;
    }

    public async Task<bool> Handle(InputUpdateRoleUseCase request, CancellationToken cancellationToken = default)
    { 
        await _roleRepository.UpdateAsync(request.role);
        return true;
    }
}