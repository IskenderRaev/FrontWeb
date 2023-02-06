using MediatR;
using Microsoft.Extensions.Logging;
using StiGovKg.Application.Common.Extensions;
using StiGovKg.Application.Common.Interfaces;
using StiGovKg.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace StiGovKg.Application.MediatR.Calendar.Queries.GetCalendar
{
    public class GetCalendarQuery : IRequest<IEnumerable<CalendarDto>>
    {
       
    }

    public class GetCalendarQueryHandler : IRequestHandler<GetCalendarQuery , IEnumerable<CalendarDto>>
    {
        private readonly IStigovkgDbContext _Context;
        private readonly ILogger<GetCalendarQueryHandler> _logger;
        public GetCalendarQueryHandler(IStigovkgDbContext context, ILogger<GetCalendarQueryHandler> logger)
        {
            _Context = context;
            _logger = logger;
        }

        public async Task<IEnumerable<CalendarDto>> Handle(GetCalendarQuery request , CancellationToken cancellationToken)
        {
            var query = _Context.TaxpayerCalendar.OrderByDescending(x => x.CalendarDate).ThenBy(x => x.LanguageType).AsEnumerable();
              
         return query.Select(x => x.AsDto());
        }
    }
}
