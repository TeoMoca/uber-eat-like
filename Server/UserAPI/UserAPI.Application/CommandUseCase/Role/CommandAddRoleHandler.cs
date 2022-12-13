using MediatR;
using UserAPI.Application.CommandUseCase.User;
using UserAPI.Application.Interface;

namespace UserAPI.Application.CommandUseCase.Role;

public record InputAddRoleUseCase(Domain.Role role) : IRequest<bool>{}
public class CommandAddRoleHandler : IRequestHandler<InputAddRoleUseCase, bool> {

    private readonly IRoleRepository _roleRepository;

    public CommandAddRoleHandler(IRoleRepository roleRepository) {
        _roleRepository = roleRepository;
    }

    public async Task<bool> Handle(InputAddRoleUseCase request, CancellationToken cancellationToken = default) {
        
        await _roleRepository.AddAsync(request.role);

        return true;
    }
}