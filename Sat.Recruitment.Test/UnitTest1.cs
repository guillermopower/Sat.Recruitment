using Sat.Recruitment.Business;
using Sat.Recruitment.Data;
using Sat.Recruitment.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Sat.Recruitment.Test
{
    [CollectionDefinition("Tests", DisableParallelization = true)]
    public class UnitTest1
    {
        [Fact]
        public async Task Test_Business_UserCreated_OK()
        {
            var userManager = new UserManager(new UserData(), new RuleData());
            var usr = new User() { Name = "Mike", Email = "mike@gmail.com", Address = "Av. Juan G", Phone = "+349 1122354215", UserType = "Normal", Money = 124 };
            var result = await userManager.CreateUser(usr);

            Assert.True(result.IsSuccess);
            Assert.Equal("User Created", result.Errors);
        }

        [Fact]
        public async Task Test_Business_UserCreated_NO_OK()
        {
            var userManager = new UserManager(new UserData(), new RuleData());
            var usr = new User()
            {
                Name = "Agustina",
                Email = "Agustina@gmail.com",
                Address = "Av. Juan G",
                Phone = "+349 1122354215",
                UserType = "Normal",
                Money = 124
            };
            var result = await userManager.CreateUser(usr);

            Assert.False(result.IsSuccess);
            Assert.Equal("The user is duplicated", result.Errors);
        }

        [Fact]
        public async Task Test_Business_CalculateGif_1000_UserTyepe_Normal()
        {
            var userManager = new UserManager(new UserData(), new RuleData());
            var usr = new User()
            {
                Name = "Agustina",
                Email = "Agustina@gmail.com",
                Address = "Av. Juan G",
                Phone = "+349 1122354215",
                UserType = "Normal",
                Money = 124
            };
            var result = await userManager.CalculateGif(1000, User.UserTypeEnum.Normal.ToString());

            Assert.Equal(1120, result);
        }

        [Fact]
        public async Task Test_Business_CalculateGif_20_UserType_Normal()
        {
            var userManager = new UserManager(new UserData(), new RuleData());
            var result = await userManager.CalculateGif(20, User.UserTypeEnum.Normal.ToString());
            Assert.Equal((decimal)36, result);
        }

        [Fact]
        public async Task Test_Business_CalculateGif_1_UserType_Normal()
        {
            var userManager = new UserManager(new UserData(), new RuleData());
            var result = await userManager.CalculateGif(1, User.UserTypeEnum.Normal.ToString());

            Assert.Equal((decimal)1, result);
        }

        [Fact]
        public async Task Test_Business_CalculateGif_0_UserType_Normal()
        {
            var userManager = new UserManager(new UserData(), new RuleData());
            var result = await userManager.CalculateGif(0, User.UserTypeEnum.Normal.ToString());

            Assert.Equal((decimal)0, result);
        }

        [Fact]
        public async Task Test_Business_CalculateGif_NegativeAmounts_UserType_Normal()
        {
            var userManager = new UserManager(new UserData(), new RuleData());
            var result = await userManager.CalculateGif(-1, User.UserTypeEnum.Normal.ToString());

            Assert.Equal((decimal)-1, result);
        }

        [Fact]
        public async Task Test_Business_CalculateGif_1000_UserType_SuperUser()
        {
            var userManager = new UserManager(new UserData(), new RuleData());
            var result = await userManager.CalculateGif(1000, User.UserTypeEnum.SuperUser.ToString());

            Assert.Equal((decimal)1200, result);
        }

        [Fact]
        public async Task Test_Business_CalculateGif_1000_UserType_Premium()
        {
            var userManager = new UserManager(new UserData(), new RuleData());
            var result = await userManager.CalculateGif(1000, User.UserTypeEnum.Premium.ToString());

            Assert.Equal((decimal)3000, result);
        }

        [Fact]
        public void Test_Business_IsDuplicated_True()
        {
            var userManager = new UserManager(new UserData(), new RuleData());
            var Agustina = new User()
            {
                Name = "Agustina",
                Email = "Agustina@gmail.com",
                Address = "Av. Juan G",
                Phone = "+349 1122354215",
                UserType = "Normal",
                Money = 124
            };
            List<User> list = new List<User>() { Agustina };

            Assert.True(userManager.IsDuplicated(Agustina, list));
        }

        [Fact]
        public void Test_Business_IsDuplicated_False()
        {
            var userManager = new UserManager(new UserData(), new RuleData());
            var Agustina = new User()
            {
                Name = "Agustina",
                Email = "Agustina@gmail.com",
                Address = "Av. Juan G",
                Phone = "+349 1122354215",
                UserType = "Normal",
                Money = 124
            };

            List<User> list = new List<User>() {
            new User()
            {
                Name = "Pochito",
                Email = "Pochito@gmail.com",
                Address = "Av. Juan G",
                Phone = "+349 1111111",
                UserType = "Normal",
                Money = 124
            }
            , new User()
            {
                Name = "Pepita",
                Email = "Pepita@gmail.com",
                Address = "Av. Juan G",
                Phone = "+349 22222222",
                UserType = "Normal",
                Money = 124
            }
            };

            Assert.False(userManager.IsDuplicated(Agustina, list));
        }
    }
}