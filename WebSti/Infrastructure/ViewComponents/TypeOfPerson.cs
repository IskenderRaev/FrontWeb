using Microsoft.AspNetCore.Mvc;
using StiGovKg.Application.MediatR.Subsections.Queries.GetSubsections;
using System;
using System.Threading.Tasks;
using WebSti.Infrastructure.ViewComponents;

namespace WebSti.Infrastructure.ViewComponents
{
    public class TypeOfPerson : BaseViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var items = await Mediator.Send(new GetSubsectionsQuery() { SectionType = StiGovKg.Domain.Enums.SectionType.LeftNav });
            return View(items);
        }
    }
}
