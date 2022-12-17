using UserAPI.Controllers.Gender.ViewModel;

namespace UserAPI.Controllers.Gender.Extensions;

public static class GenderExtensions
{
    public static List<GenderViewModel> ToViewModel(this List<Domain.Gender> genders) {
        var genderViewModels = new List<GenderViewModel>();

        foreach (var gender in genders){
            genderViewModels.Add(new GenderViewModel(){Id = gender.Id, Label = gender.Label, IsDisabled = gender.IsDisabled});
        }

        return genderViewModels;
    }

    public static Domain.Gender ToUseCase(this GenderViewModel genderViewModel)
    {
        var gender = new Domain.Gender()
        {
            Id  = genderViewModel.Id, Label = genderViewModel.Label, IsDisabled = genderViewModel.IsDisabled
        };

        return gender;
    }
}