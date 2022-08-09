namespace Sat.Recruitment.Data
{
    public interface IRuleData
    {
        decimal GetPercentage(string userType, decimal? amount);
    }
}