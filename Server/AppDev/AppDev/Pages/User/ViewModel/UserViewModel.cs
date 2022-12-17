using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDev.Pages.User.ViewModel;

public class UserViewModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    [EmailAddress]
    public string Email { get; set; }
    public string Password { get; set; }
    public int RoleId { get; set; }

    public UserViewModel Copy ()
    {
        return new UserViewModel { Id = this.Id, Name = this.Name, Email = this.Email, Password = this.Password, RoleId = this.RoleId };
    }
}
