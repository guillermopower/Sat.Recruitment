using Sat.Recruitment.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sat.Recruitment.Data
{
    public interface IUserData
    {
        Task<List<User>> ReadUsersFromFile(string filename);
    }
}