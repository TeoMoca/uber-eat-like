using UserAPI.Controllers.User.ViewModel;

namespace UserAPI.Controllers.User.Extensions;

public static class UserExtensions {

    public static List<UserViewModel> ToViewModel(this List<Domain.User> users) {
        var userViewModel = new List<UserViewModel>();

        foreach (var user in users){
            userViewModel.Add(new UserViewModel(){Id = user.Id, Email = user.Email, Name = user.Name, Password = user.Password});
        }

        return userViewModel;
    }

    public static Domain.User ToUseCase(this UserViewModel userViewModel) {

        var user = new Domain.User()
        {
          Id  = userViewModel.Id, Email = userViewModel.Email, Name = userViewModel.Name, Password = userViewModel.Password
        };

        return user;
    }
}