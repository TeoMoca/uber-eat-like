using AppDev.Applications.Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDev.Applications.QueryUseCase.User
{
    public record InputAllUsersUseCase() : IRequest<List<Domain.User>> { }
    public class QueryAllUserHandler : IRequestHandler<InputAllUsersUseCase, List<Domain.User>>
    {
        private readonly IUserRepository _userRepository;

        public QueryAllUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<Domain.User>> Handle(InputAllUsersUseCase request, CancellationToken cancellationToken = default)
            => await _userRepository.AllUserAsync();
    }
}
