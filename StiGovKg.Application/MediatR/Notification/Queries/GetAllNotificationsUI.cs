using MediatR;
using Microsoft.EntityFrameworkCore;
using StiGovKg.Application.Common.Extensions;
using StiGovKg.Application.Common.Interfaces;

namespace StiGovKg.Application.MediatR.Notification.Queries
{
    public class GetAllNotificationsUI : IRequest<List<NotificationCommandDto>>
    {
    }
    public class GetAllNotificationsHandler : IRequestHandler<GetAllNotificationsUI, List<NotificationCommandDto>>
    {
        private readonly IStigovkgDbContext _context;

        public GetAllNotificationsHandler(IStigovkgDbContext context)
        {
            _context = context;
        }

        public async Task<List<NotificationCommandDto>> Handle(GetAllNotificationsUI request, CancellationToken cancellationToken)
        {
            var culture = System.Globalization.CultureInfo.CurrentCulture;
            var query = _context.Notifications;
            var notifications = await query.Select(x => x.AsDto(culture.Name)).ToListAsync();
            if (notifications == null)
            {
                return null;
            }
            return notifications;
        }
    }
}
