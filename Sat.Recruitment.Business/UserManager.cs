using Sat.Recruitment.Data;
using Sat.Recruitment.Models;
using Sat.Recruitment.Models.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Sat.Recruitment.Business
{
    public class UserManager : IUserManager
    {
        private readonly IUserData UserData;
        private readonly IRuleData RuleData;

        public UserManager(IUserData userData, IRuleData ruleData)
        {
            UserData = userData;
            RuleData = ruleData;
        }

        public async Task<Result> CreateUser(User user)
        {
            var newUser = new User
            {
                Name = user.Name,
                Email = Utils.NormalizeEmail(user.Email),
                Address = user.Address,
                Phone = user.Phone,
                UserType = user.UserType,
                Money = user.Money
            };

            newUser.Money = await CalculateGif(newUser.Money, newUser.UserType);

            var users = await UserData.ReadUsersFromFile(@"\\Files\\Users.txt");

            try
            {
                if (!IsDuplicated(newUser, users))
                {
                    Debug.WriteLine("User Created");

                    return new Result()
                    {
                        IsSuccess = true,
                        Errors = "User Created"
                    };
                }
                else
                {
                    Debug.WriteLine("The user is duplicated");

                    return new Result()
                    {
                        IsSuccess = false,
                        Errors = "The user is duplicated"
                    };
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return new Result()
                {
                    IsSuccess = false,
                    Errors = ex.Message
                };
            }
        }

        public async Task<decimal> CalculateGif(decimal originalAmount, string userType)
        {
            decimal finalAmount = originalAmount;
            finalAmount = RuleData.GetPercentage(userType, originalAmount);
            return finalAmount;
        }

        public bool IsDuplicated(User newUser, List<User> userList)
        {
            var isDuplicated = false;
            foreach (var user in userList)
            {
                if (user.Email == newUser.Email
                    ||
                    user.Phone == newUser.Phone)
                {
                    isDuplicated = true;
                }
                else if (user.Name == newUser.Name)
                {
                    if (user.Address == newUser.Address)
                    {
                        isDuplicated = true;
                        throw new Exception("User is duplicated");
                    }
                }
            }

            return isDuplicated;
        }
    }
}