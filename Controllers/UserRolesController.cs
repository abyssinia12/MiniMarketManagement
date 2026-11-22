using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MiniMarket.Models;
using MiniMarket.Models.ViewModels;

namespace MiniMarket.Controllers
{
    public class UserRolesController : Controller
    {
        private readonly DBContext _context;

        public UserRolesController(DBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Assign(int? userId)
        {
            var users = await _context.Users.ToListAsync();
            var roles = await _context.Roles.ToListAsync();

            List<int> assignedRoleIds = new();

            if (userId.HasValue && userId.Value > 0)
            {
                var user = await _context.Users
                    .Include(u => u.Roles)
                    .FirstOrDefaultAsync(u => u.Id == userId.Value);

                if (user != null)
                {
                    assignedRoleIds = user.Roles.Select(r => r.Id).ToList();
                }
            }

            var model = new AssignUserRolesViewModel
            {
                UserId = userId ?? 0,
                SelectedRoleIds = assignedRoleIds,

                Users = users.Select(u => new SelectListItem
                {
                    Value = u.Id.ToString(),
                    Text = u.FullName,
                    Selected = userId.HasValue && u.Id == userId.Value
                }).ToList(),

                Roles = roles.Select(r => new RoleOptionViewModel
                {
                    Id = r.Id,
                    RoleName = r.RoleName,
                    Description = r.Description,
                    IsSelected = assignedRoleIds.Contains(r.Id)
                }).ToList()
            };

            return View("~/Views/Roles/Assign.cshtml", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Assign(AssignUserRolesViewModel model)
        {
            if (model.UserId <= 0)
            {
                ModelState.AddModelError("UserId", "Please select a user.");
            }

            if (!ModelState.IsValid)
            {
                var users = await _context.Users.ToListAsync();
                var roles = await _context.Roles.ToListAsync();

                model.Users = users.Select(u => new SelectListItem
                {
                    Value = u.Id.ToString(),
                    Text = u.FullName,
                    Selected = u.Id == model.UserId
                }).ToList();

                model.Roles = roles.Select(r => new RoleOptionViewModel
                {
                    Id = r.Id,
                    RoleName = r.RoleName,
                    Description = r.Description,
                    IsSelected = model.SelectedRoleIds.Contains(r.Id)
                }).ToList();

                return View("~/Views/Roles/Assign.cshtml", model);
            }

            var userToUpdate = await _context.Users
                .Include(u => u.Roles)
                .FirstOrDefaultAsync(u => u.Id == model.UserId);

            if (userToUpdate == null)
            {
                return NotFound();
            }

            var selectedRoles = await _context.Roles
                .Where(r => model.SelectedRoleIds.Contains(r.Id))
                .ToListAsync();

            userToUpdate.Roles.Clear();
            foreach (var role in selectedRoles)
            {
                userToUpdate.Roles.Add(role);
            }

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Assign), new { userId = model.UserId });
        }



        //new

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var model = await _context.Users
                .Select(u => new UserRoleListViewModel
                {
                    UserId = u.Id,
                    FullName = u.FullName,
                    Username = u.Username,
                    AssignedRoles = u.Roles.Select(r => r.RoleName).ToList()
                })
                .ToListAsync();

            return View("~/Views/Roles/UserRoleList.cshtml", model);
        }

        [HttpGet]
        public async Task<IActionResult> UserRoleList()
        {
            return await Index();
        }
    }
}
