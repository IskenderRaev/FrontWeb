using System;

namespace StiGovKg.Application.MediatR.Departments.Queries
{
    public record DepartmentDto(Guid Id, string Name, string Email, Guid RegionId, string RegionName);
}