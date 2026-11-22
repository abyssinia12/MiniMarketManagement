
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MiniMarket.Models.ViewModels
{
    public class AssignUserRolesViewModel
    {
        [Required(ErrorMessage = "Please select a user.")]
        public int UserId { get; set; }

        public List<int> SelectedRoleIds { get; set; } = new();

        public List<SelectListItem> Users { get; set; } = new();

        public List<RoleOptionViewModel> Roles { get; set; } = new();

        // List of users and their assigned roles
        //public List<UserRoleListViewModel> UserRoleList { get; set; } = new();
    }

    public class RoleOptionViewModel
    {
        public int Id { get; set; }

        public string RoleName { get; set; } = string.Empty;

        public string? Description { get; set; }

        public bool IsSelected { get; set; }
    }
}
