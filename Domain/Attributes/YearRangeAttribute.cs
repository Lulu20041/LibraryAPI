using System.ComponentModel.DataAnnotations;

namespace LibraryAPI.Domain.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public class YearRangeAttribute : RangeAttribute
    {
        public YearRangeAttribute(int minimum) : base(minimum, DateTime.Now.Year)
        {
        }
    }
}
