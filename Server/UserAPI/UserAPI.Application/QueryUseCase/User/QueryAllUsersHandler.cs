using MediatR;
using UserAPI.Application.Interface;

namespace UserAPI.Application.QueryUseCase.User;

public record InputAllUsersUseCase() : IRequest<List<Domain.User>>{}

public class QueryAllUsersHandler : IRequestHandler<InputAllUsersUseCase, List<Domain.User>> {

    private readonly IUserRepository _userRepository;

    public QueryAllUsersHandler(IUserRepository userRepository) {
        _userRepository = userRepository;
    }

    public async Task<List<Domain.User>> Handle(InputAllUsersUseCase request, CancellationToken cancellationToken = default)
        => await _userRepository.AllAsync();
}
