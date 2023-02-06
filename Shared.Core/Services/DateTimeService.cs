using Shared.Core.Interfaces;

namespace Shared.Core.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}
