using UserAPI.Controllers.Role.ViewModel;
using UserAPI.Controllers.User.ViewModel;

namespace UserAPI.Controllers.Role.Extensions;

public static class RoleExtensions
{
    public static List<RoleViewModel> ToViewModel(this List<Domain.Role> roles) {
        var roleViewModel = new List<RoleViewModel>();

        foreach (var role in roles){
            roleViewModel.Add(new RoleViewModel(){Id = role.Id, Label = role.Label, IsDisabled = role.IsDisabled});
        }

        return roleViewModel;
    }

    public static Domain.Role ToUseCase(this RoleViewModel roleViewModel)
    {
        var role = new Domain.Role()
        {
          Id  = roleViewModel.Id, Label = roleViewModel.Label, IsDisabled = roleViewModel.IsDisabled
        };

        return role;
    }
}