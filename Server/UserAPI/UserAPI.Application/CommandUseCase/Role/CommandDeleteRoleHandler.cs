using MediatR;
using UserAPI.Application.CommandUseCase.User;
using UserAPI.Application.Interface;

namespace UserAPI.Application.CommandUseCase.Role;

public record InputDeleteRoleUseCase(Domain.Role role) : IRequest<bool>;

public class CommandDeleteRoleHandler : IRequestHandler<InputDeleteRoleUseCase, bool>
{
    private IRoleRepository _roleRepository;

    public CommandDeleteRoleHandler(IRoleRepository roleRepository)
    {
        _roleRepository = roleRepository;
    }

    public async Task<bool> Handle(InputDeleteRoleUseCase request, CancellationToken cancellationToken = default)
    {
        await _roleRepository.DeleteAsync(request.role);

        return true;
    }
}