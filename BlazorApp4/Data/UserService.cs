using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp4.Data
{
    public class UserService
    {
        private readonly UserManager<IdentityUser> userManager;

        public List<IdentityUser> Users { get; private set; } = new List<IdentityUser>();

        public UserService(UserManager<IdentityUser> userManager)
        {
            this.userManager = userManager;
        }

        public Task<List<IdentityUser>> LoadUsers()
        {
            return userManager.Users.ToListAsync();
        }

        public Task<IdentityResult> Create(IdentityUser user)
        {
            return  userManager.CreateAsync(user);
        }
    }
}
