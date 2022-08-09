using Microsoft.AspNetCore.Mvc;
using Sat.Recruitment.Api.DataTransferObjects;
using Sat.Recruitment.Business;
using Sat.Recruitment.Models;
using Sat.Recruitment.Models.Entities;
using System.Threading.Tasks;

namespace Sat.Recruitment.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public partial class UsersController : ControllerBase
    {
        private readonly IUserManager userManager;

        public UsersController(IUserManager _userManager)
        {
            this.userManager = _userManager;
        }

        [HttpPost]
        [Route("/create-user")]
        public async Task<Result> CreateUser(UserDTO user)
        {
            var usr = new User() { Name = user.Name, Email = user.Email, Address = user.Address, Money = user.Money, Phone = user.Phone, UserType = user.UserType };
            return await userManager.CreateUser(usr);
        }
    }
}