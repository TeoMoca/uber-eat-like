using AppDev.Applications.Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDev.Applications.CommandUseCase.User;

public record InputAddUserUseCase(Domain.User user) : IRequest<Guid> { }
public class CommandAddUserHandler : IRequestHandler<InputAddUserUseCase, Guid>
{
    private readonly IUserRepository _userRepository;

    public CommandAddUserHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<Guid> Handle(InputAddUserUseCase request, CancellationToken cancellationToken = default) 
        => await _userRepository.AddUserAsync(request.user);    
}
