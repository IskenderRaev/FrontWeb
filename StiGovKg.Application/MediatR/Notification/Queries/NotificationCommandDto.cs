using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StiGovKg.Application.MediatR.Notification.Queries
{
    public record NotificationCommandDto
   (
       Guid Id,
       string Title,
       DateTimeOffset NotificationDate
   );
}
