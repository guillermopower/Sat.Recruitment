using Sat.Recruitment.Models;
using Sat.Recruitment.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sat.Recruitment.Business
{
    public interface IUserManager
    {
        Task<Result> CreateUser(User user);

        Task<decimal> CalculateGif(decimal originalAmount, string userType);

        bool IsDuplicated(User user, List<User> userList);
    }
}