using Sat.Recruitment.Models.Entities;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;

namespace Sat.Recruitment.Data
{
    public class UserData : IUserData
    {
        public async Task<List<User>> ReadUsersFromFile(string filename)
        {
            var _users = new List<User>();
            var path = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location.Substring(0, Assembly.GetEntryAssembly().Location.IndexOf("bin\\")));
            //Directory.GetCurrentDirectory()
            var completePath = path + filename;

            FileStream fileStream = new FileStream(completePath, FileMode.Open);

            StreamReader reader = new StreamReader(fileStream);

            while (reader.Peek() >= 0)
            {
                var line = reader.ReadLineAsync().Result;
                var user = new User
                {
                    Name = line.Split(',')[0].ToString(),
                    Email = line.Split(',')[1].ToString(),
                    Phone = line.Split(',')[2].ToString(),
                    Address = line.Split(',')[3].ToString(),
                    UserType = line.Split(',')[4].ToString(),
                    Money = decimal.Parse(line.Split(',')[5].ToString()),
                };
                _users.Add(user);
            }
            reader.Close();

            return _users;
        }
    }
}