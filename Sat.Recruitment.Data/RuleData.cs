using Sat.Recruitment.Models.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Sat.Recruitment.Data
{
    public class RuleData : IRuleData
    {
        public decimal GetPercentage(string userType, decimal? amount)
        {
            var finalValue = (decimal)amount;
            List<Rule> Rules = new List<Rule>()
            {
                new Rule(){ UserType = User.UserTypeEnum.Normal.ToString(), RangeMinor = 100, RangeMajor = decimal.MaxValue, Percentage = (decimal)0.12 },
                new Rule(){ UserType = User.UserTypeEnum.Normal.ToString(), RangeMinor = 10, RangeMajor = 100, Percentage = (decimal)0.8 },
                new Rule(){ UserType = User.UserTypeEnum.SuperUser.ToString(), RangeMinor = 100, RangeMajor = decimal.MaxValue, Percentage = (decimal)0.2 },
                new Rule(){ UserType = User.UserTypeEnum.Premium.ToString(), RangeMinor = 100, RangeMajor = decimal.MaxValue, Percentage = (decimal)2 }
            };

            var per = (decimal)0;
            try
            {
                per = (decimal)Rules.FirstOrDefault(x => x.UserType == userType && (amount > x.RangeMinor && amount < x.RangeMajor)).Percentage;
            }
            catch { }
            var gif = per * (decimal)amount;
            finalValue += gif;

            return finalValue;
        }
    }
}