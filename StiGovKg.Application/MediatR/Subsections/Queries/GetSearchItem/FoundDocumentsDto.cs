using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StiGovKg.Application.MediatR.Subsections.Queries.GetSearchItem
{
    public record FoundDocumentsDto(
        Guid Id, Guid ThemeId, Guid SubsectionId, string Header, string ShortDescription, string HtmlString, int SearchedType
    );
}
