using System.Collections.Generic;

namespace MiniMarket.Models.ViewModels
{
    public class UserRoleListViewModel
    {
        public int UserId { get; set; }

        public string FullName { get; set; }

        public string Username { get; set; }

        public List<string> AssignedRoles { get; set; }
    }
}