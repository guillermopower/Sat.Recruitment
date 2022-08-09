namespace Sat.Recruitment.Models.Entities
{
    public class Rule
    {
        public string UserType { get; set; }
        public decimal? RangeMinor { get; set; }
        public decimal? RangeMajor { get; set; }
        public decimal? Percentage { get; set; }
    }
}