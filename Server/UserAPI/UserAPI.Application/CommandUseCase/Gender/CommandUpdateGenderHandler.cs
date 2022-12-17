using MediatR;
using UserAPI.Application.Interface;

namespace UserAPI.Application.CommandUseCase.Gender;

public record InputUpdateGenderUseCase(Domain.Gender gender) : IRequest<bool>{}
public class CommandUpdateGenderHandler : IRequestHandler<InputUpdateGenderUseCase, bool>
{
    private readonly IGenderRepository _genderRepository;

    public CommandUpdateGenderHandler(IGenderRepository genderRepository)
    {
        _genderRepository = genderRepository;
    }

    public async Task<bool> Handle(InputUpdateGenderUseCase request, CancellationToken cancellationToken = default)
    { 
        await _genderRepository.UpdateAsync(request.gender);
        return true;
    }
}