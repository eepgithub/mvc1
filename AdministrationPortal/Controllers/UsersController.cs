using AdministrationPortal.Data;
using AdministrationPortal.Models;
using AdministrationPortal.Services.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdministrationPortal.Controllers
{

    [Authorize(Roles = "Admin")]
    public class UsersController : Controller
    {

        private readonly IIdentityService _identityService;

        public UsersController(IIdentityService identityService)
        {
            _identityService = identityService;
        }


        public async Task <IActionResult> Index()
        {
            ViewBag.Users = await _identityService.GetAllUsersWithRolesAsync();
            ViewBag.Roles = _identityService.GetAllRoles();

            return View();
        }


        public IActionResult Create()
        {
            return View();
        }




        [HttpPost]
        public async Task<IActionResult> Create(CreateUserViewModel model)
        {
            var user = new ApplicationUser()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                UserName = model.Email
            };


            await _identityService.CreateNewUserAsync(user, model.Password);

            return RedirectToAction("Index");
        }
    }
}
