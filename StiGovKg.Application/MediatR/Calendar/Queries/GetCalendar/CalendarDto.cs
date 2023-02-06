using StiGovKg.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StiGovKg.Application.MediatR.Calendar.Queries.GetCalendar
{
    public record CalendarDto(Guid Id, string CalendarPath, LanguageType Language, int CalendarDate);
}
