using MediatR;
using UserAPI.Application.Interface;

namespace UserAPI.Application.CommandUseCase.Gender;

public record InputDeleteGenderUseCase(int genderId) : IRequest<bool>;
public class CommandDeleteGenderHandler : IRequestHandler<InputDeleteGenderUseCase, bool>
{
    private IGenderRepository _genderRepository;

    public CommandDeleteGenderHandler(IGenderRepository genderRepository)
    {
        _genderRepository = genderRepository;
    }

    public async Task<bool> Handle(InputDeleteGenderUseCase request, CancellationToken cancellationToken = default)
    {
        await _genderRepository.DeleteAsync(request.genderId);

        return true;
    }
}