using MediatR;
using UserAPI.Application.Interface;

namespace UserAPI.Application.QueryUseCase.Role;

public record InputAllRolesUseCase() : IRequest<List<Domain.Role>>{}

public class QueryAllRolesHandler : IRequestHandler<InputAllRolesUseCase, List<Domain.Role>> {

    private readonly IRoleRepository _roleRepository;

    public QueryAllRolesHandler(IRoleRepository roleRepository) {
        _roleRepository = roleRepository;
    }

    public async Task<List<Domain.Role>> Handle(InputAllRolesUseCase request, CancellationToken cancellationToken = default)
        => await _roleRepository.AllAsync();
}