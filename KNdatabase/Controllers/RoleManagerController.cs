﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace KNdatabase.Controllers
{
    public class RoleManagerController : Controller
    {
        

        private readonly RoleManager<IdentityRole> _roleManager;

        public RoleManagerController(RoleManager<IdentityRole> roleManager)

        {

            _roleManager = roleManager;

        }

        public async Task<IActionResult> Index()

        {

            var roles = await _roleManager.Roles.ToListAsync();

            return View(roles);

        }

        [HttpPost]

        public async Task<IActionResult> AddRole(string roleName)

        {

            if (roleName != null)

            {

                await _roleManager.CreateAsync(new IdentityRole(roleName.Trim()));

            }

            return RedirectToAction("Index");

        }
    }
}
