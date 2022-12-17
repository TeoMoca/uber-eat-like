using MediatR;
using UserAPI.Application.Interface;

namespace UserAPI.Application.CommandUseCase.Gender;

public record InputAddGenderUseCase(Domain.Gender gender) : IRequest<bool>{}
public class CommandAddGenderHandler : IRequestHandler<InputAddGenderUseCase, bool> {

    private readonly IGenderRepository _genderRepository;

    public CommandAddGenderHandler(IGenderRepository genderRepository) {
        _genderRepository = genderRepository;
    }

    public async Task<bool> Handle(InputAddGenderUseCase request, CancellationToken cancellationToken = default) {
        
        await _genderRepository.AddAsync(request.gender);

        return true;
    }
}