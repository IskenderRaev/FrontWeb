using StiGovKg.Application.MediatR.Departments.Queries;
using System;
using System.Collections.Generic;

namespace StiGovKg.Application.MediatR.DictRegions.Queries
{
    public record DictRegionWithDepartmentsDto(Guid Id, string Name, IList<DepartmentDto> DepartmentDtos);
}