using MediatR;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using AppDev.Pages.User.ViewModel;
using AppDev.Applications.QueryUseCase.User;
using AppDev.Extensions;
using AppDev.Applications.CommandUseCase.User;

namespace AppDev.Pages.User;

public partial class User : ComponentBase
{
    [Inject] private IMediator _Mediator { get; set; } = null!;

    private MudTable<UserViewModel>? table;
    private string searchText = "";

    private bool SearchFilter(UserViewModel element) => FilterElement(element, searchText);

    private List<UserViewModel> elements = new List<UserViewModel>();

    private UserViewModel? currentSelectModel = null!;
    private UserViewModel? previousSelectModel = null!;

    protected override async Task OnInitializedAsync()
    {
        await RefreshUser();
        StateHasChanged();
    }

    private async Task RefreshUser()
    {
        var users = await _Mediator.Send(new InputAllUsersUseCase());

        elements = new List<UserViewModel>();

        foreach(var user in users)
        {
            elements.Add(new UserViewModel
            {
                Name = user.Name,
                Email= user.Email,
                Password= user.Password,
                RoleId= user.RoleId,
            });
        }
    }

    private bool FilterElement(UserViewModel element, string searchString)
    {
        if (searchString is not null)
            searchString = searchString.TrimEnd().TrimStart().ToLowerInvariant();

        if (element.Email is not null)
        {
            element.Email = element.Email.TrimEnd().TrimStart().ToLowerInvariant();

            if (element.Email.ComplexContains(searchString))
                return true;

        }

        if (element.Name is not null)
        {
            element.Name = element.Name.TrimEnd().TrimStart().ToLowerInvariant();

            if (element.Name.ComplexContains(searchString))
                return true;

        }

        if (element.Name is null || element.Email is null)
            return true;

        return false;
    }

    private async Task AddRow() 
    {
        var user = new UserViewModel();
        elements.Insert(0, user);
        if (table is null) return;

        await Task.Delay(10);

        table.SetSelectedItem(user);
        table.SetEditingItem(user);

        StateHasChanged();
    }

    private async Task DeleteUser(object selectElement)
    {
        await Task.Delay(10);
        //if (currentSelectModel is not null)
        //    await

        //await RefreshUser();
        StateHasChanged();
    }

    private async Task RemoveUser(UserViewModel user)
    {

    }

    private async Task SaveUser()
    {
        await Task.Delay(10);

        if(currentSelectModel is not null)
            currentSelectModel.Id = await _Mediator.Send(new InputAddUserUseCase(new Domain.User { Email = currentSelectModel.Email, Name = currentSelectModel.Name, Password = currentSelectModel.Password, RoleId = currentSelectModel.RoleId }));

        this.currentSelectModel = null;
        
    }
    
    private void ItemHasBeenChanged(object selectElement)
    {
        if (selectElement is not UserViewModel currentSelectElement) return;
        this.currentSelectModel = currentSelectElement.Copy();
    }

    private void ItemPreviewChanged(object selectElement)
    {
        if (selectElement is not UserViewModel currentSelectElement) return;
        previousSelectModel = currentSelectElement.Copy();
    }
}
